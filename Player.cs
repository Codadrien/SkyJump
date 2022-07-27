using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;

    private float topScore = 0.0f;

    public Text scoreText;

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

        if (rb2d.velocity.y > 0 && transform.position.y > topScore)
        {

            topScore = transform.position.y;

        }

        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();

    }

    void FixedUpdate()
    {

        moveInput = Input.GetAxis("Horizontal");



        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }
}
