using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour, Destroyable
{

    private float maxTimeDisolve;
    private Material material;

    [HideInInspector] public ObjectSpawner spawner;

    private void Start()
    {
        this.maxTimeDisolve = 1.0f;
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
            this.material.SetFloat("Vector1_A31CC259", currentTimeDisolve);
            yield return null;
        }
        spawner.removeObject(gameObject);
        spawner.CheckForSpawn();
        GameObject.Destroy(gameObject);
    }
}
