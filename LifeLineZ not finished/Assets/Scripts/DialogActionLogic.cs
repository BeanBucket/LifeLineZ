using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class DialogActionLogic : ScriptableObject
{
    public int timesDone;
    public int howManySleepTimes;
    public void HpLogic(int howMuch)
    {
        HpBar.ChangeHp(howMuch);
    }
    public void Time(int howMuch)
    {
        TimeManager.AddTime(howMuch);
    }
    public void sleepInLogic(DialogInforamtion di)
    {
        timesDone += 1;
        if (timesDone > howManySleepTimes) 
        { 
            Ui_Assistant.Instance.UpdateDialog(di);
        }
        else 
        {
            Ui_Assistant.Instance.UpdateDialog(Ui_Assistant.Instance.activeSegment);
        }
    }
    public void SetTime(int time)
    {
        TimeManager.SetTime(time);
    }
    public void SetTimeToWait(float time)
    {
        PouseTheGame.SetTimeStop(time);
    }

    public void SetSleepInLogic(int howMany)
    {
        howManySleepTimes = howMany;
    }
    public string prefabName;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;
}
