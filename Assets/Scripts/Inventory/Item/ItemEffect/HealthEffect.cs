using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemEffect/HealthEffect", order = 1)]
public class HealthEffect : ItemEffect
{
    [SerializeField] private float HealthRegen = 0.0f;
    public override bool Effect(Character character)
    {
        //Debug.Log("HealthRegen de " + HealthRegen + " sur " + character);
        GameObject prefabSpawn = Resources.Load("Item/Effect/Particle/Heal") as GameObject;
        Instantiate(prefabSpawn,character.transform.position,Quaternion.Euler(90,0,0),character.transform);
        if(character.GetComponent<PlayerStarter>())
        {
            character.GetComponent<PlayerStarter>().Healing(HealthRegen);
        }
        return true;
    }
}
