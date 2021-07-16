using UnityEngine;

public class ArmeModelCut : MonoBehaviour
{
    [SerializeField] private Transform endPoint = null;
    [SerializeField] private LayerMask lm = ~0;
    [SerializeField] private GameObject particle = null;
    [SerializeField] private float maxEmitRate = 1.0f;
    private RaycastHit hit;
    private float distanceModel = 0.0f;
    private ParticleSystem.EmissionModule emit;
    [SerializeField] private Character character = null;

    private void Start()
    {
        distanceModel = Vector3.Distance(endPoint.transform.position, transform.position);
        emit = particle.GetComponent<ParticleSystem>().emission;
        character = transform.root.GetComponent<Character>();
    }
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceModel, lm))
        {            
            if (hit.transform.GetComponent<Terrain>())
            {
                particle.transform.position = hit.point;
                emit.rateOverDistance = maxEmitRate;
                if (character != null)
                {
                    character.SpeedModifier = 0.5f;
                }
            }
            else if (hit.transform.GetComponent<DestructibleAbilite>())
            {
                if (character != null)
                {
                    hit.transform.GetComponent<DestructibleAbilite>().Interact(character);                    
                    character.SpeedModifier = 0.5f;
                }
            }
        }
        else
        {
            if (character != null)
            {
                character.SpeedModifier = 1;
            }
            emit.rateOverDistance = 0.0f;
        }
    }
    private void OnDestroy() {
        if (character != null)
        {
                character.SpeedModifier = 1;
        }
    }
}
