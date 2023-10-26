using System.Collections;
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
    public TMP_Text loseText;
    public TMP_Text errorText;
    public TMP_Text timeText;  //  variable to display the timer text in Unity
    public float startingTime;  // variable to hold the game's starting time
    public string min;
    public string sec;
    public Transform playerPos;

    public int lives = 3;
    public TMP_Text lifeText;

    //These private variables are initialized in the Start
    private Rigidbody rb;
    private int count;
    private bool gameOver; //  bool to define game state on or off.
    public bool invincible;

    // Audio
    public AudioClip coinSFX;
    public AudioClip gemSFX;
    public AudioClip truckSFX;
    public AudioClip splashSFX;
    public AudioSource audioSource;
    public AudioClip garf;
    public GameObject waterSplash;


    public bool win = false;
    public bool lev;
    string currentSceneName;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // access the audio source component of player
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        startingTime = Time.time;
        gameOver = false;
        lifeText.text = "Lives: " + lives;
        currentSceneName = SceneManager.GetActiveScene().name;

    }
    private void Update()
    {
        lifeText.text = "Lives: " + lives;
        float timer = Time.time - startingTime;     // local variable to updated time
        min = ((int)timer / 60).ToString();     // calculates minutes
        sec = (timer % 60).ToString("f0");      // calculates seconds

        timeText.text = "Elapsed Time: " + min + ":" + sec;     // update UI time text
        
        if (lives <= 0)
        {
            SceneManager.LoadScene(currentSceneName);
        }

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
            count++;

            //PLAY SOUND EFFECT
            audioSource.clip = coinSFX;
            audioSource.Play();
            Destroy(other.gameObject);
            SetCountText();

        }
        if (other.gameObject.tag == "LevelCoin")
        {

            if (count == 9)
            {
                count++;

                //PLAY SOUND EFFECT
                audioSource.clip = coinSFX;
                audioSource.Play();
                Destroy(other.gameObject);
                SetCountText();
                lev = true;
            }
            else
            {
                errorText.text = "You haven't collected the other coins! come back when you have 9!";
                Invoke("ErrorMessage", 3);
            }
        
        }

        if (other.gameObject.tag == "WinCoin")
        {
            if (count == 9)
            {
                //PLAY SOUND EFFECT
                audioSource.clip = coinSFX;
                audioSource.Play();
                count++;
                Destroy(other.gameObject);
                SetCountText();
                win = true;
            }
            else
            {
                errorText.text = "You haven't collected the other coins! come back when you have 9!";
                Invoke("ErrorMessage",3);
            }
        }

        if (other.gameObject.CompareTag("DeathZone"))
        {
            audioSource.clip = splashSFX;
            audioSource.Play();
            loseText.text = "You Died";
            Instantiate(waterSplash, playerPos.position, Quaternion.identity);
            rb.isKinematic = true;
            Invoke("restartFunc", 2);
        }

        if (other.gameObject.CompareTag("LifeGem"))
        {
            audioSource.clip = gemSFX;
            audioSource.Play();
            lives++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("InvincibleGem"))
        {
            audioSource.clip = gemSFX;
            audioSource.Play();
            Invoke("isInvincible", 10.0f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Jump"))
        {
            rb.AddForce(new Vector3(0.0f, 300.0f, 0.0f));
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
           
            lives--;
            Destroy(other.gameObject);
            audioSource.clip = garf;
            audioSource.Play();
        }

        if (other.gameObject.CompareTag("Truck"))
        {
            audioSource.clip = truckSFX;
            audioSource.Play();
            lives--;
        }

        if (other.gameObject.CompareTag("Food"))
        {
            lives--;
            Destroy(other.gameObject);
        }

    }

    public void isInvincible()
    {
        invincible = true;
    }

    public void restartFunc()
    {
        SceneManager.LoadScene(currentSceneName);
    }

    public void ErrorMessage()
    {
        errorText.text = "";
    }


    void SetCountText()
    {
        countText.text = "Coins: " + count.ToString();
        if(count >= 10 && currentSceneName == "LevelTwo")
        {
            
         SceneManager.LoadScene("WIN");
            
        }
        
    }


}
