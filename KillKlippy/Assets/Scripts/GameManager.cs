using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private Puzzle puzzle1;
	public Transform explosionPos;
	public float explosionForce = 1000.0f;

	private void Start ()
	{
		puzzle1 = new Puzzle();
		GameObject[] puzzlePieces = GameObject.FindGameObjectsWithTag("Puzzle1");

		foreach(GameObject piece in puzzlePieces)
		{
			puzzle1.puzzlePieces.Add(piece);
			print("Got puzzle piece");
		}

		puzzle1.fullSprite = GameObject.FindGameObjectWithTag("FullPuzzlePiece1");
		//explosionPos = puzzle1.fullSprite.transform.position;

		RSUtil.Instance.DelayedAction(() =>
		{
			puzzle1.fullSprite.gameObject.SetActive(false);
			//print("Full sprite deactivated");
			foreach (GameObject piece in puzzle1.puzzlePieces)
			{
				//piece.GetComponent<Rigidbody2D>().AddExplosionForce(explosionForce, 
						//new Vector2(piece.transform.position.x + 10.0f, piece.transform.position.y + 10.0f), 50.0f);
				//piece.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 100));
					piece.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-450.0f, 450.0f), Random.Range(-450.0f, 450.0f))); 
			}
		}, 2.0f);
			
	}

}

public class Puzzle 
{
	public GameObject fullSprite;
	public List<GameObject> puzzlePieces = new List<GameObject>();
}


public static class Rigidbody2DExt {

    public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force) {
        var explosionDir = rb.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;

        // Normalize without computing magnitude again
        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else {
            // From Rigidbody.AddExplosionForce doc:
            // If you pass a non-zero value for the upwardsModifier parameter, the direction
            // will be modified by subtracting that value from the Y component of the centre point.
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }

        rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
    }
}