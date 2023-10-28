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
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickHelp()
    {
        SceneManager.LoadScene("HELP");
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("Game");
    }
}



