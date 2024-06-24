using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWood : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSource>())
        {
            GetComponent<SpawnerWood>().DropWood();
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
