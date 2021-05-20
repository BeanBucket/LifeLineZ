using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public Ui_Assistant ui_assistant;
    public bool save = true;
    public TextStorage textStorage;

    void Start()
    {
        if (PlayerPrefs.HasKey("hp"))
        {
            textStorage.SetText(PlayerPrefs.GetString("oldText"));
            HpBar.SetHp(PlayerPrefs.GetInt("hp"));
            TimeManager.SetTime(PlayerPrefs.GetInt("time"));
            MoraleSystem.SetMorale(PlayerPrefs.GetInt("morale"));
            MoraleSystem.SetMorale(PlayerPrefs.GetInt("maxMorale"));
            PouseTheGame.SetTimeStop(PlayerPrefs.GetFloat("timeIfStoped"));
            ui_assistant.LoadNode(new Vector2(PlayerPrefs.GetFloat("nodePositionX"), PlayerPrefs.GetFloat("nodePositionY")));
        }
        else
        {
            MoraleSystem.SetMorale(100);
            MoraleSystem.SetMaxMorale(100);
            HpBar.SetHp(100);
            TimeManager.SetTime(390);
            PouseTheGame.SetTimeStop(0);
        }
    }

    public void ResetTheGame( )
    {
        PlayerPrefs.DeleteAll();
        save = false;        
        SceneManager.LoadScene("SampleScene");

    }
    private void OnApplicationQuit()
    {
        if (save)
        {
            foreach (DialogInforamtion node in ui_assistant.activeDialog.nodes)
            {
                if (ui_assistant.lastNode == node)
                {
                    PlayerPrefs.SetFloat("nodePositionX", node.position.x);
                    PlayerPrefs.SetFloat("nodePositionY", node.position.y);
                }

            }
            PlayerPrefs.SetInt("time", TimeManager.ReturnTime());
            PlayerPrefs.SetString("oldText", textStorage.ReturnText());
            PlayerPrefs.SetInt("hp", HpBar.ReturnHp());
            PlayerPrefs.SetInt("morale", MoraleSystem.ReturnMorale());
            PlayerPrefs.SetInt("maxMorale", MoraleSystem.ReturnMaxMorale());
            PlayerPrefs.SetFloat("timeIfStoped", PouseTheGame.ReturnTimeStop());
            PlayerPrefs.Save();
        }
    }
}
