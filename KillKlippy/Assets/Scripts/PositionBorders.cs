using UnityEngine;
using System.Collections;

public class PositionBorders : MonoBehaviour {

//	public BoxCollider2D borderTop;
//	public BoxCollider2D borderBottom;
//	public BoxCollider2D borderLeft;
//	public BoxCollider2D borderRight;
//
//	private Vector3 screenTop;
//	private Vector3 screenBottom;
//
//	// Use this for initialization
//	void Start () {
//
//		screenTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2.0f, Screen.height, 10f));
//		screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2.0f, 0, 10f));
//
//		borderTop.transform.position = new Vector2(borderTop.transform.position.x, screenTop.y + borderTop.bounds.center.y);
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//	private void OnDrawGizmos()
//	{
//		Gizmos.color = Color.green;
//		Gizmos.DrawSphere(screenTop, 1.0f);
//		Gizmos.DrawSphere(screenBottom, 1.0f);
//	}
}
