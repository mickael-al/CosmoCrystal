using UnityEngine;

[System.Serializable]
public class AttaqueSave
{
    private Attaque attaque = null;
    [SerializeField] private string resourcesName = "";   

    public AttaqueSave(Attaque a)
    {
        Attaque = a;
    }

    #region GetterSetter
    public Attaque Attaque
    {
        get
        {
            if (attaque == null)
            {
                attaque = Resources.Load("AttaqueCombat/" + resourcesName) as Attaque;
            }
            return attaque;
        }
        set
        {
            attaque = value;
            resourcesName = attaque.name;
        }
    }
    public string ResourcesName { get { return resourcesName; } }

    #endregion
}
