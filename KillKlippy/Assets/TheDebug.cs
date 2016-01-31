using UnityEngine;
using System.Collections;

public class TheDebug : MonoBehaviour {

	public bool isDebug = true;

	private void OnGUI ()
	{
		if (!isDebug)
			return;

		GUI.Button(new Rect(10,10, 120, 20), "Current puzzle:  " + GameManager.Instance.Puzzles.Count);
	}
}
