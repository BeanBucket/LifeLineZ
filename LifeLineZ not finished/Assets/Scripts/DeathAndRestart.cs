using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAndRestart : MonoBehaviour
{
    public SaveLoad saveLoad;
    public GameObject panel;
    public void OpenTheGamePanel()
    {
        if(panel!=null)
        {
            panel.SetActive(true);
        }
    }
    public void RestartTheGame()
    {
        saveLoad.ResetTheGame();
    }

}
