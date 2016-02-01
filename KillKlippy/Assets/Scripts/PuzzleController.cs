using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PuzzleController : MonoBehaviour {

	public static PuzzleController Instance;

	[HideInInspector] public List<Puzzle> Puzzles = new List<Puzzle>();
	[HideInInspector] public Dialogue dialogue;

	public float explosionForce = 1000.0f;
	public List<Transform> PuzzleContainers = new List<Transform>();

	private void Start ()
	{
		if (Instance == null) Instance = this;
		else Destroy(Instance);

		dialogue = GameObject.FindObjectOfType<Dialogue>();
	}

	// Start a new puzzle
	public void StartNewPuzzle()
	{
		if (Puzzle.currentPuzzle == null)
		{
			// Initialize a new puzzle and add it to the Puzzle list
			Puzzles.Add(new Puzzle());

			// Get a puzzle container
			Transform puzzleContainer = PuzzleContainers[Puzzles.Count - 1];
			Puzzle.currentPuzzle.CachePuzzlePieces(puzzleContainer);

			// Start the current puzzle
			Puzzle.currentPuzzle.StartPuzzle();
		}
	}
}
