using Unity;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool CanOpen = false;
    public GameObject interact;
    public GameObject itemToSpawn;
    public bool IsOpened = false;
    public Sprite Opened;
    bool hassent = false;

    private void Start()
    {
        interact.SetActive(false);
    }

    private void Update()
    {
        if (CanOpen && IsOpened == false)
        {
            interact.SetActive(true);

            if (Input.GetKeyUp(KeyCode.E))
            {
                Debug.Log("Open Chest");
                Vector3 spawnPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
                GameObject obj = Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
                IsOpened = true;
            }
        }

        if(IsOpened == false && hassent == false)
        {
            GameObject.Find("CM").GetComponent<ChestManager>().RemoveChest(this.gameObject);
        }

        if (IsOpened && hassent == false)
        {
            interact.SetActive(false);
            this.GetComponent<SpriteRenderer>().sprite = Opened;
            hassent = true;
            GameObject.Find("CM").GetComponent<ChestManager>().AddChest(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanOpen = false;
            interact.SetActive(false);
        }
    }
}
