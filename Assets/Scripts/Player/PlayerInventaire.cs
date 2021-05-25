using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInventaire : Inventaire, I_Save
{
    private UIInventaire uiInventaire = null;    
    private PlayerInteract playerInteract = null;
    private PlayerAbiliteControleur playerAbiliteControleur = null;

    #region GetterSetter
        public bool inInventaire
        {
            get
            {
                return uiInventaire.InventaireOpen;
            }
        }
    #endregion

    public override bool AddItem(Item item, int nombre, out int reste)
    {
        bool result = base.AddItem(item, nombre, out reste);
        if (reste != nombre && !result)
        {
            uiInventaire.ItemTakeDrop(item, reste, true);
        }
        else if (result)
        {
            uiInventaire.ItemTakeDrop(item, nombre, true);
        }
        return result;
    }
    public void Save(string s)
    {
        JSONArchiver.SaveJSONsFile(JSONArchiver.JSONPath, s, JsonUtility.ToJson(this));
    }
    protected override void Start()
    {
        base.Start();
        playerAbiliteControleur = GetComponent<PlayerAbiliteControleur>();
        uiInventaire = GameObject.FindWithTag("SceneManager").GetComponent<UIInventaire>();
        InputManager.InputJoueur.Controller.Inventaire.started += ctx => switchInventaire(); 
        playerInteract = GetComponent<PlayerInteract>();
    }

    void switchInventaire()
    {     
        if(!playerInteract.isInteract && (!playerAbiliteControleur.IsUsing || !playerAbiliteControleur.IsChoising))  
        {
            uiInventaire.OpenInventaire(); 
        }
    }
    public void Load(string s)
    {
        bool state = false;
        JsonUtility.FromJsonOverwrite(JSONArchiver.LoadJsonsFile(JSONArchiver.JSONPath, s, out state), this);
        if (!state)
        {
            itemInventaire = new List<ItemInventaire>();
        }
    }

    public override void Lacher(ItemInventaire ii)
    {
        base.Lacher(ii);
        if(ii.Item.Jetable)
        {
            uiInventaire.ItemTakeDrop(ii.Item, ii.NbItem, false);
        }
    }
}
