using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemEffect/HealthManaEffect", order = 1)]
public class HealthManaEffect : ItemEffect
{
    [SerializeField] private float HealthManaRegen = 0.0f;
    public override bool Effect(Character character,int nombre = -1)
    {
        GameObject prefabSpawn = Resources.Load("Item/Effect/Particle/HealMana") as GameObject;
        Instantiate(prefabSpawn,character.transform.position,Quaternion.Euler(90,0,0),character.transform);
        if(character.GetComponent<PlayerStarter>())
        {
            character.GetComponent<PlayerStarter>().HealingMana(HealthManaRegen);
        }
        return true;
    }
}
