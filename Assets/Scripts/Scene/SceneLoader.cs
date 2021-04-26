using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [Header("Next Scene")]

    [SerializeField] private string nextSceneName = "";
    [SerializeField] private Vector3 nextPosition = Vector3.zero;
    [SerializeField] private float nextAngleY = 0.0f;
    [SerializeField] private SceneManagerLoader sceneManager = null;
    private Collider colliderTrigger = null;
    private void Start() 
    {
        sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManagerLoader>();
        colliderTrigger = gameObject.GetComponent<Collider>();
        if(colliderTrigger == null || sceneManager == null)
        {
            Destroy(gameObject);
            return;
        }
        StartCoroutine(ColliderCanActive());
    }

    IEnumerator ColliderCanActive()
    {
        colliderTrigger.isTrigger = false;
        while(!sceneManager.CanChangeScene)
        {
            yield return null;
        }
        colliderTrigger.isTrigger = true;
        yield return null;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            sceneManager.LoadSceneTransition(nextSceneName,nextPosition,nextAngleY);
        }
    }


}
