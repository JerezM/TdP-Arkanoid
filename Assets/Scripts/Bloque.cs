using UnityEngine;

public class Bloque : MonoBehaviour {

    [SerializeField] Sprite[] hitSprites; //Contendra los sprites de los bloques con diferentes daños
    [SerializeField] int points = 10;//Will contain the sprites of the blocks with different damages

    Nivel nivel = null;

    int timesHitted = 0;

    private void Start() {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks() {
        nivel = FindObjectOfType<Nivel>();
        if (tag == "Breakable")
        {
            nivel.UpdateBlocks();//Will increase the number of blocks in the current level
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable")
        {
            GetHit();
        }
    }

    
    //Destroy the game object, and add the points to the game score
    private void DestroyBlock() {
        Destroy(gameObject); 
        nivel.DestroyBlockFromLevel();
        FindObjectOfType<GameStatus>().AddToScore(points);
    }

    private void GetHit() {
        timesHitted++;
        int maxHits = hitSprites.Length + 1;

        if (timesHitted >= maxHits) {
            DestroyBlock();
            points = 10;
        } else {
            ChangeSprite();
            points += 5;
        }
    }

    private void ChangeSprite() {
        int spriteIndex = timesHitted - 1;
        if (hitSprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Array index out of bounds");
        }
    }
}
