using UnityEngine;

public class PlayerSaveManager : MonoBehaviour
{
    public I_Save[] PlayerSave
    {
        get{
            return GetComponentsInChildren<I_Save>();
        }
    }


}
