using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Class to make new puzzles
public class Puzzle 
{
	public GameObject fullSprite;
	public List<GameObject> puzzlePieces = new List<GameObject>();
	public List<Rigidbody2D> puzzlePiecesRBs = new List<Rigidbody2D>();

	public enum PuzzleState
	{
		NotStarted,
		Doing,
		Finished
	}
	public PuzzleState state = PuzzleState.NotStarted;

	// The current puzzle
	public static Puzzle currentPuzzle = null;

	// Class constructor
	public Puzzle()
	{
		currentPuzzle = this;
		state = PuzzleState.Doing;
	}

	// Cache all the puzzle pieces for the current puzzle
	public void CachePuzzlePieces(Transform puzzleContainer)
	{
		//Transform puzzleContainer = GameObject.FindGameObjectWithTag(_tag).transform;
		if (puzzleContainer == null) 
			Debug.Log("Can not find puzzle container. Is it attached in the inspector?");

		puzzleContainer.gameObject.SetActive(true);

		foreach(Transform piece in puzzleContainer)
		{
			if (piece.CompareTag("PuzzlePiece"))
			{
				puzzlePieces.Add(piece.gameObject);
				puzzlePiecesRBs.Add(piece.GetComponent<Rigidbody2D>());
			}
			else if (piece.CompareTag("FullPuzzlePiece"))
			{
				//cache full puzzle piece
				fullSprite = piece.gameObject;
			}
		}

		if (puzzlePieces.Count == 0) Debug.LogError("Puzzle pieces not cached");
		if (fullSprite == null) Debug.LogError("Full sprite not cached");
	}


	public void StopAllRigidbodies()
	{
		Debug.Log("stop all rigidbodies");
		foreach(Rigidbody2D piece in puzzlePiecesRBs)
		{
			piece.velocity = Vector2.zero;
			piece.isKinematic = true;
		}

		Debug.Log("Rigidbodies stopped");
	}

	// Static method to Start a puzzle
	public void StartPuzzle()
	{
		RSUtil.Instance.DelayedAction(() =>
		{
			fullSprite.gameObject.SetActive(false);

			//print("Full sprite deactivated");
			foreach (Rigidbody2D piece in puzzlePiecesRBs)
				piece.AddForce(new Vector2(Random.Range(-450.0f, 450.0f), Random.Range(-450.0f, 450.0f))); 
			

		}, 2.0f);
	}
}