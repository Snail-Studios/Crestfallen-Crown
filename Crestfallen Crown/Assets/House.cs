using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject[] interior;
    public GameObject[] exterior;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject i in interior)
            {
                i.SetActive(true);
            }

            foreach (GameObject i in exterior)
            {
                i.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.transform.position.y < this.transform.position.y)
        {
            foreach (GameObject i in interior)
            {
                i.SetActive(false);
            }

            foreach (GameObject i in exterior)
            {
                i.SetActive(true);
            }
        }
    }
}
