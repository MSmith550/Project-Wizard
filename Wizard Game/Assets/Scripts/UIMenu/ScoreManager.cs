using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    private int scoreCount = 0;

    private void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
    }

    public void ScoreCountUpdate(int points)
    {
        scoreCount += points;
    }
}
