using UnityEngine;

[System.Serializable]
public class PlayerPosAngleSave : MonoBehaviour, I_Save
{
    [SerializeField] private Vector3 positionPlayer = Vector3.zero;
    [SerializeField] private float angleYPlayer = 0.0f;
    #region GetterSetter
    public Vector3 LastPos
    {
        get
        {
            return positionPlayer;
        }
        set
        {
            positionPlayer = value;
        }
    }
    public float LastAngle
    {
        get
        {
            return angleYPlayer;
        }
        set
        {
            angleYPlayer = value;
        }
    }
    #endregion
    public void Save(string s)
    {
        JSONArchiver.SaveJSONsFile(JSONArchiver.JSONPath, s, JsonUtility.ToJson(this));
    }
    public void Load(string s)
    {
        bool state = false;
        JsonUtility.FromJsonOverwrite(JSONArchiver.LoadJsonsFile(JSONArchiver.JSONPath,s,out state),this);
        if(!state)
        {
            positionPlayer = Vector3.zero;
            angleYPlayer = 0.0f;
        }
    }
}
