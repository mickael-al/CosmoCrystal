using UnityEngine;

[System.Serializable]
public class ItemSpawnPourcentage
{
    public Item itemSpawn = null;
    [Range(0.0f, 100.0f)] public float pourcentage = 100.0f;
    public void Spawn(Vector3 pos,Quaternion quat)
    {
        if(Random.Range(0.0f,100.0f) < pourcentage)
        {
            GameObject go = GameObject.Instantiate(Resources.Load("Item/Prefab/itemBase") as GameObject,pos,quat);
            go.GetComponent<ItemDrop>().Item = itemSpawn;
        }
    }
}
