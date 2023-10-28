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

public class LevelLoaderScript : MonoBehaviour
{
    public PlayerController psCon;

    public Animator transition;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(psCon.lev == true)
        {
            LoadLevTwo();
        }
    }

    public void LoadLevTwo()
    {
        StartCoroutine(LoadLevelTwo(2));
    }

    IEnumerator LoadLevelTwo(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("LevelTwo");
    }
}
