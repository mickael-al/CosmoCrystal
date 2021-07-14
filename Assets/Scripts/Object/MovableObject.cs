using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour, Destroyable
{

    [SerializeField] private float maxTimeDisolve = 2.0f;
    private Material material;

    [HideInInspector] public ObjectSpawner spawner;

    private void Start()
    {
        this.material = GetComponent<MeshRenderer>().material;
    }

    public void Desintegrate()
    {
        StartCoroutine(DisolveColor());
    }

    public IEnumerator DisolveColor()
    {
        float currentTimeDisolve = 0.0f;
        while (currentTimeDisolve < 0.5f)
        {
            currentTimeDisolve += Time.deltaTime;
            yield return null;
        }
        currentTimeDisolve = 0.0f;
        while (currentTimeDisolve < this.maxTimeDisolve)
        {
            currentTimeDisolve += Time.deltaTime;
            this.material.SetFloat("Vector1_A31CC259", currentTimeDisolve/maxTimeDisolve);
            yield return null;
        }
        spawner.removeObject(gameObject);
        spawner.CheckForSpawn();
        GameObject.Destroy(gameObject);
    }
}
