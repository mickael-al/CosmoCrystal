using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDropRareteEffect
{
    public float thickness = 0.0f;
    [ColorUsage(true, true)] public Color HdrColor;
    [ColorUsage(true, true)] public Color HdrColorText;
    public float shine = 0.0f;
}

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private Item item = null;
    [SerializeField] private int nbItem = 1;
    [SerializeField] private SpriteRenderer spriteRender = null;
    [SerializeField] private ItemDropRareteEffect[] itemDropRareteEffect = null;
    [Header("Recuperation")]
    [SerializeField] private Rigidbody rb = null;
    [SerializeField] private Collider coll = null;
    [SerializeField] private SpriteRenderer ombreRender = null;
    [SerializeField] private float speedRcup = 1.0f;
    private bool blockRecup = false;

    #region  GetterSetter
    public Item Item
    {
        set
        {
            item = value;
            spriteRender.sprite = item.SpriteIcon;
            spriteRender.material.SetFloat("_OutlineThickness", itemDropRareteEffect[(int)item.ItemRarete].thickness);
            spriteRender.material.SetVector("_OutlineColor", (Vector4)itemDropRareteEffect[(int)item.ItemRarete].HdrColor);
            spriteRender.material.SetFloat("_Shine", itemDropRareteEffect[(int)item.ItemRarete].shine);
            rb.mass = item.Mass;
        }
    }
    public int NbItem
    {
        set
        {
            nbItem = Mathf.Clamp(value, 0, item != null ? item.MaxStack : 0);
        }
    }
    #endregion

    private void Awake()
    {
        Item = item;
    }

    private void OnTriggerEnter(Collider other)
    {
        Inventaire inventaire = other.GetComponent<Inventaire>();
        if (inventaire != null && !blockRecup && item != null)
        {
            StartCoroutine(takeItem(inventaire));
        }
    }

    public void Desintegrate()//detruit par un traps 
    {
        Destroy(gameObject);
    }

    public IEnumerator blockRecupWait(float temps)
    {
        blockRecup = true;
        yield return new WaitForSeconds(temps);
        blockRecup = false;
    }

    IEnumerator takeItem(Inventaire inventaire)
    {
        blockRecup = true;
        float timer = speedRcup;
        int reste = 0;
        Vector3 baseScale = transform.localScale;
        Vector3 calcScale = baseScale;
        Vector3 startPos = transform.position;
        rb.isKinematic = true;
        coll.enabled = false;
        ombreRender.enabled = false;
        while (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            calcScale.x = baseScale.x * timer / speedRcup + 0.01f;
            calcScale.y = baseScale.y * timer / speedRcup + 0.01f;
            calcScale.z = baseScale.z * timer / speedRcup + 0.01f;
            transform.localScale = calcScale;
            transform.position = Vector3.Lerp(startPos, inventaire.transform.position, Vector3.Distance(startPos, inventaire.transform.position) * (1 - (timer / speedRcup)));
            yield return null;
        }
        if (inventaire.AddItem(item, nbItem, out reste))
        {
            Destroy(gameObject);
        }
        else
        {
            nbItem = reste;
            while (Vector3.Distance(transform.position, inventaire.transform.position) < 2.0f) { yield return null; }
            timer = 0.01f;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                transform.position = hit.point;
            }
            while (timer < speedRcup)
            {
                timer += Time.deltaTime;
                calcScale.x = baseScale.x * timer / speedRcup;
                calcScale.y = baseScale.y * timer / speedRcup;
                calcScale.z = baseScale.z * timer / speedRcup;
                transform.localScale = calcScale;
                yield return null;
            }
            rb.isKinematic = false;
            coll.enabled = true;
            ombreRender.enabled = true;
        }
        blockRecup = false;
    }
}
