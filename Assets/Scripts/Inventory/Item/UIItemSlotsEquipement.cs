using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemSlotsEquipement : UIItemSlots
{
    [SerializeField] private Equipable.EquipementType typeEquipement = Equipable.EquipementType.Arme;

    #region GetterSetter
    public Equipable.EquipementType TypeEquipement { get { return typeEquipement; } }
    #endregion
    public override ItemInventaire ItemInv
    {
        get { return itemInventaire; }
        set
        {
            itemInventaire = value;
            if (itemInventaire != null)
            {
                iconImage.material = new Material(shader);
                iconImage.texture = itemInventaire.Item.SpriteIcon.texture;
                backGround.texture = backGroundHaveItem.texture;
                iconImage.material.SetFloat("_Shine", uIInventaire.Idre[(int)itemInventaire.Item.ItemRarete].shine);
                iconImage.material.SetColor("_OutlineColor", (Vector4)uIInventaire.Idre[(int)itemInventaire.Item.ItemRarete].HdrColor);
                countText.text = "";
                if (itemInventaire.Item is Equipable)
                {
                    foreach (BonusMalus bm in ((Equipable)itemInventaire.Item).BonusMalusStat)
                    {
                        countText.text += "[" + bm.statTypes.ToString() + ":" + bm.statModifier.ToString() + "]\n";
                    }
                }
            }
            else
            {
                iconImage.texture = nullImage.texture;
                countText.text = "";
            }
        }

    }
    public override void Drag() { }
    public override void Drop()
    {
        if (uIInventaire != null)
        {
            uIInventaire.Equip(this);
        }
    }

    public override void menuContextuel()
    {
        if (ItemInv != null)
        {
            ItemInv.EquipementID = -1;
            if (ItemInv.Item is Equipable)
            {
                uIInventaire.PlayerObj.GetComponent<PlayerEquipableModel>().RemoveModel(((Equipable)ItemInv.Item).PlayerEquipement);
            }
            uIInventaire.HideInfoBox();
            uIInventaire.PlayerObj.GetComponent<PlayerInventaire>().majStatBonusEquipement();
            ItemInv = null;
        }
    }
}
