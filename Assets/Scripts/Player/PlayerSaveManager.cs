using UnityEngine;

[System.Serializable]
public class InfoPartiJoueur
{
    public string nom;
    public float vie;
    public float mana;
    public string tempsDate;
    public string tempsHeure;
    public float tempsTotal;
}

public class PlayerSaveManager : MonoBehaviour
{
    [SerializeField] private InfoPartiJoueur infoPartiJoueur = new InfoPartiJoueur();
    private I_Save[] allPlayerSave = null;

    #region GetterSetter

    public I_Save[] PlayerSave
    {
        get{
            return GetComponentsInChildren<I_Save>();
        }
    }
    #endregion

    public void SaveAll(int p)
    {
        allPlayerSave = PlayerSave;
        for(int i = 0 ; i < allPlayerSave.Length;i++)
        {
            allPlayerSave[i].Save("Player"+i);
        }
        Save("Player_"+p);
    }

    public void LoadAll(int p)
    {
        allPlayerSave = PlayerSave;
        for(int i = 0 ; i < allPlayerSave.Length;i++)
        {
            allPlayerSave[i].Load("Player"+i);
        }
        Load("Player_"+p);
    }

    void Update() 
    {
       infoPartiJoueur.tempsTotal += Time.deltaTime; 
    }

    public void Save(string s)
    {                
        infoPartiJoueur.tempsDate = System.DateTime.Now.ToString("yyyy/MM/dd");
        infoPartiJoueur.tempsHeure = System.DateTime.Now.ToString("HH:mm");
        infoPartiJoueur.vie = GetComponent<PlayerStarter>().Stat.Vie;
        infoPartiJoueur.mana = GetComponent<PlayerStarter>().Stat.Mana;
        JSONArchiver.SaveJSONsFile(JSONArchiver.JSONPath,s,JsonUtility.ToJson(infoPartiJoueur));
    }
    public void Load(string s)
    {
        bool state = false;
        infoPartiJoueur = JsonUtility.FromJson<InfoPartiJoueur>(JSONArchiver.LoadJsonsFile(JSONArchiver.JSONPath,s,out state));
        if(!state)
        {
            infoPartiJoueur = new InfoPartiJoueur();
            infoPartiJoueur.nom = "";
            infoPartiJoueur.vie = GetComponent<PlayerStarter>().Stat.VieBase;
            infoPartiJoueur.mana = GetComponent<PlayerStarter>().Stat.ManaBase;
            infoPartiJoueur.tempsTotal = 0.0f;
            infoPartiJoueur.tempsDate = System.DateTime.Now.ToString("yyyy/MM/dd");
            infoPartiJoueur.tempsHeure = System.DateTime.Now.ToString("HH:mm");
        }
    }


}
