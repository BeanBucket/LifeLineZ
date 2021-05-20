using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private static int hp=100;
    public Image image;
    public Sprite[] hpBarSprites= new Sprite [6];
    public DeathAndRestart deathAndRestart;
    public void Start()
    {
        image = GetComponent<Image>();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            hp = 0;
        }
        if(hp>100)
        {
            hp = 100;
        }
        if(hp >= 80 )
        {
            image.sprite = hpBarSprites[0];
        }
        else if (hp>=60 && hp<80)
        {
            image.sprite = hpBarSprites[1];
        }
        else if (hp >= 40 && hp < 60)
        {
            image.sprite = hpBarSprites[2];
        }
        else if (hp >= 20 && hp < 40)
        {
            image.sprite = hpBarSprites[3];
        }
        else if (hp > 0 && hp < 20)
        {
            image.sprite = hpBarSprites[4];
        }
        else if (hp <= 0 )
        {
            image.sprite = hpBarSprites[5];
            deathAndRestart.OpenTheGamePanel();
        }
    }   
    public static int ReturnHp()
    {
        return hp;
    }
    public static void SetHp(int setTo)
    {
        hp = setTo;
    }
    public static void ChangeHp(int takeHp)
    {
        hp += takeHp;
    }

}
