using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorStuff : EditorWindow 
{
    float valueRespawnChange = 1.0f;

    [MenuItem("Window/CarteEditStuff")]
	public static void ShowWindow ()
	{
		GetWindow<EditorStuff>("Carte Editeur");
	}

	void OnGUI ()
	{
		GUILayout.Label("Edit Carte", EditorStyles.boldLabel);

        valueRespawnChange = EditorGUILayout.FloatField("dist to ground:", valueRespawnChange);

		if (GUILayout.Button("Respawn box Change dist to ground"))
		{
			SetupRespawnChange(valueRespawnChange);
		}
	}

    public void SetupRespawnChange(float dist)
    {
        foreach(ChangeRespawnPoint crp in GameObject.FindObjectsOfType<ChangeRespawnPoint>())
        {
            RaycastHit hit;
            if (Physics.Raycast(crp.transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                crp.transform.position = new Vector3(0,dist,0) + hit.point;
            }            
        }
        Debug.Log("Terminer");
    }
}
