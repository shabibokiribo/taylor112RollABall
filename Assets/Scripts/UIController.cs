using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {


    public TMP_Text level1Time;
    public TMP_Text level2Time;
    public int totalMin;
    public int totalSec;
    public TMP_Text totalTime;
    public PlayerController pc;
    public TimerScr levTime;

    public void OnClickQuitButton()
    {
        print("Quit button was clicked");
        Application.Quit();
    }

    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "LevelTwo" && pc.winCanvas.enabled == true)
        {
            totalMin = TimerScr.levTime.minNum1 + TimerScr.levTime.minNum2;
            totalSec = TimerScr.levTime.secNum1 + TimerScr.levTime.secNum2;

            if(totalSec >= 60)
            {
                totalSec -= 60;
                totalMin++;
            }

            if(totalSec < 10) 
            {
                totalTime.text = "Total Time:" + totalMin + ":" + "0" + totalSec;
            }
            else
            {
                totalTime.text = "Total Time:" + totalMin + ":" + totalSec;
            }

            if (pc.winCanvas.enabled == true)
            {
                level1Time.text = TimerScr.levTime.levOneTime;
            }
            if (pc.winCanvas.enabled == true)
            {
                level2Time.text = TimerScr.levTime.levTwoTime;
            }


        }

    }
}
