using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISave : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    private PlayerCameraMouvement cameraJoueur = null;
    private static UISave uiSave = null;
    private bool onSave;
    #region GetterSetter
        public static UISave Instance
        {
            get
            {
                return uiSave;
            }
        }
    #endregion
    void Awake()
    {
        uiSave = this;
    }

    private void Start()
    {
        cameraJoueur = GameObject.FindWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>();
        animator.gameObject.SetActive(true);
    }

    public void StartSaveMenu()
    {
        animator.SetBool("IsOpen", true);
        onSave = true;
        cameraJoueur.MouseCursorMove = onSave;
        cameraJoueur.MouseSee = onSave;
        cameraJoueur.CameraMove = !onSave;
    }

    public void EndSaveMenu()
    {
        animator.SetBool("IsOpen", false);
        onSave = false;
        cameraJoueur.MouseCursorMove = onSave;
        cameraJoueur.MouseSee = onSave;
        cameraJoueur.CameraMove = !onSave;
    }

   
}
