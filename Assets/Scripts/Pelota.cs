using UnityEngine;

public class Pelota : MonoBehaviour {

	//Config parameters
	[SerializeField] Paleta paleta = null;
	[SerializeField] float xPush = 2f;
	[SerializeField] float yPush = 15f;
	[SerializeField] AudioClip clip = null;
	[SerializeField] float randomFactor = 0.2f;

	Vector2 paddleToBallVector;
	bool hasStarted = false;

	//Reference to game objects
	AudioSource myAudioSource;
	Rigidbody2D myRigidbody2D;

	// Start is called before the first frame update
	void Start() {
		paddleToBallVector = transform.position - paleta.transform.position;//Distance between ball and racket position
		myRigidbody2D = GetComponent<Rigidbody2D>();
		myAudioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update() {
		if (!hasStarted) {
			LockBallToPaddle();
			LaunchOnMouseClick();
		}
	}

	//Set the ball position to the center of the racket
	private void LockBallToPaddle() {
		Vector2 posPaleta = new Vector2(paleta.transform.position.x, paleta.transform.position.y);
		transform.position = posPaleta + paddleToBallVector;
	}

	//The ball is eyected if the player use the left click, then the game begins
	private void LaunchOnMouseClick() {
		if (Input.GetMouseButtonDown(0)) {
			hasStarted = true;
			myRigidbody2D.velocity = new Vector2(xPush,yPush);
		}
	}

	//If the game began, when the ball hit something will reproduce a sound.
	private void OnCollisionEnter2D(Collision2D collision) {
		Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor)); //this is used to avoid the ball bug and keep hitting in the same line

		if (hasStarted) {
			myAudioSource.PlayOneShot(clip);
			myRigidbody2D.velocity += velocityTweak;
		}

	}
}
