using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score = 0;
    public int highScore = 0;
    private Rigidbody2D rb2d;


    public Text scoreText, highScoreText;

    private void Awake()
    {


        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = highScore.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.velocity.y > 0 && transform.position.y > score)
        {

            score = (int)transform.position.y;

        }

        scoreText.text = "Score: " + Mathf.Round(score).ToString();
        UpdateHighScore();
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    public void UpdateHighScore()
    {

        if (score > highScore)

        {

            highScore = score;

            PlayerPrefs.SetInt("HighScore", highScore);

        }

    }

}
