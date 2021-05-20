using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;
using UnityEngine.Events;

[Serializable]
public struct Connection { }

public class DialogInforamtion : Node
{
    [Serializable]
    public class DialogOption
    {
        public string text = string.Empty;
        public UnityEvent actions;
        public int Count;
    }
    [Input]
    public Connection input;

    public string MessageArray;

    [Output(dynamicPortList = true)]
    public List<DialogOption> Answers;
    public override object GetValue(NodePort port)
    {
        return null;
    }
}
