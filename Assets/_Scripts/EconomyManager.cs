using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : Singleton<EconomyManager>
{
    private TMP_Text goldText;
    private TMP_Text goldText1;
    private TMP_Text woodText;
    private TMP_Text woodText1;


    private int currentGold = 0;
    private int currentWood = 0;

    const string COIN_AMOUNT_TEXT = "Gold Coin Text";
    const string COIN1_AMOUNT_TEXT = "Quanti";

    const string WOOD_AMOUNT_TEXT = "Wood Text";
    const string WOOD1_AMOUNT_TEXT = "Quanti1";


    private IncreaseSword increaseSword;
    private IncreaseBow increaseBow;

    public void UpdateCurrentGold()
    {
        currentGold += 1;

        if (goldText == null)
        {
            goldText = GameObject.Find(COIN_AMOUNT_TEXT).GetComponent<TMP_Text>();
            
        }

        goldText.text = currentGold.ToString("D5");
       
    }

    public void UpdateCurrentWood()
    {
        currentWood += 1;

        if (woodText == null)
        {
            woodText = GameObject.Find(WOOD_AMOUNT_TEXT).GetComponent<TMP_Text>();
            
        }

        woodText.text = currentWood.ToString("D5");
       
    }

    public void UpdateBag()
    {
        goldText1 = GameObject.Find(COIN1_AMOUNT_TEXT).GetComponent<TMP_Text>();
        goldText1.text = currentGold.ToString();

        woodText1 = GameObject.Find(WOOD1_AMOUNT_TEXT).GetComponent<TMP_Text>();
        woodText1.text = currentWood.ToString();
    }
        //public void OnActivated()
        //{

        //}

    public void UpWeapon()
    {   
        if (currentGold >= 10 && currentWood >= 10)
        {
            currentGold -= 10;
            currentWood -= 10;


            goldText.text = currentGold.ToString("D5");
            woodText.text = currentWood.ToString("D5");
            if (increaseSword == null)
            {
                
                increaseSword = FindObjectOfType<IncreaseSword>();
            }
            if (increaseSword != null)
            {
                increaseSword.IncreaseSword1();
            }
            else
            {
                Debug.LogWarning("IncreaseSword component not found!");
            }
            
            
        }

        else
        {

        }
    }
    public void UpWeapon2()
    {
        if (currentGold >= 10 && currentWood >= 10)
        {
            currentGold -= 10;
            currentWood -= 10;


            goldText.text = currentGold.ToString("D5");
            woodText.text = currentWood.ToString("D5");
            if (increaseBow == null)
            {

                increaseBow = FindObjectOfType<IncreaseBow>();
            }
            if (increaseBow != null)
            {
                increaseBow.IncreaseBow1();
            }
            else
            {
                Debug.LogWarning("IncreaseSword component not found!");
            }


        }

        else
        {

        }
    }
}
