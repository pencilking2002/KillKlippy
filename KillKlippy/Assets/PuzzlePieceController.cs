using UnityEngine;
using System.Collections;

public class PuzzlePieceController : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector3 worldPos;
	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rb.rotation = 0;
	}

	void OnMouseDown()
	{
		print("Mousedown");
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0;
		rb.MoveRotation(0);
		rb.isKinematic = true;
		offset = transform.position - Camera.main.ScreenToWorldPoint(
    		 new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
	}

	void OnMouseDrag()
	{
		//print("Mousedown");
		//print(Input.mousePosition);
		worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + offset;

		rb.MovePosition(worldPos);
	}
}
