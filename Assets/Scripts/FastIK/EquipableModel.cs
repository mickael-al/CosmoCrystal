using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableModel : MonoBehaviour
{
    [SerializeField] private List<GameObject> parentRig = new List<GameObject>();
    private Dictionary<EquipementObjectPlacer,GameObject> modelAdd = new Dictionary<EquipementObjectPlacer, GameObject>();

    public void ClearModel()
    {
        foreach(KeyValuePair<EquipementObjectPlacer,GameObject> eopGo in modelAdd)
        {
            Destroy(eopGo.Value);
        }
        modelAdd.Clear();
    }

    public void RemoveModel(List<EquipementObjectPlacer> eop)
    {
        foreach(EquipementObjectPlacer eo in eop)
        {
            RemoveModel(eo);
        }
    }

    public void RemoveModel(EquipementObjectPlacer eop)
    {
        GameObject go = null;
        if(modelAdd.TryGetValue(eop, out go))
        {
            Destroy(go);
            modelAdd.Remove(eop);
        }
    }

    public void AddModel(EquipementObjectPlacer eop)
    {
        if(eop != null)
        {
            if(eop.indiceBody >= parentRig.Count)
            {
                Debug.LogWarning("L'indice ne correspond pas avec le nombre de membres.");
                return;
            }
            GameObject go = Instantiate(eop.prefabPlayerEquipement,parentRig[eop.indiceBody].transform.position,Quaternion.identity,parentRig[eop.indiceBody].transform);
            go.transform.localPosition = eop.posObj;
            go.transform.localEulerAngles = eop.eulerObj;
            go.transform.localScale = eop.scaleObj;
            modelAdd.Add(eop,go);
        }
    }

    public void AddModel(List<EquipementObjectPlacer> eop)
    {
        foreach(EquipementObjectPlacer eo in eop)
        {
            AddModel(eo);
        }
    }
}
