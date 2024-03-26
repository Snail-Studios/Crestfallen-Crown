using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jab_Atk : MonoBehaviour
{
    public bool isminion = false;
    public int Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isminion == false)
        {
            collision.GetComponent<Move2_0>().PDMG(Damage);
        }

        if (collision.CompareTag("Enemy") && isminion == true)
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(Damage);
        }
    }
}
