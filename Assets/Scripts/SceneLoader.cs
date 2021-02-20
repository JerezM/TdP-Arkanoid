using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    //Load the next scene
	public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    //Begins a new game, and reset the score of the game.
    public void ResetGame() {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().DestroyGS();
    }

    //Exit of the game
    public void QuitGame() {
        Application.Quit();
    }

    //Load the start scene
    public void LoadStartScene() {
        SceneManager.LoadScene(0);
    }

    //Load the "Player wins" scene
    public void LoadWinGame() {
        SceneManager.LoadScene("Win Game");
    }
}
