using UnityEngine;
using System.Collections;

public class Racket_Enemy : MonoBehaviour {

    public GameObject wallTop;
    public GameObject wallBottom;
    public GameObject ball;
    private float currentBallPos;
    private bool isBeginning;
    public bool isPlaying { get; set; }

    void Start()
    {
        isBeginning = true;
    }

    void FixedUpdate()
    {
        // Without this piece of code the right racket would be in the center of the yard
        if (isBeginning)
        {
            gameObject.transform.localPosition = new Vector3(370f, 0f, 0f);
            isBeginning = false;
        }

        if (isPlaying)
        {
            // Don't make the paddle move on the x axe
            gameObject.transform.localPosition = new Vector3(370.0f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);


            currentBallPos = ball.transform.localPosition.y - gameObject.transform.localPosition.y;

            if (currentBallPos > 30 && (gameObject.transform.localPosition.y + 32) <= (wallTop.transform.localPosition.y - 10))
            {
                transform.Translate(new Vector2(0.0f, 8f));
            }
            else if (currentBallPos < -30 && (gameObject.transform.localPosition.y - 32) >= (wallBottom.transform.localPosition.y + 10))
            {
                transform.Translate(new Vector2(0.0f, -8f));
            } 
        }

        /*Debug.Log(ball.rigidbody2D.velocity.y);
        if (ball.rigidbody2D.velocity.y > 40f && (gameObject.transform.localPosition.y + 32) <= (wallTop.transform.localPosition.y - 10))
        {
            transform.Translate(new Vector2(0.0f, 500.0f*Time.deltaTime)); 
        }
        if (ball.rigidbody2D.velocity.y < 40f && (gameObject.transform.localPosition.y - 32) >= (wallBottom.transform.localPosition.y + 10))
        {
            transform.Translate(new Vector2(0.0f, -500.0f * Time.deltaTime));
        }*/

        /*if (isFirst)
        {
            previousBallPos = ball.transform.localPosition.y;
            isFirst = false;
        }
        previousBallPos -= ball.transform.localPosition.y;
        Debug.Log(previousBallPos);
        if (previousBallPos > 2f)
        {
            transform.Translate(new Vector2(0.0f, 8.0f));
        }
        else if (previousBallPos < 2f)
        {
            transform.Translate(new Vector2(0.0f, -8.0f));
        }*/
    }

    public void ResetPosition()
    {
        gameObject.transform.localPosition = new Vector3(370f, 0f, 0f);
    }
}
