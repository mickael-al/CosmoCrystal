using System.Collections.Generic;
using UnityEngine;

public class RagDollFocus : MonoBehaviour
{
    [SerializeField] private List<RagDoll> ragDollList = null;
    public void ActiveAllRagDoll(int state)
    {
        foreach(RagDoll rd in ragDollList)
        {
            rd.ActiveRagDoll(state == 0);
        }
    }
}
