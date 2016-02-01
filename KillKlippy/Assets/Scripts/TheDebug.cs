using UnityEngine;
using System.Collections;

public class TheDebug : MonoBehaviour {

	public bool isDebug = true;

	private void OnGUI ()
	{
		if (!isDebug)
			return;

		GUI.Button(new Rect(10,10, 120, 20), "Current puzzle:  " + PuzzleController.Instance.Puzzles.Count);
		GUI.Button(new Rect(10,30, 120, 20), "Current node:  " + PuzzleController.Instance.dialogue.currentNodeID);

		if (Puzzle.currentPuzzle != null)
		{
			GUI.Button(new Rect(10,60, 120, 20), "Current node:  " + Puzzle.currentPuzzle.state);
		}
	}
}
