using UnityEngine;

public class PlayerStarter : CombatStarter, InteractableAbilite, I_Save
{
    private GameObject sceneManagerObj = null;
    protected override void Start()
    {
        sceneManagerObj = GameObject.FindWithTag("SceneManager");
    }
    public void Interact(Character owner)
    {
        GameObject.FindObjectOfType<CombatManager>().StartCombat(false, gameObject, owner.gameObject);
    }

    public void Healing(float heal)
    {
        statistique.Vie += heal;
        if(statistique.Vie > statistique.VieMax)
        {
            statistique.Vie = statistique.VieMax;
        }
        sceneManagerObj.GetComponent<UIStatPlayer>().MajValue();
    }

    public void HealingMana(float heal)
    {
        statistique.Mana += heal;
        if(statistique.Mana > statistique.ManaMax)
        {
            statistique.Mana = statistique.ManaMax;
        }
        sceneManagerObj.GetComponent<UIStatPlayer>().MajValue();
    }

    public void TakeExternalDamage(float damage, float effCamMag = 0.0f, float effCamDur = 0.0f, float effCamSmoth = 0.0f)
    {
        if (statistique.Vie - damage < 0)
        {
            statistique.Vie = 0;
            Transform respawnPoint = GameObject.FindWithTag("RespawnPoint").transform;
            StartCoroutine(sceneManagerObj.GetComponent<UIGameOver>().DeathPlayer(respawnPoint.position, respawnPoint.eulerAngles.y));
        }
        else
        {
            statistique.Vie -= damage;
            GameObject.FindWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>().ApplyEffect(new ShakeCamera(), effCamDur, effCamMag, effCamSmoth);
        }
        sceneManagerObj.GetComponent<UIStatPlayer>().MajValue();
    }

    public void Respawn()
    {
        statistique.Vie = statistique.VieMax * 0.1f;
        sceneManagerObj.GetComponent<UIStatPlayer>().MajValue();
    }

    public void Save(string s)
    {
        JSONArchiver.SaveJSONsFile(JSONArchiver.JSONPath, s, JsonUtility.ToJson(base.statistique));
    }
    public void Load(string s)
    {
        bool state = false;
        JsonUtility.FromJsonOverwrite(JSONArchiver.LoadJsonsFile(JSONArchiver.JSONPath, s, out state), base.statistique);
        if (!state)
        {
            base.statistique = Resources.Load("Stat/Player") as Statistique;
            base.statistique.Vie = base.statistique.VieBase;
            base.statistique.Mana = base.statistique.ManaBase;
            base.statistique.Niveaux = 1.0f;
            base.statistique.Experience = 0.0f;
            base.statistique.CharacterType = new Statistique.Types[1];
            base.statistique.CharacterType[0] = Statistique.Types.Normal;
            base.statistique.VieBaseBonus = 0.0f;
            base.statistique.ManaBaseBonus = 0.0f;
            base.statistique.VitesseBaseBonus = 0.0f;
            base.statistique.AttaqueBaseBonus = 0.0f;
            base.statistique.DefenceBaseBonus = 0.0f;
            base.statistique.AttaqueBaseSpecialBonus = 0.0f;
            base.statistique.DefenceBaseSpecialBonus = 0.0f;
        }
    }
}
