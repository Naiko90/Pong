using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pong : MonoBehaviour {

    private bool isPlaying;
    // Reference to the ball
    public GameObject ball;
    // Reference to the status panel
    public GameObject status;
    // Player 1 & 2
    public GameObject player1;
    public GameObject player2;
    // Racket 1 & 2
    public GameObject racket1;
    public GameObject racket2;
    // Beginning
    private bool isBeginning;

    void Start()
    {
        isPlaying = false;
        isBeginning = true;
    }

    void FixedUpdate()
    {
        if (!isPlaying && Input.GetKeyDown(KeyCode.Return))
        {
            // Disable message
            status.GetComponent<Text>().enabled = false;
            // Make the ball move
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(1, (Random.Range(-0.5f, 0.5f))).normalized * ball.GetComponent<Ball>().speed;
            // Playing
            ball.GetComponent<Ball>().isPlaying = true;
            racket1.GetComponent<Racket>().isPlaying = true;
            racket2.GetComponent<Racket_Enemy>().isPlaying = true;
            isPlaying = true;
        }
    }

    public void Winner(string name)
    {
        // If the user wins,...
        if (name.CompareTo("Player1") == 0)
        {
            ActivatePong("You win!\nPress return to start a new game");
        }
        else // If the user loses...
        {
            ActivatePong("You lose!\nPress return to start a new game");
        }
    }

    public void ActivatePong(string message)
    {
        if (isBeginning)
        {
            GameObject.FindGameObjectWithTag("PongCanvas").GetComponent<Canvas>().enabled = true;
            isBeginning = false;
        }

        // Show a message
        status.GetComponent<Text>().enabled = true;
        status.GetComponent<Text>().text = message;
        // User is not playing
        ball.GetComponent<Ball>().isPlaying = false;
        racket1.GetComponent<Racket>().isPlaying = false;
        racket2.GetComponent<Racket_Enemy>().isPlaying = false;
        isPlaying = false;
        // Reset scores
        player1.SendMessage("ResetScore", SendMessageOptions.DontRequireReceiver);
        player2.SendMessage("ResetScore", SendMessageOptions.DontRequireReceiver);
        // Reset rackets position
        racket1.SendMessage("ResetPosition", SendMessageOptions.DontRequireReceiver);
        racket2.SendMessage("ResetPosition", SendMessageOptions.DontRequireReceiver);
    }
}
