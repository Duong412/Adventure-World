using TMPro;
using UnityEngine;

public class IncreaseBow : MonoBehaviour, IWeapon
{
    public WeaponInfo weaponInfo;

    const string BOW_DAMAGE_TEXT = "Bow Damage";
    private TMP_Text bowdamage;
    private int currentdamage1 = 1;

    public void UpdateWeapon1()
    {
        EconomyManager.Instance.UpWeapon2();
        GetWeaponInfo();
    }

    public WeaponInfo GetWeaponInfo()
    {
        //Debug.Log("Update");
    
        //Debug.Log(weaponInfo.weaponDamage);
        //Debug.Log(weaponInfo.weaponRange);
        return weaponInfo;
    }
    public void IncreaseBow1()
    {
        if (weaponInfo != null)
        {
            currentdamage1 += 1;
            weaponInfo.weaponDamage += 1;
            //weaponInfo.weaponRange++;
            bowdamage = GameObject.Find(BOW_DAMAGE_TEXT).GetComponent<TMP_Text>();
            bowdamage.text = currentdamage1.ToString();
        }
        else
        {
            Debug.LogError("WeaponInfo is not assigned!");
        }
    }

    void IWeapon.Attack()
    {
        throw new System.NotImplementedException();
    }

    
}   