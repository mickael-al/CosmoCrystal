using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private TextMeshProUGUI damageText = null;

    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Debug.Log(clipInfo.Length);
        Destroy(gameObject, clipInfo[0].clip.length);
    }

    public void SetText(string text)
    {
        damageText.text = text;
    }
}
