using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCoin : MonoBehaviour
{
    //points for the coin pickup
    private int points = 2;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            scoreManager.ScoreCountUpdate(points);
            Destroy(gameObject);
        }
    }
}
