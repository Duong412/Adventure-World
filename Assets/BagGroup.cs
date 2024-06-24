using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BagGroup : MonoBehaviour
{
    

    private void Update()
    {
        EconomyManager.Instance.UpdateBag();
        

    }

}
