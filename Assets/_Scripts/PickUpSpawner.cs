using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin, healthGlobe;

    public void DropItems()
    {
        int randomNum = Random.Range(1, 4);

        if (randomNum == 1)
        {
            Instantiate(healthGlobe, transform.position, Quaternion.identity);
        }

        //if (randomNum == 2)
        //{
        //    Instantiate(staminaGlobe, transform.position, Quaternion.identity);
        //}

        if (randomNum == 2)
        {
            int AmountOfGold = 1;

            for (int i = 0; i < AmountOfGold; i++)
            {
                Instantiate(goldCoin, transform.position, Quaternion.identity);
            }
        }

        if (randomNum == 3)
        {
            int AmountOfGold = 2;

            for (int i = 0; i < AmountOfGold; i++)
            {
                Instantiate(goldCoin, transform.position, Quaternion.identity);
            }
        }

        if (randomNum == 4)
        {
            int AmountOfGold = 3;

            for (int i = 0; i < AmountOfGold; i++)
            {
                Instantiate(goldCoin, transform.position, Quaternion.identity);
            }
        }
    }
}
