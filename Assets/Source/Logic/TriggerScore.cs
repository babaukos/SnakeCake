using UnityEngine;

public class TriggerScore : MonoBehaviour 
{
	public string tagActivator = "Player";
	public int scoreValue = 1;

	private void OnTriggerEnter(Collider other) 
	{
		if(other.tag == tagActivator && GameManager.Instance != null)
		{
			GameManager.Instance.SetscoreInc(scoreValue);
			other.SendMessage("SnakeGrow", SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}
