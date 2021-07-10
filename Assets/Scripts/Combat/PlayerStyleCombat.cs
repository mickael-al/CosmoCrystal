using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStyleCombat : StyleCombat
{
    protected bool choix = false;
    protected Attaque attaqueChoix = null;
    protected List<GameObject> cible = null;
    public override IEnumerator sCombat()
    {
        Vector3 targetPosition = transform.position;
        while (!endFight)
        {
            float timer = 0.0f;
            while (!canFight) //player esquive attaque
            {
                if (Mathf.Abs(InputManager.InputJoueur.Controller.Mouvement.ReadValue<Vector2>().y) > 0)
                {
                    float mult = InputManager.InputJoueur.Controller.Mouvement.ReadValue<Vector2>().y > 0 ? 3.0f : -3.0f;
                    while(timer < 0.2f)
                    {
                        timer+=Time.deltaTime;
                        transform.position = targetPosition + new Vector3((timer/0.2f)*mult, 0, 0);
                        yield return null;
                    }
                    while(timer > 0.0f)
                    {
                        timer-=Time.deltaTime;
                        transform.position = targetPosition + new Vector3((timer/0.2f)*mult, 0, 0);
                        yield return null;
                    }
                    transform.position = targetPosition;
                }
                yield return null;
            }
            canFight = false;
            yield return null;
            choix = true;
            cm.UICombatChoix(true);
            while (choix)
            {
                yield return null;
            }
            cm.UICombatChoix(false);

            StartCoroutine(attaqueChoix.AttaqueRendu.Rendu(gameObject, cible, attaqueChoix));
            yield return null;
            while (attaqueChoix.AttaqueRendu.IsRunning)
            {
                yield return null;
            }
            yield return new WaitForSeconds(1.0f);
            cm.Next();
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AttaqueDegat")
        {
            AttaqueDegatCombat adc = other.GetComponent<AttaqueDegatCombat>();
            if (adc.LanceurStat.name == base.stat.name) { return; }
            float DegCal = 0;
            if (adc.LanceurAttaque.TypeAttaque == Attaque.TypesAttaques.Physique)
            {
                DegCal = ((((adc.LanceurStat.Niveaux * 0.8f + 2.0f) * adc.LanceurStat.AttaqueMax * adc.LanceurAttaque.Degat) / (stat.DefenceMax * 50.0f)) + 2.0f) * (adc.PourcentageReussite / 100.0f);
            }
            else if (adc.LanceurAttaque.TypeAttaque == Attaque.TypesAttaques.Special)
            {
                DegCal = ((((adc.LanceurStat.Niveaux * 0.8f + 2.0f) * adc.LanceurStat.AttaqueMaxSpecial * adc.LanceurAttaque.Degat) / (stat.DefenceMaxSpecial * 50.0f)) + 2.0f) * (adc.PourcentageReussite / 100.0f);
            }
            DegCal = Mathf.Round(DegCal);
            base.stat.Vie -= DegCal;
            cm.Uisp.MajValue();
            cm.Ftc.CreateFloatingText(DegCal.ToString(), transform);
        }
    }


    #region GetterSetter
    public bool Choix { set { choix = value; } get { return choix; } }
    public Attaque AttaqueChoix { set { attaqueChoix = value; } get { return attaqueChoix; } }
    public List<GameObject> Cible { set { cible = value; } get { return cible; } }
    #endregion

}
