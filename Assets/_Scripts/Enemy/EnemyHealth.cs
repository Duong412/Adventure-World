using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 5;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust=15f;

    private int currenthealth;
    private Knockback knockback;
    private Flash flash;
    

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
      
    }
    private void Start()
    {   

        currenthealth = startingHealth;
        
    }
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        knockback.GetKnockedBack(PlayerControl.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }
    public void DetectDeath()
    {
        if (currenthealth <= 0) 
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GetComponent<PickUpSpawner>().DropItems();  
            
        }
    }
    

}
