using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemSlots : MonoBehaviour
{
    [SerializeField] private Sprite backGroundHaveItem = null;
    [SerializeField] private Sprite backGroundNotHaveItem = null;
    [SerializeField] private Sprite nullImage = null;
    private ItemInventaire itemInventaire = null;

    [Header("UI")]
    [SerializeField] private RawImage iconImage = null;
    [SerializeField] private RawImage selected = null;
    [SerializeField] private RawImage backGround = null;
    [SerializeField] private TextMeshProUGUI countText = null;
    private int indice = -1;
    public UIItemSlots(int ind,ItemInventaire item = null)
    {
        ItemInv = item;
        indice = ind;
    }
    public UIItemSlots(){}

    public virtual ItemInventaire ItemInv{get{return itemInventaire;}
        set
        {
            itemInventaire = value;
            if(itemInventaire != null)
            {
                itemInventaire.NumeroPosInventaire = indice;
                iconImage.texture = itemInventaire.Item.SpriteIcon.texture;
                backGround.texture = backGroundHaveItem.texture;
                countText.text = "x " + itemInventaire.NbItem.ToString();
            }
            else
            {
                iconImage.texture = nullImage.texture;
                //backGround.texture = backGroundNotHaveItem.texture;
                countText.text = "";
            }
            selected.enabled = itemInventaire != null;
        }

    }

    public int IndiceSlots
    {
        set
        {
            indice = value;
        }
    }

    public void Drag()
    {
        iconImage.texture = nullImage.texture;
        countText.text = "";
    }
    public void Drop()
    {
        
    }
}

