using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterupteurTrigger : Switch, InteractableAbilite
{
    [Header("Color")]
    [ColorUsage(false, true)] [SerializeField] private Color baseColor = Color.white;
    [ColorUsage(false, true)] [SerializeField] private Color activeColor = Color.white;  
    [SerializeField] private GameObject pointLight = null;
    [SerializeField] private MeshRenderer meshRenderer = null;
    private Material mat = null;

    protected override void Start()
    {
        base.Start();
        mat = meshRenderer.material;
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", base.switchState.state ? activeColor : baseColor);
        pointLight.SetActive(base.switchState.state);
    }

    public void Interact(Character owner)
    {
        base.setState(!base.switchState.state);
        mat.SetColor("_EmissionColor", base.switchState.state ? activeColor : baseColor);
        pointLight.SetActive(base.switchState.state);
    }
}
