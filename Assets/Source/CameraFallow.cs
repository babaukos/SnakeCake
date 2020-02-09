using UnityEngine;

public class CameraFallow : MonoBehaviour 
{
	public string tagFollowObject = "Player";
	public float smouthin;
	private Transform target;

	private void LateUpdate () 
	{
		if(GameManager.Instance.pause == false)
		{
			if(target == null)
				target = GameObject.FindWithTag(tagFollowObject).transform;
			
			if(target != null)
				transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), smouthin * Time.deltaTime);
		}
	}
}
