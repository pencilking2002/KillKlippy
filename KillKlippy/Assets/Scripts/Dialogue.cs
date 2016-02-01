using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour 
{
	[HideInInspector] 
	public int currentNodeID = 0;

	public RectTransform stapelyTextPanel;
	public Text stapelyText;

	public Button yesBTN;
	public Button noBTN;

	public RectTransform yesBTN_RT;
	public RectTransform noBTN_RT;

	private Vector2 default_YesBTN_Pos;
	private Vector2 default_NoBTN_Pos;

	public DialogueNode[] Nodes;
	private DialogueNode currentNode = null;			// What is the current node?


	private float clickedTime;
	private float clickTimeBuffer = 1.0f;

	private void Start ()
	{
		SetDefaultButtonPositions();

		// Hide buttons
		DisplayButtons(false);

		// Load the panel with the node text
		NextNode(currentNodeID);

		// Tween in the dialogue window
		DisplayDialoguePanel(true);
	}

	private void Update ()
	{
		// If current node is waiting for a click, move to the next node
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
		{
			ClickNextNode();
		}
	}

	private void SetDefaultButtonPositions()
	{
		yesBTN_RT = yesBTN.GetComponent<RectTransform>();
		noBTN_RT = noBTN.GetComponent<RectTransform>();

		default_YesBTN_Pos = yesBTN_RT.anchoredPosition;
		default_NoBTN_Pos = noBTN_RT.anchoredPosition;
	}

	private void ResetButtonPositions()
	{
		yesBTN_RT.anchoredPosition = default_YesBTN_Pos;
		noBTN_RT.anchoredPosition = default_NoBTN_Pos;
	}

	public void Answer(int buttonID)
	{
		print("Button id" + buttonID);
		switch (buttonID)
		{
			case 1:
				print("clicked yes button");
				currentNodeID = currentNode.yesDestinationNode;
				NextNode(currentNodeID);
				break;
			case 0:
				currentNodeID = currentNode.noDestinationNode;
				NextNode(currentNodeID);
				break;
			default:
				Debug.LogError("Unrecognized button id: " + buttonID);
				break;
		}
	}

	// Record the current node

	// Wait for user answer, it can be 1 = true, 0 = false. Next is an automatic true
	// This is a method that would get called by one fo the buttons

	// When user answers, take them to the next dialogue node
	// Check if its an exit node or not, if it is print it out for now 

	private void DisplayButtons(bool display)
	{
		yesBTN.gameObject.SetActive(display);
		noBTN.gameObject.SetActive(display);
	}

	private void DisplayDialoguePanel(bool display)
	{
		if (display)
		{
			LeanTween.scale(stapelyTextPanel, Vector3.one, 1f)
				.setFrom(Vector3.zero)
				.setEase(LeanTweenType.easeInOutExpo);
		}
		else
		{
			LeanTween.scale(stapelyTextPanel, Vector3.zero, 1f)
				.setFrom(Vector3.one)
				.setEase(LeanTweenType.easeInOutExpo);
		}
	}

	/// <summary>
	/// Display the next node and cache it as the current node
	/// Display any buttons that are supposed to be visible 
	/// </summary>
	private void NextNode(int nodeID)
	{
		// Reset the current node and hide buttons
		currentNode = null;
		ResetButtonPositions();
		DisplayButtons(false);

		// Search for a node with the specified node ID
		currentNode = FindNode(nodeID);

		if (currentNode == null)
		{
			Debug.LogError("Cant find node with id: " + nodeID + ". Check if any nodes have that ID.");
			return; 
		}		
		stapelyText.text = currentNode.text;

		// Display buttons
		if (currentNode.yesButton)
		{ 
			yesBTN.gameObject.SetActive(true);
			if (!currentNode.noButtonn)
			{
				yesBTN_RT.anchoredPosition = new Vector2(0, default_YesBTN_Pos.y);
				print("center yes button");
			}
		}
		if (currentNode.noButtonn)
		{ 
			noBTN.gameObject.SetActive(true);
			if (!currentNode.yesButton)
			{
				noBTN_RT.anchoredPosition = new Vector2(0,default_NoBTN_Pos.y);
			}
		}
	}

	private void ClickNextNode()
	{
		if (currentNode.clickTriggerPuzzle)
		{
			print("Play puzzle");
			PuzzleController.Instance.StartNewPuzzle();
		}

		if (currentNode.clickToGoToNextNode /* || OneButtonVisible() */ /*&& Time.time > clickedTime + clickTimeBuffer*/)
		{
			currentNodeID = currentNode.nodeID + 1;
			NextNode(currentNodeID);
			clickedTime = Time.time;
		}


	}

	// Check if only one button is visible
	private bool OneButtonVisible()
	{
		int numButtons = 0;

		if (currentNode.yesButton)
			numButtons++;

		if (currentNode.noButtonn)
			numButtons++;

			return numButtons == 1 ? true : false;
	}

	private DialogueNode FindNode(int id)
	{
		foreach (DialogueNode node in Nodes)
		{
			if (node.nodeID == id)
			{
				return node;
			}
		}

		return currentNode;

	}

}

[System.Serializable]
public class DialogueNode : System.Object
{
	public string name;

	[TextArea(3,10)]
	public string text;
	public int nodeID;

	public bool yesButton;
	public int yesDestinationNode;

	public bool noButtonn;
	public int noDestinationNode;

	public bool clickToGoToNextNode = false;
	public bool clickTriggerPuzzle = false;
	public int puzzleNumber = -1;
	public bool exitNode = false;

	//public Answer answer;
}
