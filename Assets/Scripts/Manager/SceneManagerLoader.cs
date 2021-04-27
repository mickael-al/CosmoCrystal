using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManagerLoader : MonoBehaviour
{
    [SerializeField] private RawImage imageTransition = null;
    [SerializeField] private GameObject loadingText = null;
    [SerializeField] private float tempsTransition = 0.5f;
    private GameObject playerObj = null;
    private GameObject cameraObj = null;
    private SceneSave sceneSave = null;
    private bool canChangeScene = true;
    private AsyncOperation _asyncOperation;

    public bool CanChangeScene
    {
        get
        {
            return canChangeScene;
        }
    }

    public void LoadSceneTransition(string sceneName, Vector3 pos, float angleY)
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        cameraObj = GameObject.FindGameObjectWithTag("PivotCamera");
        StartCoroutine(ChangeSceneTransition(sceneName, pos, angleY));
    }

    public IEnumerator TransitionFade(float time)
    {
        float elapsedTime = time;
        Color color = imageTransition.color;
        color.a = 1.0f;
        imageTransition.color = color;
        imageTransition.gameObject.SetActive(true);
        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            color.a = elapsedTime / time;
            imageTransition.color = color;
            yield return null;
        }
        imageTransition.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        sceneSave = GameObject.FindWithTag("SceneSave").GetComponent<SceneSave>();
        sceneSave.LoadAll();
    }

    private IEnumerator ChangeSceneTransition(string sceneName, Vector3 pos, float angleY)
    {
        if (canChangeScene)
        {            
            canChangeScene = false;
            sceneSave.SaveAll();
            float timer = tempsTransition;
            Color color = imageTransition.color;
            color.a = 0.0f;
            imageTransition.color = color;
            imageTransition.gameObject.SetActive(true);
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                color.a = 1 - timer / tempsTransition;
                imageTransition.color = color;
                yield return null;
            }
            playerObj.GetComponent<PlayerController>().ChangeAnimationState(false);
            playerObj.transform.position = pos;
            cameraObj.transform.position = pos;
            playerObj.transform.eulerAngles = new Vector3(playerObj.transform.eulerAngles.x, angleY, playerObj.transform.eulerAngles.z);
            cameraObj.GetComponent<PlayerCameraMouvement>().ChangeAngleY(angleY);
            loadingText.SetActive(true);
            this._asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            string chargement = "Chargement";
            timer = 0.0f;
            int countPoint = 0;
            while (!this._asyncOperation.isDone)
            {
                chargement = "Chargement";
                for(int i = 0; i <= countPoint;i++)
                {
                    chargement += ".";
                }
                timer += Time.deltaTime;
                if(timer > 0.1f)
                {
                    timer = 0.0f;
                    countPoint = ++countPoint%3;
                }
                loadingText.GetComponent<TextMeshProUGUI>().text = chargement;
                yield return null;
            }            
            loadingText.SetActive(false);
            playerObj.GetComponent<PlayerController>().ChangeAnimationState(true);
            timer = tempsTransition;
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                color.a = timer / tempsTransition;
                imageTransition.color = color;
                yield return null;
            }
            imageTransition.gameObject.SetActive(false);
            canChangeScene = true;
        }
        yield return null;
    }
}
