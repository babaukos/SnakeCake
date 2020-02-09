using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour 
{
	public Transform target;
	public float distanceToTarget = 10.0f;
    public float speedRotation = 5;
    public float hightOverTarget = 20;
    private Quaternion rotation;
	private Vector3 position;

    float x, y, InputX, InputY;
    //------------------------------------

	// Use this for initialization
	private void Start () 
	{
	   	 if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	 }
	// Update is called once per frame
    private void LateUpdate() 
	{
	      if (target) 
		  {
             x += speedRotation * Time.deltaTime;
             rotation = Quaternion.Euler(hightOverTarget, x, 0.0f);
             position = rotation * new Vector3(0.0f, 0.0f, -distanceToTarget) + target.position;
		        
		     transform.rotation = rotation;
		     transform.position = position;
             transform.LookAt(target.position);
         }
	}
	//
    private float ClampAngle(float angle, float min, float max) 
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
