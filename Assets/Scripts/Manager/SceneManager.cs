using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private SceneSave sceneSave = null;

    private void Awake() {
        sceneSave = GameObject.FindWithTag("SceneSave").GetComponent<SceneSave>();
    }
    private void Start() {
        sceneSave.LoadAll();
    }
}
