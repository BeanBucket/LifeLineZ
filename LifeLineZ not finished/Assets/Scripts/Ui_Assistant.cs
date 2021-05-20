using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Assistant : MonoBehaviour
{
    public DialogGraph activeDialog;

    public List<Button> OptionButtons;

    public GameObject buttonPrefab;

    public Transform buttonParent;

    private int segmentIndex = 0;

    public DialogInforamtion activeSegment;

    public Text messageText;

    public static Ui_Assistant Instance;

    private bool hasUpdated;

    public TextStorage oldMessages;

    public TextWriterCall textWriterCall;

    public GameObject buttonContainer;

    public DialogInforamtion lastNode;

    
    void Start()
    {
        Instance = this;
        textWriterCall = messageText.GetComponent<TextWriterCall>();
        // Find Start Node
        if (!PlayerPrefs.HasKey("hp"))
        {
            foreach (DialogInforamtion node in activeDialog.nodes)
            {
                if (!node.GetInputPort("input").IsConnected)
                {
                    UpdateDialog(node);
                    break;
                }
            }
        }
          
    }
    public void LoadNode(Vector2 nodePossition)
    {
        foreach (DialogInforamtion node in activeDialog.nodes)
        {
            if(nodePossition==node.position)
            {
                UpdateDialog(node);
                    break;
            }
        }
    }
    private void Update()
    {
        hasUpdated = false;
    }


    public void AnswerClicked(int clickedIndex)
    {
        activeSegment.Answers[clickedIndex].actions.Invoke();
        if (hasUpdated)
            return;
        var port = activeSegment.GetPort("Answers " + clickedIndex);
        if (port.IsConnected)
            UpdateDialog(port.Connection.node as DialogInforamtion);
        else
            gameObject.SetActive(false);

    }

    public void UpdateDialog(DialogInforamtion newSegment)
    {
        buttonContainer.SetActive(false);
        activeSegment = newSegment;
        oldMessages.AddText(messageText.text);
        messageText.text = newSegment.MessageArray;
        textWriterCall.SetText(messageText.text);
        SpawnButtons(newSegment);
        lastNode = newSegment;


    }
    public void SpawnButtons (DialogInforamtion newSegment)
    {
        int answerIndex = 0;
        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var answer in newSegment.Answers)
        {
            var btn = Instantiate(buttonPrefab, buttonParent);
            btn.GetComponentInChildren<Text>().text = answer.text;

            var index = answerIndex;
            btn.GetComponentInChildren<Button>().onClick.AddListener((() => { AnswerClicked(index); }));

            answerIndex++;
        }
        hasUpdated = true;
        buttonParent.gameObject.SetActive(false);
    }
    public void SetButtonsTrue()
    {
        buttonParent.gameObject.SetActive(true);
    }
}
