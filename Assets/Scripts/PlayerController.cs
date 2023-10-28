//////////////////////////////////////////////////////
// Assignment/Lab/Project: 112RollABall
//Name: Shaniah Taylor
//Section: 2022FA.SGD.112.2602
//Instructor: Lydia Granholm
// Date: 10/28/2023
//////////////////////////////////////////////////////
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
    //public GameObject NextLevel;
    public TimerScr levTime;
    public int minNum1;
    public int minNum2;
    public int secNum1;
    public int secNum2;
    public Canvas winCanvas;


    public int lives = 3;
    public TMP_Text lifeText;

    //These private variables are initialized in the Start
    private Rigidbody rb;
    private int count;
    //private bool gameOver; //  bool to define game state on or off.
    public bool invincible;

    // Audio
    public AudioClip coinSFX;
    public AudioClip gemSFX;
    public AudioClip truckSFX;
    public AudioClip splashSFX;
    public AudioSource audioSource;
    public AudioClip garf;
    public AudioClip yay;
    public GameObject waterSplash;
    public TMP_Text invincibleText;


    public bool win = false;
    public bool lev;
    string currentSceneName;

    public TakeDamageScr damageScript;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // access the audio source component of player
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        startingTime = Time.time;
        //gameOver = false;
        lifeText.text = "Lives: " + lives;
        currentSceneName = SceneManager.GetActiveScene().name;
        winCanvas.enabled = false;

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
            invincible = true;
            Invoke("EndInvincible", 10);
            invincibleText.text = "";
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Jump"))
        {
            rb.AddForce(new Vector3(0.0f, 300.0f, 0.0f));
        }

        if (other.gameObject.CompareTag("Projectile"))
        {

            TakeDamage();
            Destroy(other.gameObject);
            audioSource.clip = garf;
            audioSource.Play();
        }

        if (other.gameObject.CompareTag("Truck"))
        {
            audioSource.clip = truckSFX;
            audioSource.Play();
            TakeDamage();
        }

        if (other.gameObject.CompareTag("Food"))
        {
            TakeDamage();
            Destroy(other.gameObject);
        }

    }

    public void endInvincible()
    {
        invincible = false;
        invincibleText.text = "You are no longer invincible";
    }

    public void restartFunc()
    {
        SceneManager.LoadScene(currentSceneName);
    }

    public void ErrorMessage()
    {
        errorText.text = "";
    }

    public void TakeDamage()
    {
        if (invincible != true)
        {
            lives--;
            damageScript.StartCoroutine(damageScript.TakeDamageEffect());
        }

    }


    void SetCountText()
    {
        countText.text = "Coins: " + count.ToString();
        if (currentSceneName == "Game")
        {
            int.TryParse(min, out minNum1);
            int.TryParse(sec, out secNum1);
            TimerScr.levTime.minNum1 = minNum1;
            TimerScr.levTime.secNum1 = secNum1;
            TimerScr.levTime.levOneTime = "Level 1 Time: " + min + ":" + sec;
        }
        if (currentSceneName == "LevelTwo")
        {
            int.TryParse(min, out minNum2);
            int.TryParse(sec, out secNum2);
            TimerScr.levTime.minNum2 = minNum2;
            TimerScr.levTime.secNum2 = secNum2;
            TimerScr.levTime.levTwoTime = "Level 2 Time: " + min + ":" + sec;
        }

        if (count >= 10 && currentSceneName == "LevelTwo")
        {
            rb.isKinematic = true;
            winCanvas.enabled = true;
            audioSource.clip = yay;
            audioSource.Play();

        }

        
    }


}
