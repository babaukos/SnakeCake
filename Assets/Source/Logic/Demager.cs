using UnityEngine;

public class Demager : MonoBehaviour 
{
	public string tagActivator = "Player";
	public int value = 1;

	private void OnTriggerEnter(Collider other) 
	{
		if(other.tag == tagActivator && GameManager.Instance != null)
		{
			GameManager.Instance.life -= value;
			Destroy(other.gameObject);
		}
	}
}
