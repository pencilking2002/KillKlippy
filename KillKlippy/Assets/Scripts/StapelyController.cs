using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StapelyController : MonoBehaviour {
	
	public Sprite happySprite;
	public Sprite neutralSprite;
	public Sprite angrySprite;
	public Sprite flamingMad;

	public enum StapelyMood 
	{
		Happy,
		Neutral,
		Sad,
		Angry,
		FlamingMad
	}

	private Dictionary<StapelyMood, Sprite> moodDict = new Dictionary<StapelyMood, Sprite>();
	private SpriteRenderer sr;

	private void Awake ()
	{
		moodDict.Add(StapelyMood.Happy, happySprite);
		moodDict.Add(StapelyMood.Neutral, neutralSprite);
		moodDict.Add(StapelyMood.Angry, angrySprite);
		moodDict.Add(StapelyMood.FlamingMad, flamingMad);

		sr = GetComponent<SpriteRenderer>();
	}

	public void ChangeSprite(StapelyMood mood)
	{
		sr.sprite = moodDict[mood];
	}
}