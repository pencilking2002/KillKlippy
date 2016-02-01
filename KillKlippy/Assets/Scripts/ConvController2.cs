using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ConvController2 : MonoBehaviour 
{
//	public RectTransform stapelyTextPanel;
//	public Text stapelyText;
//	public Button yesBTN;
//	public Button noBTN;
//
//	private List<ConvNode2> nodes = new List<ConvNode2>();
//
//	private void Awake()
//	{
//		// Deactivate yes/no buttons
//		DisplayButtons(false);
//
//		/* ----------------- FIRST NODE ---------------------*/
//
//		new ConvNode2();
//		ConvNode2.currentNode.prompts.Add("Hi there! I’m Stapely - your friendly computer helper.");
//		ConvNode2.currentNode.prompts.Add("The world of computers is new and exciting, but it can also be confusing at times. Don’t worry, Stapely will help you!");
//		ConvNode2.currentNode.prompts.Add("Would you like Stapely’s help in navigating your computer? ");
//		stapelyText.text = ConvNode2.currentNode.GetPrompt();
//		DisplayPrompt(true);
//		ConvNode2.SetState(ConvState2.WaitingForNextText);
//		 	
//	}
//
//	private void Update ()
//	{
//		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
//		{
//			print("Next");
//			ConvNode2.Next(stapelyText);
//		}
//	}
//
//	private void DisplayButtons(bool display)
//	{
//		yesBTN.gameObject.SetActive(display);
//		noBTN.gameObject.SetActive(display);
//	}
//
//	private void DisplayPrompt(bool display)
//	{
//		if (display)
//		{
//			LeanTween.scale(stapelyTextPanel, Vector3.one, 1f)
//				.setFrom(Vector3.zero)
//				.setEase(LeanTweenType.easeInOutExpo);
//		}
//		else
//		{
//			LeanTween.scale(stapelyTextPanel, Vector3.zero, 1f)
//				.setFrom(Vector3.one)
//				.setEase(LeanTweenType.easeInOutExpo);
//		}
//	}
//}
//
//public enum ConvState2
//{
//	Nothing,
//	WaitingForNextText,
//	WaitingForResponce
//}
//
//public class ConvNode2 
//{
//	public List<string> prompts = new List<string>();
//	//public List<string> replies = new List<string>();
//	public int[] nodeLinks;
//
//	public static ConvNode2 currentNode;
//	public static ConvState2 currentState = ConvState2.Nothing;
//
//	public bool answer;
//	private int currentPrompt = -1;
//
//	public string GetPrompt()
//	{
//		prompts.RemoveAt(currentPrompt);
//		currentPrompt++;
//		return prompts[currentPrompt];
//	}
//
//    public static void Next(Text _stapelyText)
//    {
//    	if (currentState == ConvState2.WaitingForNextText)
//    	{
//			if (currentNode.prompts.Count > 0)
//				_stapelyText.text = currentNode.GetPrompt();
//    	}
//    	else
//    	{
//    		//NextNode();
//    	}
//    }
//
//    public static void SetState(ConvState2 _state)
//    {
//    	currentState = _state;
//    }
//
//    public ConvNode2()
//    {
//    	currentNode = this;
//    }

}