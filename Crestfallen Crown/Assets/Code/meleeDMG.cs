using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeDMG : MonoBehaviour
{
    [SerializeField] int Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().TakeDamage(Damage);
        }
    }
}
