using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnPoints;

    private List<GameObject> objects;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int objectsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        this.objects = new List<GameObject>();
        this.CheckForSpawn();
    }

    public void CheckForSpawn()
    {
        this.Respawn(this.objectsToSpawn - this.objects.Count);
    }

    private void Respawn(int nb)
    {
        List<Transform> randomPoints = new List<Transform>(this.spawnPoints);
        for (int i = 0; i < nb; i++)
        {
            if(randomPoints.Count != 0)
            {
                int rand = Random.Range(0, randomPoints.Count);
                
                if (randomPoints != null && randomPoints[rand] != null)
                {
                    GameObject go;
                    go = Instantiate(this.prefab, randomPoints[rand].position, Quaternion.identity);
                    go.GetComponent<MovableObject>().spawner = this;
                    this.objects.Add(go);
                    randomPoints.RemoveAt(rand);
                }
            }   
        }
    }

    public void removeObject(GameObject go)
    {
        this.objects.Remove(go);
    }
}
