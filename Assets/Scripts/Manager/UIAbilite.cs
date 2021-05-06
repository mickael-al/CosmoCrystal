using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilite : MonoBehaviour
{
    [SerializeField] private Sprite nullImage = null;    
    [SerializeField] private Sprite[] imageAbilite = null;
    [SerializeField] private GameObject abiliteCanvas = null;
    [SerializeField] private GameObject pointeurAbility = null;
    [SerializeField] private AnimationCurve curveAlpha = null;
    [SerializeField] private AnimationCurve curveSize = null;
    [SerializeField] private float mindistanceActive = 0.0f;
    [SerializeField] private RawImage abiliteSelected = null;
    private GameObject playerObj = null;
    private GameObject cameraObj = null;
    private List<RawImage> slot = new List<RawImage>();
    private List<float> slotWeight = new List<float>();
    private List<RawImage> slotImage = new List<RawImage>();
    private bool showAbilite = false;
    private Vector2 posCursor = Vector2.zero;
     private Vector2 posGamePad = Vector2.zero;
    private Vector2 magScreen = Vector2.zero;
    private RectTransform pointeurRectTransform = null;
    private RectTransform targetPoint = null;
    private RectTransform mask = null;
    private float calcAtan = 0.0f;
    private float distanceCurve = 0.0f;
    private float distanceGamePad = 0.0f;
    private float scaleCurve = 0.0f;
    private void Start() {
               
        for(int i = 0; i < abiliteCanvas.transform.childCount;i++)
        {
            slot.Add(abiliteCanvas.transform.GetChild(i).gameObject.GetComponent<RawImage>());
            slotWeight.Add(0.0f);
            slotImage.Add(abiliteCanvas.transform.GetChild(i).GetChild(0).GetComponent<RawImage>());
        }
        playerObj = GameObject.FindGameObjectWithTag("Player");
        cameraObj = GameObject.FindGameObjectWithTag("PivotCamera");
        pointeurRectTransform = pointeurAbility.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();
        mask = pointeurAbility.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        targetPoint = pointeurAbility.transform.GetChild(0).GetComponent<RectTransform>();
        InputManager.InputJoueur.Controller.Abilite.started += ctx => StartMenuAbilite(); 
        InputManager.InputJoueur.Controller.Abilite.canceled += ctx => EndMenuAbilite();         
    }

    private void Update() {
        if(showAbilite)
        {
            magScreen.x = Screen.width/2;
            magScreen.y = Screen.height/2;
            posGamePad = Vector3.Lerp(posGamePad,InputManager.InputJoueur.Controller.CameraGamePad.ReadValue<Vector2>(),Time.deltaTime * 15.0f);
            if(posGamePad.magnitude > 0.05f)
            {
                distanceGamePad = Vector2.Distance(new Vector2(slot[0].transform.position.x-magScreen.x,slot[0].transform.position.y-magScreen.y),Vector2.zero);
                posCursor.x = posGamePad.x * distanceGamePad + magScreen.x;
                posCursor.y = posGamePad.y * distanceGamePad + magScreen.y;
            }
            else{
                posCursor = InputManager.InputJoueur.Controller.CameraMousePos.ReadValue<Vector2>();
                if(Vector2.Distance(Vector2.zero,posCursor) < 1.0f)
                {
                   posCursor=magScreen;
                }
            }
            targetPoint.position = new Vector3(posCursor.x,posCursor.y,0);
            posCursor.x-=magScreen.x;
            posCursor.y-=magScreen.y;
            calcAtan = Mathf.Atan2(posCursor.x, posCursor.y) * Mathf.Rad2Deg;
            mask.sizeDelta = new Vector2 (magScreen.magnitude*2.0f, 10);   
            mask.eulerAngles = new Vector3(0,0,-calcAtan + 270.0f);
            pointeurRectTransform.eulerAngles = new Vector3(0,0,-calcAtan + 90.0f);            
            pointeurRectTransform.position = new Vector3(magScreen.x,magScreen.y,0);
            pointeurRectTransform.sizeDelta = mask.sizeDelta;

            for(int i = 0; i < slot.Count;i++)
            {
                distanceCurve = Vector2.Distance(new Vector2(slot[i].transform.position.x-magScreen.x,slot[i].transform.position.y-magScreen.y),posCursor);
                if(distanceCurve < mindistanceActive)
                {
                    slot[i].color = new Color(slot[i].color.r,slot[i].color.g,slot[i].color.b,curveAlpha.Evaluate(distanceCurve/mindistanceActive));
                    scaleCurve = curveSize.Evaluate(distanceCurve/mindistanceActive);
                    slotImage[i].transform.localScale = new Vector3(scaleCurve,scaleCurve,scaleCurve);
                    slotWeight[i] = 1-(distanceCurve/mindistanceActive);
                }
                else
                {
                    slot[i].color = new Color(slot[i].color.r,slot[i].color.g,slot[i].color.b,curveAlpha.Evaluate(1.0f));
                    scaleCurve = curveSize.Evaluate(1.0f);
                    slotImage[i].transform.localScale = new Vector3(scaleCurve,scaleCurve,scaleCurve);
                    slotWeight[i] = 0.0f;
                }
            }
        }
    }

    public void StartMenuAbilite()
    {
        if(playerObj.GetComponent<PlayerController>().IsInteract|| playerObj.GetComponent<PlayerInteract>().isInteract) return;
        posGamePad = Vector2.zero;
        posCursor = new Vector2(Screen.width/2,Screen.height/2);
        showAbilite = true;
        playerObj.GetComponent<PlayerAbiliteControleur>().IsChoising = true;
        cameraObj.GetComponent<PlayerCameraMouvement>().MouseCursorMove = true;
        cameraObj.GetComponent<PlayerCameraMouvement>().MouseSee = true;
        cameraObj.GetComponent<PlayerCameraMouvement>().CameraMove = false;
        abiliteCanvas.SetActive(true);
        pointeurAbility.SetActive(true);
        S_PlayerAbility allAbilite = playerObj.GetComponent<PlayerAbiliteControleur>().SavePlayerAbilite;
        for(int i = 0; i < slot.Count;i++)
        {
            slotWeight[i] = 0.0f;
            if(i < allAbilite.hasAbilite.Length)
            {
                if(allAbilite.hasAbilite[i])
                {
                    slotImage[i].texture = imageAbilite[i].texture;
                }
                else
                {
                    slotImage[i].texture = nullImage.texture;
                }
            }
            else
            {
                slotImage[i].texture = nullImage.texture;
            }
        }
    }

    public void EndMenuAbilite()
    {
        if(!playerObj.GetComponent<PlayerAbiliteControleur>().IsChoising) return;        
        abiliteCanvas.SetActive(false);
        pointeurAbility.SetActive(false);
        cameraObj.GetComponent<PlayerCameraMouvement>().CameraMove = true;
        cameraObj.GetComponent<PlayerCameraMouvement>().MouseCursorMove = false;
        cameraObj.GetComponent<PlayerCameraMouvement>().MouseSee = false;
        playerObj.GetComponent<PlayerAbiliteControleur>().IsChoising = false;
        showAbilite = false;
        float calcWeight = 0.3f;
        int choix = -1;
        for(int i = 0; i < slot.Count;i++)
        {
            if(slotWeight[i] > calcWeight)
            {
                calcWeight = slotWeight[i]; 
                choix = i;
            }
        }
        if(choix >= 0)
        {
            abiliteSelected.texture = choix < imageAbilite.Length ? imageAbilite[choix].texture : nullImage.texture;
            abiliteSelected.transform.parent.GetComponent<Animator>().SetTrigger("new");
            playerObj.GetComponent<PlayerAbiliteControleur>().ChangeAbilite(choix);
        }
    }
}
