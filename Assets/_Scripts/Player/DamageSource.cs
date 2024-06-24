using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem.iOS;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int damageAmount ;


    private void Start()
    {
        MonoBehaviour currentActiveWeapon = ActiveWeapon.Instance.CurrentActiveWeapon;
        damageAmount = (currentActiveWeapon as IWeapon).GetWeaponInfo().weaponDamage;
    }

    private void Update()
    {
        MonoBehaviour currentActiveWeapon = ActiveWeapon.Instance.CurrentActiveWeapon;
        damageAmount = (currentActiveWeapon as IWeapon).GetWeaponInfo().weaponDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        enemyHealth?.TakeDamage(damageAmount);

        GhostHealth ghostHealth = other.gameObject.GetComponent<GhostHealth>();
        ghostHealth?.TakeDamage(damageAmount);

        GhostHealth0 ghostHealth0 = other.gameObject.GetComponent<GhostHealth0>();
        ghostHealth0?.TakeDamage(damageAmount);

        GrapeHealth grapeHealth = other.gameObject.GetComponent<GrapeHealth>();
        grapeHealth?.TakeDamage(damageAmount);

    }
}
