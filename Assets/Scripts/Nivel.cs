using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel : MonoBehaviour
{
    [SerializeField] int currentBlocks = 0;

    SceneLoader sceneLoader;
    GameStatus gameStatus;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    //Increse the number of blocks in the current level.
    public void UpdateBlocks()
    {
        currentBlocks++;
    }

    //Decrease the number of blocks in the current level. 
    //If it is no more blocks to destroy, the next scene will be loaded, 
    //or the game will end(depends on wich level the player is playing).
    public void DestroyBlockFromLevel() {
        currentBlocks--;
        if (currentBlocks <= 0) {

            if (tag == "LastLevel") {
                sceneLoader.LoadWinGame();
                gameStatus.GameOver();
            } else {
                sceneLoader.LoadNextScene();
                gameStatus.UpdateLevel();
            }
            
        }
    }
}
