using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public Movement Player;
    public GameObject outline;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        outline = this.gameObject.transform.GetChild(0).gameObject;
    }

    void Pickup()
    {
        InventoryManager.instance.add(item);
        InventoryManager.instance.ListItems();
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Player.canpickup == true)
        {
            Pickup();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        outline.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        outline.SetActive(false);
    }
}
