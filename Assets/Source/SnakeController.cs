using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour 
{
	public float speed = 2;
	public bool speedDepenLength;
	private float qurentSpeed;
	public int langth = 1;
	public float offset = 1;
	public GameObject snakeBody;
	private Vector3 direction;
	private List<GameObject> bodyParts;
	private Vector3 memPos;
	// Use this for initialization
	private void Start () 
	{
		langth += GameManager.Instance.score;
		if(bodyParts == null)
		bodyParts = new List<GameObject>();
		CreateBodyPart();
	}
	// Update is called once per frame
	private void Update () 
	{

		MoveHead();
		MoveBody();
		Inputes();
	}
	private void MoveHead()
	{
		if(speedDepenLength)
		{
			qurentSpeed = speed * langth;
		}
		else
		{
			qurentSpeed = speed;
		}
		transform.position += transform.forward * qurentSpeed * Time.deltaTime;
		memPos = transform.position;
	}
	//
	private void MoveBody()
	{
		Vector3 newPosition, oldPosition;
		newPosition = transform.position;
		for(int b = 0; b < bodyParts.Count; b++)
        {
			if((bodyParts[b].transform.position - newPosition).sqrMagnitude > offset)
			{
				oldPosition = bodyParts[b].transform.position;
           		bodyParts[b].transform.position = newPosition;
				newPosition = oldPosition;
			}
			else
			{
				break;
			}
        }
	}
	//
	private void CreateBodyPart()
	{
		for(int b = 1; b <= langth; b++)
        {
			Vector3 position = transform.position;
			position.z -= b * offset;
			GameObject bodyPart = (GameObject) Instantiate(snakeBody, position, Quaternion.identity);
			bodyParts.Add(bodyPart);
			if(b == langth-1)
			{
				bodyPart.transform.localScale = Vector3.one / 1.1f;
			}
			if(b == langth)
			{
				bodyPart.transform.localScale = Vector3.one / 1.5f;
			}
		}
	}
	private void Inputes()
	{
		if(Input.GetKeyDown(KeyCode.D))
		{
			//if(Vector3.Angle(transform.forward, Vector3.right) < 180)
			transform.Rotate(Vector3.up * 90);
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			//if(Vector3.Angle(transform.forward, Vector3.right) < -180)
			transform.Rotate(Vector3.up * -90);
		}
	}
	private void OnDrawGizmos() 
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, transform.forward);
	}
	private void SnakeGrow()
	{
		langth +=1;
		GameObject bodyPart = (GameObject) Instantiate(snakeBody, transform.position, Quaternion.identity);
		bodyParts.Insert(0, bodyPart);
	}
	private void OnDestroy()
	{
		foreach (GameObject bp in bodyParts)
		{
			Destroy(bp);
		}
	}
}
