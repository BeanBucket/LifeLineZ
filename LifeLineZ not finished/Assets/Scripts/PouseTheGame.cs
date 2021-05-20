using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PouseTheGame : MonoBehaviour
{
    public bool gameIsPoused = false;
    public GameObject pauseMenuPanel;
    public static float timeToStop;
    public Text textBox;
    public GameObject freshTextPanel;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            timeToStop = 0;
        }
        timeToStop -= Time.deltaTime;
            if(timeToStop<=0)
            {
                Resume();
            }
            else
            {
                Pause();
                textBox.text = Mathf.Round(timeToStop).ToString();
            }
    }
    void Resume()
    {
        pauseMenuPanel.SetActive(false);
    }
    void Pause()
    {
        pauseMenuPanel.SetActive(true);
    }
    public static float ReturnTimeStop()
    {
        return timeToStop;
    }
    public static void SetTimeStop(float setTo)
    {
        timeToStop = setTo;
    }
}
