using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    
    // Speed to be modified in the Inspector
    public float speed = 2.0f;
    public bool isPlaying { get; set; }
    public AudioClip pongAudio;

    void Start()
    {
        // Give the ball some initial movement direction
        //rigidbody2D.velocity = Vector2.one.normalized * speed;
        //rigidbody2D.velocity = new Vector2(1, (Random.Range(-0.5f, 0.5f))).normalized * speed;
        /*switch (Random.Range(0, 1))
        {
            case 0: rigidbody2D.velocity = new Vector2(1, (Random.Range(-0.5f, 0.5f))).normalized * speed; break;
            case 1: rigidbody2D.velocity = new Vector2(-1, -(Random.Range(-0.5f, 0.5f))).normalized * speed; break;
        }*/
        isPlaying = false;
    }

    

    void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        AudioSource.PlayClipAtPoint(pongAudio, GameObject.FindGameObjectWithTag("Camera").transform.position, 1f);

        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
            float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    public void ResetBall(string name)
    {
        // Update score
        if (name.CompareTo("VerticalWallLeft") == 0)
        {
            GameObject.Find("Player2").SendMessage("SetScore", SendMessageOptions.DontRequireReceiver);
        }
        else if (name.CompareTo("VerticalWallRight") == 0)
        {
            GameObject.Find("Player1").SendMessage("SetScore", SendMessageOptions.DontRequireReceiver);
        }

        // Make the balll moves just when the user is playing
        if (isPlaying)
        {
            // Reset ball position in the center of the yard
            gameObject.transform.localPosition = new Vector3(Random.Range(-200, 200), 0, 0);
            // Give the ball some initial, random direction
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-0.5f, 0.5f), 1).normalized * speed;
            /*switch (Random.Range(0, 1))
            {
                case 0: rigidbody2D.velocity = new Vector2(1, (Random.Range(-0.5f, 0.5f))).normalized * speed; break;
                case 1: rigidbody2D.velocity = new Vector2(-1, -(Random.Range(-0.5f, 0.5f))).normalized * speed; break;
            }*/
        }
        else
        {
            // Reset ball position in the center of the yard
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
            // Reset ball velocity
            GetComponent<Rigidbody2D>().velocity = Vector2.zero.normalized;
        }
    }
}
