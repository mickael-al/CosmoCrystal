using UnityEngine;
using TMPro;
public class UIStatPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textVie = null;
    [SerializeField] private TextMeshProUGUI textMana = null;
    private PlayerStarter ps = null;
    void Start()
    {
        ps = GameObject.FindWithTag("Player").GetComponent<PlayerStarter>();
        textVie.text = ps.Stat.Vie + "/" + ps.Stat.VieBase;
        textMana.text = ps.Stat.Mana + "/" + ps.Stat.ManaBase;
    }

    public void MajValue()
    {
        textVie.text = ps.Stat.Vie + "/" + ps.Stat.VieBase;
        textMana.text = ps.Stat.Mana + "/" + ps.Stat.ManaBase;
    }

}
