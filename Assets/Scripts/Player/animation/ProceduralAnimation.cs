using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralAnimation : MonoBehaviour
{
    #region Animation
    [Header("ProceduralAnimation")]
    [SerializeField] protected float stepSize = 1f;
    [SerializeField] protected int smoothness = 7;
    [SerializeField] protected int smoothnessbase = 7;
    [SerializeField] protected float stepHeight = 0.1f;
    [SerializeField] protected bool bodyOrientation = true;
    [SerializeField] protected float velocityMultiplier = 15f;
    #region GetterSetter
    public int Smoothnessbase{set{smoothness=value;}get{return smoothness;}}
    #endregion
    #endregion

    protected virtual void Start(){}
    protected virtual void FixedUpdate(){}

    protected static Vector3[] MatchToSurfaceFromAbove(Vector3 point, float halfRange, Vector3 up)
    {
        Vector3[] res = new Vector3[2];
        RaycastHit hit;
        Ray ray = new Ray(point + halfRange * up, - up);

        //Debug.DrawRay(point + halfRange * up, -up, Color.red, 2f * halfRange);

        if (Physics.Raycast(ray, out hit, 2f * halfRange))
        {
            res[0] = hit.point;
            res[1] = hit.normal;
            Debug.Log(hit.transform.name);
        }
        else
        {
            res[0] = point;
        }
        return res;
    }
}
