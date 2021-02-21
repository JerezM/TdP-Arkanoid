using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
	//Config parameters
	[Range(0.1f,10f)][SerializeField] float gameSpeed=1f;
	[SerializeField] TextMeshProUGUI scoreText = null;
	[SerializeField] TextMeshProUGUI levelText = null;

	int currentScore = 0;
	int currentLevel = 1;

	//Obtain the amount of instances of GameStatus(game sessions where we had the score of a certant level).
	//If we already had an instance of GameStatus then a new instance won't be created. (Singleton pattern)
	private void Awake() {
		int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

		if (gameStatusCount > 1) {
			gameObject.SetActive(false);
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
			
	}

	// Start is called before the first frame update
	private void Start() {
		scoreText.text = "Score: "+ currentScore.ToString();
		levelText.text = "Round " + currentLevel.ToString();			
	}

	// Update is called once per frame
	void Update() {
		Time.timeScale = gameSpeed;
	}

	//Add the received points by parameter to the current game score
	public void AddToScore(int points) {
		currentScore += points;
		scoreText.text = "Score: " + currentScore.ToString();
	}

	public void UpdateLevel() {
		currentLevel++;
		levelText.text = "Round " + currentLevel.ToString();
	}

	public void GameOver() {
		levelText = null;
	}

	//Destroy the instance of the class and reset the score of the game
	public void DestroyGS()
    {
		scoreText = null;
		Destroy(gameObject);

    }
}
