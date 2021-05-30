using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> rbList = null;    
    [SerializeField] private bool active = false;
    private void Awake() {
        ActiveRagDoll(active);
    }

    public void ActiveRagDoll(bool state)
    {
        foreach(Rigidbody rb in rbList)
        {
            rb.isKinematic = state;
        }
    }
}
