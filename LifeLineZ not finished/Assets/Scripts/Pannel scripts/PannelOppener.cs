using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelOppener : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel()
    {
        if(panel!=null)
        {
            panel.SetActive(true);
        }

    }
}
