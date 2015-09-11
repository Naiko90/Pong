using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Ball>().SendMessage("ResetBall", gameObject.name);
    }
}
