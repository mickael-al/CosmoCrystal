using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiStyleCombat : StyleCombat
{
    public override IEnumerator sCombat()
    {
        while (!endFight)
        {
            while (!canFight)
            {
                yield return null;
            }
            canFight = false;

            int r = Random.Range(0, attaquesList.Count);
            StartCoroutine(attaquesList[r].Attaque.AttaqueRendu.Rendu(gameObject, cm.AllPlayer, attaquesList[r].Attaque));
            while (attaquesList[r].Attaque.AttaqueRendu.IsRunning)
            {
                yield return null;
            }
            cm.Next();
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AttaqueDegat")
        {
            AttaqueDegatCombat adc = other.GetComponent<AttaqueDegatCombat>();
            float DegCal = 0;
            if (adc.LanceurStat.name == base.stat.name) { return; }
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
            FloatingTextControler.CreateFloatingText(DegCal.ToString(), transform);
            cm.NoteAttaque(adc.PourcentageReussite / 100.0f);
        }
    }
}
