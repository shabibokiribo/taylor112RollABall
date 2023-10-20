﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //needed to restart the game when the player enters the death zone (trigger event)
using TMPro;

public class PlayerController : MonoBehaviour
{

    //These public variables are initialized in the Inspector
    public float speed;
    public TMP_Text countText;
    public TMP_Text winText;
    public TMP_Text timeText;  //  variable to display the timer text in Unity
    public float startingTime;  // variable to hold the game's starting time
    public string min;
    public string sec;

    public int lives;
    public TMP_Text lifeText;

    //These private variables are initialized in the Start
    private Rigidbody rb;
    private int count;
    private bool gameOver; //  bool to define game state on or off.

    // Audio
    public AudioClip coinSFX;
    public AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // access the audio source component of player
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        startingTime = Time.time;
        gameOver = false;

        lives = 3;
        lifeText.text = "Lives: " + lives;


    }
    private void Update()
    {
        if (gameOver) // condition that the game is NOT over; returns the false value
            return;
        float timer = Time.time - startingTime;     // local variable to updated time
        min = ((int)timer / 60).ToString();     // calculates minutes
        sec = (timer % 60).ToString("f0");      // calculates seconds

        timeText.text = "Elapsed Time: " + min + ":" + sec;     // update UI time text
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        //This event/function handles trigger events (collsion between a game object with a rigid body)
   
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;

            //PLAY SOUND EFFECT
            audioSource.clip = coinSFX;
            audioSource.Play();
            Destroy(other.gameObject);
            SetCountText();

        }

        if (other.gameObject.CompareTag("DeathZone"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        if (other.gameObject.CompareTag("LifeGem"))
        {
            if (transform.localScale.x <= 2.0f)
            {
                transform.localScale *= 1.25f;    // increase scale by 25%
            }
        }

        if (other.gameObject.CompareTag("InvincibleGem"))
        {
            if (transform.localScale.x >= 0.5f)
            {
                transform.localScale *= 0.75f;     // decreases scale by 25%
            }
        }

        if (other.gameObject.CompareTag("Jump"))
        {
            rb.AddForce(new Vector3(0.0f, 300.0f, 0.0f));
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 2)
        {
            gameOver = true; // returns true value to signal game is over
            timeText.color = Color.green;  // changes timer's color
            winText.text = "You win!";
            speed = 0;
        }
    }
}
