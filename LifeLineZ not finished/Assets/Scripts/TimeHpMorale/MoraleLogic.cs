using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraleLogic : MonoBehaviour
{
    public GameObject panel;
    public MoraleSystem moraleSystem;

    public void OpenTheMoralePanel(bool closeOpen)
    {
        if(panel!=null)
        {
            panel.SetActive(closeOpen);
        }
    }
}
