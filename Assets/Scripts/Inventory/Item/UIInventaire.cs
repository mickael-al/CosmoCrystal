using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    [SerializeField] private GameObject invantaireObj = null;
    private PlayerController playerController = null;
    private PlayerAbiliteControleur playerAbiliteControleur = null;
    private PlayerCameraMouvement playerCameraMouvement = null;
    private bool inventaireOpen = false;
    private int selectedTypePage = 0;


    #region GetterSetter
    public bool InventaireOpen { get { return inventaireOpen; } set { inventaireOpen = value; } }
    #endregion

    private void Start() {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerAbiliteControleur = playerController.GetComponent<PlayerAbiliteControleur>();
        playerCameraMouvement = GameObject.FindGameObjectWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>();
    }
    public void ItemTakeDrop(Item item,int nombre,bool take)
    {
        GameObject prefab = Instantiate(spawnPrefabAddItemUi,verticalLayoutAddItem.transform.position,Quaternion.identity,verticalLayoutAddItem.transform);
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
    }

    public void ChangeInventairePage(int type)
    {

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
        if(!active)
        {            
            InventaireOpen = false;
            invantaireObj.SetActive(InventaireOpen);   
            playerCameraMouvement.CameraMove = !InventaireOpen;
            playerCameraMouvement.MouseCursorMove = InventaireOpen;
            playerCameraMouvement.MouseSee = InventaireOpen;
            return;
        }
        if(!playerController.IsInteract && !playerAbiliteControleur.IsChoising && !playerAbiliteControleur.IsUsing)
        {
            InventaireOpen = !InventaireOpen;
            invantaireObj.SetActive(InventaireOpen);   
            playerCameraMouvement.CameraMove = !InventaireOpen;
            playerCameraMouvement.MouseCursorMove = InventaireOpen;
            playerCameraMouvement.MouseSee = InventaireOpen;
        }
    }
}
