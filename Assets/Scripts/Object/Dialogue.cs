using UnityEngine;

[System.Serializable]
public class Dialogue {

	[SerializeField] private string nameCharacter = "";
	[TextArea(3, 10)] [SerializeField] private string[] sentences = null;

	public string Name
	{
		get{
			return nameCharacter;
		}
	}

	public string[] Sentences
	{
		get{
			return sentences;
		}
	}
}
