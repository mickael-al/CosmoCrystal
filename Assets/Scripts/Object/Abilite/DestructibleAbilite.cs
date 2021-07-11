using System.Collections.Generic;
using UnityEngine;
public class DestructibleAbilite : MonoBehaviour, InteractableAbilite
{
    [SerializeField] private GameObject prefabParticle = null;
    [SerializeField] private Vector3 offsetVec3 = Vector3.zero;
    [SerializeField] private List<ItemSpawnPourcentage> itemsSpawn = new List<ItemSpawnPourcentage>();
    public void Interact(Character owner)
    {
        foreach(ItemSpawnPourcentage isp in itemsSpawn)
        {
            isp.Spawn(transform.position+offsetVec3,Quaternion.identity);
        }
        Destroy(Instantiate(prefabParticle,transform.position+offsetVec3,Quaternion.identity),5.0f);
        Destroy(gameObject);
    }
}
