using UnityEngine;

public class SpawnPlayerPoint : MonoBehaviour 
{
	public static SpawnPlayerPoint Instace;


	private void Awake()
	{
		if(Instace == null)
		{
			Instace = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	private void OnDrawGizmos() 
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(transform.position, Vector3.up);
		Gizmos.DrawSphere(transform.position, 0.25f);
	}
}
