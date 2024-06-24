using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner0 : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin;

    public void DropItems0()
    {
        
            int AmountOfGold = 20;

            for (int i = 0; i < AmountOfGold; i++)
            {
                Instantiate(goldCoin, transform.position, Quaternion.identity);
            }
        
    }
}
