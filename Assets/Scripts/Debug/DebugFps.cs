using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFps : MonoBehaviour
{
[Header("Draw FPS")]
    [SerializeField] private Color textColor = new Color (0.0f, 1.0f, 0.5f, 1.0f);
    [SerializeField] private float withScreen = 0.0f, heightScreen = 0.0f, fps = 0.0f, msec = 0.0f, deltaTime = 0.0f;
	[Range(0,0.1f)] [SerializeField] private float sizeText = 0.02f;
    private string textUI = "";

	void Update()
	{
		this.deltaTime += (Time.unscaledDeltaTime - this.deltaTime) * 0.1f;
	}
 
	void OnGUI()
	{
		this.withScreen = Screen.width;
        this.heightScreen = Screen.height;
 
		GUIStyle style = new GUIStyle();
        
		Rect rect = new Rect(0, 0, this.withScreen, this.heightScreen * sizeText);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = (int)(this.heightScreen * sizeText);
		style.normal.textColor = textColor;
		this.msec = this.deltaTime * 1000.0f;
		this.fps = 1.0f / this.deltaTime;
		textUI = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(rect, textUI, style);
	}
}
