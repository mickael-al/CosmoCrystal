using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class ButtonChangeUiType
{
    public string titreTxt;
    public Color colorTxt;
    public bool armure = true;
    public bool detailPlus = true;
    public bool changeInventaire = true;
    public bool carte = true;
}

public class UIInventaire : MonoBehaviour
{
    [Header("AddItem")]
    [SerializeField] private GameObject spawnPrefabAddItemUi = null;
    [SerializeField] private GameObject verticalLayoutAddItem = null;
    [SerializeField] private ItemDropRareteEffect[] itemDropRareteEffect = null;
    [SerializeField] private float tempsDispawnAddItem = 2.0f;
    [SerializeField] private Color addItem = Color.white;
    [SerializeField] private Color removeItem = Color.white;
    [SerializeField] private Shader shader = null;

    [Header("Inventaire")]
    [SerializeField] private TextMeshProUGUI titreText = null;
    [SerializeField] private GameObject invantaireObj = null;
    [SerializeField] private GameObject contentBox = null;
    [SerializeField] private GameObject prefabItemSlots = null;
    [SerializeField] private GameObject detailPlusObj = null;
    [SerializeField] private GameObject armureCase = null;
    [SerializeField] private GameObject carteObj = null;
    [SerializeField] private ButtonChangeUiType[] buttonChangeUiType = null;
    [SerializeField] private RawImage imageMouse = null;
    [SerializeField] private GameObject infoBox = null;
    [SerializeField] private GameObject menuContextuel = null;
    [SerializeField] private TextMeshProUGUI textPiece = null;
    [SerializeField] private List<UIItemSlotsEquipement> uiItemSlotsEquipement = new List<UIItemSlotsEquipement>();
    private List<UIItemSlots> uiItemSlots = new List<UIItemSlots>();
    private PlayerController playerController = null;
    private PlayerAbiliteControleur playerAbiliteControleur = null;
    private PlayerCameraMouvement playerCameraMouvement = null;
    private PlayerInventaire playerInventaire = null;
    private bool inventaireOpen = false;
    private int selectedTypePage = 0;
    private UIItemSlots swhitchSlots = null;
    private UIItemSlots menuContext = null;


    #region GetterSetter
    public bool InventaireOpen { get { return inventaireOpen; } set { inventaireOpen = value; } }
    public ItemDropRareteEffect[] Idre { get { return itemDropRareteEffect; } }
    public GameObject PlayerObj { get { return playerController.gameObject; } }
    #endregion

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerInventaire = playerController.GetComponent<PlayerInventaire>();
        playerAbiliteControleur = playerController.GetComponent<PlayerAbiliteControleur>();
        playerCameraMouvement = GameObject.FindGameObjectWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>();
        InputManager.InputJoueur.Controller.Drop.canceled += ctx => StartCoroutine(DropWait());
    }
    public void ItemTakeDrop(Item item, int nombre, bool take)
    {
        GameObject prefab = Instantiate(spawnPrefabAddItemUi, verticalLayoutAddItem.transform.position, Quaternion.identity, verticalLayoutAddItem.transform);
        TextMeshProUGUI nomText = prefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nombreText = prefab.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        RawImage iconImage = prefab.transform.GetChild(2).GetComponent<RawImage>();
        iconImage.material = new Material(shader);
        nomText.text = item.Nom;
        nomText.color = itemDropRareteEffect[(int)item.ItemRarete].HdrColorText;
        nombreText.text = (take ? "x " : "- ") + nombre.ToString();
        nombreText.color = take ? addItem : removeItem;
        iconImage.texture = item.SpriteIcon.texture;
        iconImage.material.SetFloat("_Shine", itemDropRareteEffect[(int)item.ItemRarete].shine);
        iconImage.material.SetColor("_OutlineColor", (Vector4)itemDropRareteEffect[(int)item.ItemRarete].HdrColor);
        StartCoroutine(DispawnAddItem(prefab.GetComponent<Animator>()));
        BoutonChangeUI(selectedTypePage);
    }

    public void BoutonChangeUI(int ind)
    {
        HideInfoBox();
        HideMenuContextuel();        
        imageMouse.gameObject.SetActive(false);
        selectedTypePage = ind;
        textPiece.text = playerInventaire.Piece.ToString("00000");
        titreText.text = buttonChangeUiType[ind].titreTxt;
        titreText.color = buttonChangeUiType[ind].colorTxt;
        armureCase.SetActive(buttonChangeUiType[ind].armure);
        carteObj.SetActive(buttonChangeUiType[ind].carte);
        detailPlusObj.SetActive(buttonChangeUiType[ind].detailPlus);
        if (buttonChangeUiType[ind].changeInventaire)
        {
            ChangeInventairePage(ind);
        }
        else
        {
            foreach (Transform child in contentBox.transform) { GameObject.Destroy(child.gameObject); }
        }
    }

    public void ChangeInventairePage(int type)
    {
        foreach (UIItemSlotsEquipement uie in uiItemSlotsEquipement)
        {
            uie.ItemInv = null;
            uie.UIInventaireSwith = this;
        }
        foreach (Transform child in contentBox.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        uiItemSlots = new List<UIItemSlots>();
        List<ItemInventaire> ii = playerInventaire.ItemInventaire;
        int countSlot = 0;
        for (int i = 0; i < ii.Count; i++)
        {
            if ((int)(ii[i].Item.typeInventaire) == type)
            {
                GameObject ui = Instantiate(prefabItemSlots, contentBox.transform.position, Quaternion.identity, contentBox.transform);
                ui.GetComponent<UIItemSlots>().IndiceSlots = countSlot++;
                ui.GetComponent<UIItemSlots>().UIInventaireSwith = this;
                ui.GetComponent<UIItemSlots>().ItemInv = ii[i];
                uiItemSlots.Add(ui.GetComponent<UIItemSlots>());
            }
            if ((int)(ii[i].Item.typeInventaire) == (int)Item.CaseTypeInventaire.ObjEquipable)
            {
                if (ii[i].EquipementID >= 0)
                {
                    foreach (UIItemSlotsEquipement uie in uiItemSlotsEquipement)
                    {
                        if (ii[i].EquipementID == (int)uie.TypeEquipement)
                        {
                            uie.ItemInv = ii[i];
                        }
                    }
                }
            }
        }
        for (int i = countSlot; i < playerInventaire.MaxSlotPage; i++)
        {
            GameObject ui = Instantiate(prefabItemSlots, contentBox.transform.position, Quaternion.identity, contentBox.transform);
            ui.GetComponent<UIItemSlots>().IndiceSlots = i;
            ui.GetComponent<UIItemSlots>().UIInventaireSwith = this;
        }
    }

    IEnumerator DispawnAddItem(Animator anim)
    {
        yield return new WaitForSeconds(tempsDispawnAddItem);
        anim.SetTrigger("exit");
        yield return new WaitForSeconds(0.25f);
        Destroy(anim.gameObject);
    }

    public void OpenInventaire(bool active = true)
    {
        BoutonChangeUI(selectedTypePage);
        if (!active)
        {
            InventaireOpen = false;
            invantaireObj.SetActive(InventaireOpen);
            playerCameraMouvement.CameraMove = !InventaireOpen;
            playerCameraMouvement.MouseCursorMove = InventaireOpen;
            playerCameraMouvement.MouseSee = InventaireOpen;
            return;
        }
        if (!playerController.IsInteract && !playerAbiliteControleur.IsChoising && !playerAbiliteControleur.IsUsing)
        {
            InventaireOpen = !InventaireOpen;
            invantaireObj.SetActive(InventaireOpen);
            playerCameraMouvement.CameraMove = !InventaireOpen;
            playerCameraMouvement.MouseCursorMove = InventaireOpen;
            playerCameraMouvement.MouseSee = InventaireOpen;
        }
    }

    public void Drag(UIItemSlots uIItemSlots)
    {
        swhitchSlots = uIItemSlots;
        imageMouse.gameObject.SetActive(true);
        imageMouse.texture = swhitchSlots.ItemInv.Item.SpriteIcon.texture;
    }
    IEnumerator DropWait()
    {
        yield return null;
        Drop(null);
    }

    public void ShowInfoBox(UIItemSlots uiItemSlots)
    {
        if (uiItemSlots.ItemInv != null)
        {
            infoBox.SetActive(true);
            infoBox.transform.position = uiItemSlots.transform.position;
            TextMeshProUGUI nameBox = infoBox.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI textBox = infoBox.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            nameBox.text = uiItemSlots.ItemInv.Item.Nom;
            nameBox.color = itemDropRareteEffect[(int)uiItemSlots.ItemInv.Item.ItemRarete].HdrColorText;
            textBox.text = uiItemSlots.ItemInv.Item.Description;
        }
    }
    public void HideInfoBox()
    {
        infoBox.SetActive(false);
    }

    public void Equip(UIItemSlotsEquipement uiItemSE)
    {
        imageMouse.gameObject.SetActive(false);
        if (swhitchSlots != null)
        {
            if (uiItemSE == null || !(swhitchSlots.ItemInv.Item is Equipable))
            {
                swhitchSlots.ItemInv = swhitchSlots.ItemInv;
                swhitchSlots = null;
                return;
            }
            if (((Equipable)swhitchSlots.ItemInv.Item).EquipementTypeObjet == uiItemSE.TypeEquipement)
            {
                uiItemSE.menuContextuel();
                uiItemSE.ItemInv = swhitchSlots.ItemInv;
                uiItemSE.ItemInv.EquipementID = (int)uiItemSE.TypeEquipement;
                PlayerObj.GetComponent<PlayerEquipableModel>().AddModel(((Equipable)swhitchSlots.ItemInv.Item).PlayerEquipement);
                swhitchSlots.ItemInv = swhitchSlots.ItemInv;
                swhitchSlots = null;
            }
        }
    }

    public void MenuContextuel(UIItemSlots uIItemSlots)
    {
        if (!uIItemSlots.ItemInv.Item.Jetable && !uIItemSlots.ItemInv.Item.Utilisable)
        {
            return;
        }
        menuContextuel.SetActive(true);
        menuContextuel.transform.position = uIItemSlots.transform.position;
        menuContextuel.transform.GetChild(0).GetChild(0).gameObject.SetActive(uIItemSlots.ItemInv.Item.Utilisable);
        menuContextuel.transform.GetChild(0).GetChild(1).gameObject.SetActive(uIItemSlots.ItemInv.Item.Jetable);
        uIItemSlots.MenuC = true;
        menuContext = uIItemSlots;
        HideInfoBox();
    }

    public void HideMenuContextuel()
    {
        if (menuContext != null)
        {
            menuContext.MenuC = false;
            menuContext = null;
        }
        menuContextuel.SetActive(false);
    }

    public void Utiliser()
    {
        if (menuContext != null)
        {
            if (menuContext.ItemInv.Item.Utilisable)
            {
                if (menuContext.ItemInv.Item.UseEffect(GameObject.FindGameObjectWithTag("Player").GetComponent<Character>()))
                {
                    menuContext.ItemInv.NbItem--;
                    BoutonChangeUI(selectedTypePage);
                }
            }
        }
        HideMenuContextuel();
    }

    public void Lacher()
    {
        if (menuContext != null)
        {
            if (menuContext.ItemInv.Item.Jetable)
            {
                menuContext.ItemInv.EquipementID = -1;
                if (menuContext.ItemInv.Item is Equipable)
                {
                    PlayerObj.GetComponent<PlayerEquipableModel>().RemoveModel(((Equipable)menuContext.ItemInv.Item).PlayerEquipement);
                }     
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventaire>().Lacher(menuContext.ItemInv);
                BoutonChangeUI(selectedTypePage);                                               
            }
        }
        HideMenuContextuel();
    }

    public void Drop(UIItemSlots uIItemSlots)
    {
        imageMouse.gameObject.SetActive(false);
        if (swhitchSlots != null)
        {
            if (uIItemSlots == null)
            {
                swhitchSlots.ItemInv = swhitchSlots.ItemInv;
                swhitchSlots = null;
                return;
            }
            ItemInventaire ii = uIItemSlots.ItemInv;
            uIItemSlots.ItemInv = swhitchSlots.ItemInv;
            swhitchSlots.ItemInv = ii;
            swhitchSlots = null;
        }
    }
}
