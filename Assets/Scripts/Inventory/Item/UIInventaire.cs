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

    [Header("Inventaire")]
    [SerializeField] private TextMeshProUGUI titreText = null;
    [SerializeField] private GameObject invantaireObj = null;
    [SerializeField] private GameObject contentBox = null;
    [SerializeField] private GameObject prefabItemSlots = null;
    [SerializeField] private GameObject detailPlusObj = null;
    [SerializeField] private GameObject armureCase = null;
    [SerializeField] private GameObject carteObj = null;
    [SerializeField] private ButtonChangeUiType[] buttonChangeUiType = null;
    private List<UIItemSlots> uiItemSlots = new List<UIItemSlots>();
    private PlayerController playerController = null;
    private PlayerAbiliteControleur playerAbiliteControleur = null;
    private PlayerCameraMouvement playerCameraMouvement = null;
    private PlayerInventaire playerInventaire = null;
    private bool inventaireOpen = false;
    private int selectedTypePage = 0;


    #region GetterSetter
    public bool InventaireOpen { get { return inventaireOpen; } set { inventaireOpen = value; } }
    #endregion

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerInventaire = playerController.GetComponent<PlayerInventaire>();
        playerAbiliteControleur = playerController.GetComponent<PlayerAbiliteControleur>();
        playerCameraMouvement = GameObject.FindGameObjectWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>();
    }
    public void ItemTakeDrop(Item item, int nombre, bool take)
    {
        GameObject prefab = Instantiate(spawnPrefabAddItemUi, verticalLayoutAddItem.transform.position, Quaternion.identity, verticalLayoutAddItem.transform);
        TextMeshProUGUI nomText = prefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nombreText = prefab.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        RawImage iconImage = prefab.transform.GetChild(2).GetComponent<RawImage>();
        nomText.text = item.Nom;
        nomText.color = itemDropRareteEffect[(int)item.ItemRarete].HdrColor;
        nombreText.text = (take ? "x " : "- ") + nombre.ToString();
        nombreText.color = take ? addItem : removeItem;
        iconImage.texture = item.SpriteIcon.texture;
        iconImage.material.SetFloat("_Shine", itemDropRareteEffect[(int)item.ItemRarete].shine);
        StartCoroutine(DispawnAddItem(prefab.GetComponent<Animator>()));
        BoutonChangeUI(selectedTypePage);
    }

    public void BoutonChangeUI(int ind)
    {
        selectedTypePage = ind;
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
             foreach (Transform child in contentBox.transform){GameObject.Destroy(child.gameObject);}
        }
    }

    public void ChangeInventairePage(int type)
    {
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
                ui.GetComponent<UIItemSlots>().ItemInv = ii[i];
                uiItemSlots.Add(ui.GetComponent<UIItemSlots>());
            }
        }
        for (int i = countSlot; i < playerInventaire.MaxSlotPage; i++)
        {
            GameObject ui = Instantiate(prefabItemSlots, contentBox.transform.position, Quaternion.identity, contentBox.transform);            
            ui.GetComponent<UIItemSlots>().IndiceSlots = i;
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
}
