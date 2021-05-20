using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemEffect/HealthEffect", order = 1)]
public class HealthEffect : ItemEffect
{
    [SerializeField] private float HealthRegen = 0.0f;
    public override void Effect(Character character)
    {
        Debug.Log("HealthRegen de " + HealthRegen + " sur " + character);
    }
}
