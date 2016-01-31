using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[HideInInspector] 
	public List<Puzzle> Puzzles = new List<Puzzle>();
	//private Puzzle currentPuzzle;

	public Transform explosionPos;
	public float explosionForce = 1000.0f;
	//public static int currentPuzzleInt = 0;

	private void Start ()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(Instance);

		// Add a new puzzle
		StartNewPuzzle("Puzzle1");
			
	}

	// Start a new puzzle
	private void StartNewPuzzle(string tag)
	{
		Puzzles.Add(new Puzzle());

		// Cache all the puzzle pieces for the current puzzle
		Puzzle.currentPuzzle.CachePuzzlePieces(GameObject.FindGameObjectsWithTag(tag));

		//Cache the full puzzle sprite
		Puzzle.currentPuzzle.fullSprite = GameObject.FindGameObjectWithTag("FullPuzzlePiece1");
		//explosionPos = puzzle1.fullSprite.transform.position;

		// Start the current puzzle
		Puzzle.StartPuzzle(Puzzle.currentPuzzle);
	}

}

public class Puzzle 
{
	public GameObject fullSprite;
	public List<GameObject> puzzlePieces = new List<GameObject>();
	public List<Rigidbody2D> puzzlePiecesRBs = new List<Rigidbody2D>();

	// The current puzzle
	public static Puzzle currentPuzzle;

	// Class constructor
	public Puzzle()
	{
		currentPuzzle = this;
	}

	// Cache all the puzzle pieces for the current puzzle
	public void CachePuzzlePieces(GameObject[] piecesArr)
	{
		foreach(GameObject piece in piecesArr)
		{
			puzzlePieces.Add(piece);
			puzzlePiecesRBs.Add(piece.GetComponent<Rigidbody2D>());
		}
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
	public static void StartPuzzle(Puzzle _puzzle)
	{
		RSUtil.Instance.DelayedAction(() =>
		{
			_puzzle.fullSprite.gameObject.SetActive(false);

			//print("Full sprite deactivated");
			foreach (GameObject piece in _puzzle.puzzlePieces)
			{
				piece.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-450.0f, 450.0f), Random.Range(-450.0f, 450.0f))); 
			}

			RSUtil.Instance.DelayedAction(() => {
				_puzzle.StopAllRigidbodies();
			}, 1.0f);
		}, 2.0f);
	}


}
