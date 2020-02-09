using UnityEngine;

public class FoodGenerator : MonoBehaviour 
{
	public GameObject food;
	private GameObject foodMem;

	public float sizeX;
	public float sizeY;

	// Update is called once per frame
	private void Update () 
	{
		if(foodMem == null)
		{
			Vector3 pos = new Vector3(transform.position.x + Random.RandomRange(-sizeX, sizeX), transform.position.y, transform.position.z + Random.RandomRange(-sizeY, sizeY));
			foodMem = (GameObject) Instantiate(food, pos, Quaternion.identity);
		}
	}
	//
	private void OnDrawGizmos() 
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireCube(transform.position, new Vector3(sizeX * 2, 0, sizeY * 2));
	}
}
