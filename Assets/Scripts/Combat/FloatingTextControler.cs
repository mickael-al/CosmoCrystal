using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FloatingTextControler : MonoBehaviour
{
    [SerializeField] private static FloatingText popupText = null;
    [SerializeField] private static GameObject canvas = null;

    public static void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.2f, .2f), location.position.y + Random.Range(-.2f, .2f)));

        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }
}
