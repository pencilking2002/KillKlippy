using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PuzzleController : MonoBehaviour {

	public static PuzzleController Instance;

	[HideInInspector] 
	public List<Puzzle> Puzzles = new List<Puzzle>();
	public Dialogue dialogue;

	public float explosionForce = 1000.0f;

	private void Start ()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(Instance);

		dialogue = GameObject.FindObjectOfType<Dialogue>();
	}

	// Start a new puzzle
	public void StartNewPuzzle()
	{
		if (Puzzle.currentPuzzle == null)
		{
			// Initialize a new puzzle and add it to the Puzzle list
			Puzzles.Add(new Puzzle());

			// Create a string to represent the tag of the next Puzzle
			string tag = "Puzzle" + Puzzles.Count;
			Puzzle.currentPuzzle.CachePuzzlePieces(tag);

			// Start the current puzzle
			Puzzle.currentPuzzle.StartPuzzle();
		}
	}
}


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
	public void CachePuzzlePieces(string _tag)
	{
		Transform puzzleContainer = GameObject.FindGameObjectWithTag(_tag).transform;

		if (puzzleContainer == null) 
			Debug.Log("Can not find puzzle container with tag: " + _tag);

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
			{
				piece.AddForce(new Vector2(Random.Range(-450.0f, 450.0f), Random.Range(-450.0f, 450.0f))); 
			}

//			RSUtil.Instance.DelayedAction(() => {
//				Puzzle.currentPuzzle.StopAllRigidbodies();
//			}, 1.0f);
		}, 2.0f);
	}


}
