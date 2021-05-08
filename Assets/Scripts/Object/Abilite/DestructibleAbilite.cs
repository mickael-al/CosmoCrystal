using UnityEngine;
public class DestructibleAbilite : MonoBehaviour, InteractableAbilite
{
    [SerializeField] private GameObject prefabParticle = null;
    [SerializeField] private Vector3 offsetVec3 = Vector3.zero;
    public void Interact(Character owner)
    {
        Destroy(Instantiate(prefabParticle,transform.position+offsetVec3,Quaternion.identity),5.0f);
        Destroy(gameObject);
    }
}
