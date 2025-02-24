using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdFly : MonoBehaviour
{
    public float velocity = 3;
    private Rigidbody2D rb;

    private bool levelStrart;
    public GameObject PipeSpawer;

    private int score;
    public Text scoreText;

    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        levelStrart = false;
        rb.gravityScale = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            BirdUp();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                BirdUp();
            }
        }
    }
    private void BirdUp()
    {
        if (levelStrart == false)
        {
            levelStrart = true;
            rb.gravityScale = 1;
            PipeSpawer.GetComponent<PipeSpawer>().enablePipeSpawer = true;
            message.GetComponent<SpriteRenderer>().enabled = false;
        }
        rb.linearVelocity = Vector2.up * velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReloadScene();
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
