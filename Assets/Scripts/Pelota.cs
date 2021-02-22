using UnityEngine;

public class Pelota : MonoBehaviour {

	//Config parameters
	[SerializeField] Paleta paleta = null;
	[SerializeField] float xPush = 2f;
	[SerializeField] float yPush = 15f;
	[SerializeField] AudioClip clip = null;

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

		if (hasStarted) {
			myAudioSource.PlayOneShot(clip);

			// Hit the Racket?
			if ( collision.gameObject.name == "Paleta") {
				// Calculate hit Factor
				float x = HitFactor(transform.position, collision.transform.position,
								    collision.collider.bounds.size.x);

				// Calculate direction, set length to yPush to keep the same "speed"
				Vector2 dir = new Vector2(x, 1) * yPush;

				// Set Velocity with dir
				myRigidbody2D.velocity = dir;
			}
		}

	}

	//Calculates where the ball hits the racket
	private float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
		// ascii art:
		//
		// -1  -0.5  0  0.5   1  <- x value
		// ===================  <- racket
		//
		return (ballPos.x - racketPos.x) / racketWidth;
	}
}
