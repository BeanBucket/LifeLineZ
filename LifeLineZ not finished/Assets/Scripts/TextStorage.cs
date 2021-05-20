using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStorage : MonoBehaviour
{
    private  List<string> allTextUsed = new List<string>();

    public Text textBox;

    public void AddText(string textAdd)
    {
        allTextUsed.Add(textAdd);
        WriteLastMember();
    }
    public void WriteLastMember()
    {
        textBox.text += allTextUsed[allTextUsed.Count-1]+"\n";
    }
    public void SetText(string setText)
    {
        textBox.text = setText;
    }
    public string ReturnText()
    {
        return textBox.text;
    }
}

