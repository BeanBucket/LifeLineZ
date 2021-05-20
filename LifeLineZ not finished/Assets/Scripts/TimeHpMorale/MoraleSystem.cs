using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoraleSystem : MonoBehaviour
{
    private static int maxMorale=100;
    private static int morale=100;
    public Image image;
    public Sprite[] morale100Sprites = new Sprite[5];
    public Sprite[] morale80Sprites = new Sprite[4];
    public Sprite[] morale60Sprites = new Sprite[3];
    public Sprite[] morale40Sprites = new Sprite[2];
    public Sprite[] morale20Sprites = new Sprite[2];
    public MoraleLogic moraleLogic;
    public DeathAndRestart deathAndRestart;
    public void Start()
    {
        image = GetComponent<Image>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            morale -= 10;
        }
        if (morale<=0)
        {
            moraleLogic.OpenTheMoralePanel(true);
            maxMorale -= 20;
            SetMorale(maxMorale-1);
        }
        if(maxMorale<=0)
        {
            moraleLogic.OpenTheMoralePanel(false);
            deathAndRestart.OpenTheGamePanel();
        }
        if(morale>80)
        {
            Morale100Change();
        }
        else if(morale>60 && morale<80)
        {
            if(maxMorale==100)
            {
                Morale100Change();
            }
            else
            {
                Morale80Change();
            }
        }
        else if(morale>40 && morale <60)
        {
            if(maxMorale==100)
            {
                Morale100Change();
            }
            else if(maxMorale==80)
            {
                Morale80Change();
            }
            else
            {
                Morale60Change();
            }

        }
        else if(morale>20 && morale <40)
        {
            if (maxMorale == 100)
            {
                Morale100Change();
            }
            else if (maxMorale == 80)
            {
                Morale80Change();
            }
            else if (maxMorale==60)
            {
                Morale60Change();
            }
            else
            {
                Morale40Change();
            }

        }
        else if (morale > 0 && morale < 20)
        {
            if (maxMorale == 100)
            {
                Morale100Change();
            }
            else if (maxMorale == 80)
            {
                Morale80Change();
            }
            else if (maxMorale == 60)
            {
                Morale60Change();
            }
            else if(maxMorale == 40)
            {
                Morale40Change();
            }
            else
            {
                if(morale > 0 && morale < 20)
                {
                    image.sprite = morale20Sprites[0];
                }
                else
                {

                    image.sprite = morale20Sprites[1];
                }
            }

        }


    }
    private void Morale100Change()
    {
        if(morale>80)
        {
            image.sprite = morale100Sprites[0];
        }
        else if (morale > 60 && morale < 80)
        {
            image.sprite = morale100Sprites[1];
        }
        else if (morale > 40 && morale < 60)
        {
            image.sprite = morale100Sprites[2];
        }
        else if (morale > 20 && morale < 40)
        {
            image.sprite = morale100Sprites[3];
        }
        else 
        {
            image.sprite = morale100Sprites[4];
        }

    }
    private void Morale80Change()
    {
         if (morale > 60 && morale < 80)
        {
            image.sprite = morale80Sprites[0];
        }
        else if (morale > 40 && morale < 60)
        {
            image.sprite = morale80Sprites[1];
        }
        else if (morale > 20 && morale < 40)
        {
            image.sprite = morale80Sprites[2];
        }
        else
        {
            image.sprite = morale80Sprites[3];
        }
    }
    private void Morale60Change()
    {
        if (morale > 40 && morale < 60)
        {
            image.sprite = morale60Sprites[0];
        }
        else if (morale > 20 && morale < 40)
        {
            image.sprite = morale60Sprites[1];
        }
        else
        {
            image.sprite = morale60Sprites[2];
        }
    }
    private void Morale40Change()
    {
         if (morale > 20 && morale < 40)
        {
            image.sprite = morale40Sprites[0];
        }
        else
        {
            image.sprite = morale40Sprites[1];
        }
    }
    public static int ReturnMorale()
    {
        return morale;
    }
    public static int ReturnMaxMorale()
    {
        return maxMorale;
    }
    public static void SetMorale(int setTo)
    {
        morale = setTo;
    }
    public static void SetMaxMorale(int  setTo)
    {
        maxMorale = setTo;
    }
    public static void ChangeMorale(int takeMorale)
    {
        morale += takeMorale;
    }
}
