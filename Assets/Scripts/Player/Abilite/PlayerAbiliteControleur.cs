using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S_PlayerAbility
{
    public bool[] hasAbilite;
}

public class PlayerAbiliteControleur : MonoBehaviour,I_Save
{
    [SerializeField] private Character playerControleur = null;
    [SerializeField] private PlayerInteract playerInteract = null;
    [SerializeField] private Abilite currentUseAbilite = null;
    [SerializeField] private List<Abilite> allAbilite = new List<Abilite>();
    [SerializeField] private bool isChoising = false;

    #region Getter Setter
    public bool IsChoising
    {
        set{
            isChoising = value;
        }
        get{
            return isChoising;
        }
    }

    public bool IsUsing
    {
        get{
            return currentUseAbilite != null ? currentUseAbilite.isActive() : false;
        }
    }
    public S_PlayerAbility SavePlayerAbilite
    {
        get{
            return savePlayerAbilite;
        }
    }
    #endregion

    #region Save
    private S_PlayerAbility savePlayerAbilite = new S_PlayerAbility();

    #endregion

    private void Awake() {
        allAbilite.Add(gameObject.AddComponent<Morsure>() as Morsure);
        savePlayerAbilite.hasAbilite = new bool[allAbilite.Count];     
        savePlayerAbilite.hasAbilite[0] = true; //temporaire
    }
    void Start()
    {
        InputManager.InputJoueur.Controller.ActionPrincipale.performed += ctx => StartAbilite();  
    }

    public void StartAbilite()
    {
        if(currentUseAbilite != null && !playerControleur.IsInteract && !playerInteract.CanInteract && !IsChoising)
        {
            if(!currentUseAbilite.isActive())
            {
                currentUseAbilite.startAbilite();
            }
        }
    }

    public void ChangeAbilite(int i)
    {
        if(currentUseAbilite != null)
        {
            if(currentUseAbilite.isActive())
            {
                currentUseAbilite.endAbilite();
            }
        }
        if(i < savePlayerAbilite.hasAbilite.Length)
        {
            if(savePlayerAbilite.hasAbilite[i])
            {
                currentUseAbilite = allAbilite[i];
            }
            else{
                currentUseAbilite = null;
            }
        }
        else{
            currentUseAbilite = null;
        }
    }

    public void Save(string s)
    {
        //Debug.Log(JsonUtility.ToJson(savePlayerAbilite));
    }
    public void Load(string s)
    {
        //Debug.Log(JsonUtility.FromJson<S_PlayerAbility>(""));
    }
}
