using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
	public bool firstCardInTurn;
	public int score;
	public string scoreString;
	public string[] newTrackableName = new string[] {""};
	public string[] prevTrackableName =  new string[] {""};
	public Text scoreText;

	// Use this for initialization
	void Start () {
		firstCardInTurn = true;
		score = 0;
		scoreString = "";
		scoreText = GetComponent<Text>();
		scoreText.text = "Score: 0 out of 3";
	}

	public void updateScore(string trackableName) {
		Debug.Log("First card in turn? " + firstCardInTurn);
		Debug.Log("GameLogic received " + trackableName);
		if (firstCardInTurn) {
			newTrackableName = trackableName.Split(new char[] {'_'});
			firstCardInTurn = false;
		} else {
			prevTrackableName = newTrackableName;
			newTrackableName = trackableName.Split(new char[] {'_'});
			if (newTrackableName[0] == prevTrackableName[0] && score < 3) {
				score = score + 1;
			}
			firstCardInTurn = true;
			scoreString = score.ToString();
			if (score == 3)
				scoreText.text = "You won!";
			else
				scoreText.text = "Score: " + scoreString + " out of 3";
		}
	}
}
