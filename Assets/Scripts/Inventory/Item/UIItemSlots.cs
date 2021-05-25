using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemSlots : MonoBehaviour
{
    [SerializeField] private Sprite backGroundHaveItem = null;
    [SerializeField] private Sprite backGroundNotHaveItem = null;
    [SerializeField] private Sprite nullImage = null;
    [SerializeField] private Shader shader = null;
    private ItemInventaire itemInventaire = null;

    [Header("UI")]
    [SerializeField] private RawImage iconImage = null;
    [SerializeField] private RawImage selected = null;
    [SerializeField] private RawImage backGround = null;
    [SerializeField] private TextMeshProUGUI countText = null;
    [SerializeField] private float timerInfoBox = 0.4f;
    private UIInventaire uIInventaire = null;
    private int indice = -1;
    private bool inslot = false;
    private bool menuC = false;
    public UIItemSlots(int ind, ItemInventaire item = null)
    {
        ItemInv = item;
        indice = ind;
    }
    public UIItemSlots() { }

    public virtual ItemInventaire ItemInv
    {
        get { return itemInventaire; }
        set
        {
            itemInventaire = value;
            if (itemInventaire != null)
            {
                iconImage.material = new Material(shader);
                itemInventaire.NumeroPosInventaire = indice;
                iconImage.texture = itemInventaire.Item.SpriteIcon.texture;
                backGround.texture = backGroundHaveItem.texture;
                countText.text = "x " + itemInventaire.NbItem.ToString();
                iconImage.material.SetFloat("_Shine", uIInventaire.Idre[(int)itemInventaire.Item.ItemRarete].shine);
                iconImage.material.SetColor("_OutlineColor", (Vector4)uIInventaire.Idre[(int)itemInventaire.Item.ItemRarete].HdrColor);
            }
            else
            {
                iconImage.texture = nullImage.texture;
                countText.text = "";
            }
            selected.enabled = itemInventaire != null;
        }

    }
    public bool MenuC { set{menuC = value;}get{return menuC;}}

    public UIInventaire UIInventaireSwith { set { uIInventaire = value; } }

    public int IndiceSlots { set { indice = value; } }

    public void Drag()
    {
        if (uIInventaire != null && itemInventaire != null)
        {
            iconImage.texture = nullImage.texture;
            countText.text = "";
            uIInventaire.Drag(this);
        }
    }
    public void Drop()
    {
        if (uIInventaire != null)
        {
            uIInventaire.Drop(this);
        }
    }

    public virtual void menuContextuel()
    {
        if(itemInventaire != null)
        {
            uIInventaire.MenuContextuel(this);
        }
    }

    public void EnterSlot()
    {
        if(itemInventaire != null)
        {
            inslot = true;
            StartCoroutine(InfoBox());
        }
    }

    public void ExitSlot()
    {
        if(uIInventaire)
        {
            inslot = false;
            uIInventaire.HideInfoBox();
        }
    }

    IEnumerator InfoBox()
    {
        float timer = timerInfoBox;
        while(timer > 0 && inslot)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        if(inslot && !menuC)
        {
            uIInventaire.ShowInfoBox(this);
        }
    }
}

