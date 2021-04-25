using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [Header("Next Scene")]
    [SerializeField] private Vector3 nextPosition = Vector3.zero;
    [SerializeField] private float nextAngleY = 0.0f;
    [SerializeField] private SceneManager sceneManager = null;
    private void Start() {
        sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            Debug.Log("Change Scene");
        }
    }


}
