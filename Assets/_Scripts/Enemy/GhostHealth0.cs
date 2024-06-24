using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class GhostHealth0 : MonoBehaviour
{
    [SerializeField] private int maxHealth = 30;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 15f;

    const string GHOST_HEALTH_TEXT = "Ghost Health0";
    private Slider ghosthealth;

    private int currentghosthealth;
    private Knockback knockback;
    private Flash flash;

    public GameObject AreaExit;
    public GameObject Arrow;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();

    }
    private void Start()
    {

        currentghosthealth = maxHealth;
        UpdateHealthSlider1();
        AreaExit.SetActive(false);
        Arrow.SetActive(false);
    }
    private void Update()
    {
        //UpdateHealthSlider1();
    }
    public void TakeDamage(int damage)
    {
        currentghosthealth -= damage;
        knockback.GetKnockedBack(PlayerControl.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
        UpdateHealthSlider1();
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }
    public void DetectDeath()
    {
        if (currentghosthealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GetComponent<PickUpSpawner0>().DropItems0();
            AreaExit.SetActive(true);
            Arrow.SetActive(true);
        }
    }

    private void UpdateHealthSlider1()
    {
        if (ghosthealth == null)
        {
            ghosthealth = GameObject.Find(GHOST_HEALTH_TEXT).GetComponent<Slider>();
        }

        ghosthealth.maxValue = maxHealth;
        ghosthealth.value = currentghosthealth;
    }

}
