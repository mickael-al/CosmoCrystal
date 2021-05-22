using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
public class UIGameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOver = null;
    [SerializeField] private TextMeshProUGUI textGameOver = null;
    [SerializeField] private GameObject bouttonRetry = null;
    [SerializeField] private float transitionDuree = 2.0f;
    private PlayerController pc = null;
    private PlayerCameraMouvement pcm = null;
    private Volume volume = null;
    private FilmGrain fg = null;
    private ColorAdjustments ca = null;
    private float saturationBase = 0.0f;
    private bool isDead = false;
    private bool inRespawn = false;
    private Vector3 rp = Vector3.zero;
    private float ra = 0.0f;
    public IEnumerator DeathPlayer(Vector3 respawnPos, float respawnAngle)
    {
        if (!isDead)
        {
            rp = respawnPos;
            ra = respawnAngle;
            isDead = true;
            gameOver.SetActive(true);
            bouttonRetry.SetActive(false);
            RawImage image = gameOver.GetComponent<RawImage>();
            Color colorImage = image.color;
            Color colorText = textGameOver.color;
            float timer = transitionDuree;
            pcm = GameObject.FindGameObjectWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>();
            pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            volume = GameObject.FindGameObjectWithTag("PPV").GetComponent<Volume>();
            pcm.MouseCursorMove = true;
            pcm.MouseSee = true;
            pcm.CameraMove = false;
            pc.IsInteract = true;
            volume.profile.TryGet<FilmGrain>(out fg);
            volume.profile.TryGet<ColorAdjustments>(out ca);
            saturationBase = ca.saturation.value;
            while (timer > 0.0f)
            {
                timer -= Time.deltaTime;
                colorImage.a = 1.0f - (timer / transitionDuree);
                colorText.a = 0.5f - (timer / transitionDuree) * 1.8f;
                fg.intensity.value = 1.0f - (timer / transitionDuree);
                ca.saturation.value = ((timer / transitionDuree) * (100.0f + saturationBase)) - 100.0f;
                image.color = colorImage;
                textGameOver.color = colorText;
                yield return null;
            }
            Time.timeScale = 0.05f;
            bouttonRetry.SetActive(true);
        }
        yield return null;
    }

    public void retry()
    {
        if (isDead)
        {
            StartCoroutine(RetryWaitTransition());
        }
    }

    IEnumerator RetryWaitTransition()
    {
        if (!inRespawn)
        {
            inRespawn = true;
            Time.timeScale = 1.0f;
            SceneManagerLoader sml = GetComponent<SceneManagerLoader>();
            sml.LoadSceneTransition(SceneManager.GetActiveScene().name, rp, ra);
            yield return new WaitForSeconds(sml.TempsTransition);
            pc.GetComponent<PlayerStarter>().Respawn();
            pcm.CameraMove = true; 
            pcm.MouseCursorMove = false;
            pcm.MouseSee = false;
            bouttonRetry.SetActive(false);
            fg.intensity.value = 0.0f;
            ca.saturation.value = saturationBase;
            gameOver.SetActive(false);
            isDead = false;
            inRespawn = false;
        }
        yield return null;
    }
}
