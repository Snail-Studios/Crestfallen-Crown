// PickupItem.cs
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item2 item; // Reference to the item to be picked up

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify the player controller that an item is picked up
            other.GetComponent<Move2_0>().PickupItem(item);

            // Optionally, you can play a pickup sound, disable the item, etc.
            Destroy(gameObject);
        }
    }
}
