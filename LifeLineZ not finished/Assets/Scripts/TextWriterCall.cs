using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriterCall : MonoBehaviour
{
    private string message;
    public Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    public Ui_Assistant ui_assistant;
    public DialogInforamtion lastnewSegment;

    public void Awake()
    {
        messageText = GetComponent<Text>();
    }
    public void Update()
    {
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            //ends the message on click
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                textWriterSingle.WriteAllAndDestroy();
            }
        }
        else if(IsActive()==false)
        {
            ui_assistant.SetButtonsTrue();
        }
    }
    public void SetText (string textUse)
    {
        message = textUse;
        //New message on click when the message has ended
        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, 0.1f, true, true);
        
    
    }
    public bool IsActive()
    {
        if (textWriterSingle != null)
            return false;
        return true;
    }
}
