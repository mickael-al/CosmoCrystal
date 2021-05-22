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

    IEnumerator DispawnAddItem(Animator anim)
    {
        yield return new WaitForSeconds(tempsDispawnAddItem);
        anim.SetTrigger("exit");
        yield return new WaitForSeconds(0.25f);
        Destroy(anim.gameObject);
    }
}
