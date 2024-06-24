using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GrapeHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 5f;

    const string GRAPE_HEALTH_TEXT = "Grape Health";
    private Slider grapehealth;

    private int currentgrapehealth;
    private Knockback knockback;
    private Flash flash;

    //public GameObject EndGame;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        
    }
    private void Start()
    {

        currentgrapehealth = maxHealth;
        UpdateHealthSlider2();
        //EndGame.SetActive(false);

    }
    private void Update()
    {
        //UpdateHealthSlider1();
    }
    public void TakeDamage(int damage)
    {
        currentgrapehealth -= damage;
        knockback.GetKnockedBack(PlayerControl.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
        UpdateHealthSlider2();
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }
    public void DetectDeath()
    {
        if (currentgrapehealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            //GetComponent<PickUpSpawner0>().DropItems0();
            //EndGame.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    private void UpdateHealthSlider2()
    {
        if (grapehealth == null)
        {
            grapehealth = GameObject.Find(GRAPE_HEALTH_TEXT).GetComponent<Slider>();
        }

        grapehealth.maxValue = maxHealth;
        grapehealth.value = currentgrapehealth;
    }

}
