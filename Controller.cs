using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class Controller : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;

    public int score = 0;
    public int highScore = 0;

   
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

        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (moveInput < 0)
        {

            this.GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {

            this.GetComponent<SpriteRenderer>().flipX = false;

        }

        if (rb2d.velocity.y > 0 && transform.position.y > score)
        {

            score = (int)transform.position.y;

        }

        scoreText.text = "Score: " + Mathf.Round(score).ToString();
        UpdateHighScore();
        highScoreText.text = "HighScore: " + highScore.ToString();

    }

    void FixedUpdate()
    {


        moveInput = Input.GetAxis("Horizontal");
        moveInput = CrossPlatformInputManager.GetAxis("Horizontal");



        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
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
