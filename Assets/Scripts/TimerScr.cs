using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScr : MonoBehaviour
{
    public static TimerScr levTime {  get; private set; }
    public string levOneTime = "";
    public string levTwoTime = "";
    public int minNum1 =0;
    public int minNum2 = 0;
    public int secNum1 = 0;
    public int secNum2 = 0;

    private void Awake()
    {
        if (levTime == null)
        {
            levTime = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
