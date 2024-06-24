using TMPro;
using UnityEngine;

public class IncreaseSword : MonoBehaviour, IWeapon
{
    public WeaponInfo weaponInfo;

    const string SWORD_DAMAGE_TEXT = "Sword Damage";
    private TMP_Text sworddamage;
    private int currentdamage = 2;

    public void UpdateWeapon()
    {
        EconomyManager.Instance.UpWeapon();
        GetWeaponInfo();
    }

    public WeaponInfo GetWeaponInfo()
    {
        //Debug.Log("Update");
    
        //Debug.Log(weaponInfo.weaponDamage);
        //Debug.Log(weaponInfo.weaponRange);
        return weaponInfo;
    }
    public void IncreaseSword1()
    {
        if (weaponInfo != null)
        {
            currentdamage += 1;
            weaponInfo.weaponDamage += 1;
            //weaponInfo.weaponRange++;
            sworddamage = GameObject.Find(SWORD_DAMAGE_TEXT).GetComponent<TMP_Text>();
            sworddamage.text = currentdamage.ToString();
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