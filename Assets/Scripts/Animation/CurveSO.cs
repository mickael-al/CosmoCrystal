using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Component/CurveSo", order = 1)]
[System.Serializable]
public class CurveSO : ScriptableObject
{
    public AnimationCurve animationCurve;
}
