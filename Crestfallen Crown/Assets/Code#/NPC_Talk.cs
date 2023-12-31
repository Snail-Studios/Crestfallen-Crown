using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class NPC_Talk : MonoBehaviour
{

    public bool IStalkable = false;
    public GameObject interact;
    public GameObject talkUI;
    public string dialouge;
    public Image NPC;
    bool talking;
    public bool QuestGiver;
    public GameObject YNButton;
    public LayerOptions QuestType;
    public int ItemNeeded;
    public List<GameObject> EnemysToDie = new List<GameObject>();
    public string completedDialouge;
    bool questcomp = false;
    bool Questaccepted = false;

    public enum LayerOptions
    {
        None,
        Fetch,
        Guide,
        Kill
    }

    // Start is called before the first frame update
    void Start()
    {
        interact.SetActive(false);
        IStalkable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IStalkable)
        {
            interact.SetActive(true);
        }
        else
        {
            //interact.SetActive(false);
            //talkUI.SetActive(false);
        }

        if(IStalkable)
        {
            if (Input.GetKeyUp("e") && talking == false)
            {
                talkUI.SetActive(true);
                talkUI.GetComponentInChildren<TMP_Text>().text = dialouge;
                NPC.sprite = this.GetComponent<SpriteRenderer>().sprite;
                //talkUI.GetComponentInChildren<Button>().onClick.AddListener(Quest);
                talking = true;
            }
            else if(Input.GetKeyUp("e") && talking)
            {
                talking = false;
                talkUI.SetActive(false);
                YNButton.SetActive(false);
            }
        }

        if (talking && QuestGiver)
        {
            YNButton.SetActive(true);
        }

        foreach (GameObject i in EnemysToDie)
        {
            if (i == null)
            {
                EnemysToDie.Remove(i);
            }
        }

        if (questcomp)
        {
            Debug.Log("Quest Complete");
        }

        if (Questaccepted)
        {
            Quest();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            IStalkable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IStalkable = false;
            interact.SetActive(false);
            talkUI.SetActive(false);
            YNButton.SetActive(false);
            talking = false;
        }
    }

    public void AcceptQuest()
    {
        Questaccepted = true;
    }

    public void Quest()
    {
        if (GameObject.Find("InventoryManager"))
        {
            Debug.Log("Found");
        }

        if (QuestType == LayerOptions.Fetch)
        {
            if (GameObject.Find("InventoryManager").GetComponent<Inventory>())
            {
                Inventory Inven = GameObject.Find("InventoryManager").GetComponent<Inventory>();
                foreach (Item2 I in Inven.items)
                {
                    if (I.itemID == ItemNeeded)
                    {
                        questcomp = true;
                    }
                }
            }
        }
        if (QuestType == LayerOptions.Kill)
        {
            Debug.Log("KILL");
            foreach(GameObject i in EnemysToDie)
            {
                if(i == null)
                {
                    EnemysToDie.Remove(i);
                }
            }

            if(EnemysToDie.Count == 0)
            {
                questcomp = true;
            }
        }
    }

}
