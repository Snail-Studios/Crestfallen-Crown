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
    public GameObject areatogo;
    [SerializeField]bool atplace = false;
    public List<GameObject> EnemysToDie = new List<GameObject>();
    public string completedDialouge;
    public bool questcomp = false;
    public bool Questaccepted = false;
    [SerializeField] string fetchdialouge;
    [SerializeField] string Killdialouge;
    [SerializeField] string Guiddialouge;
    [SerializeField] Transform questdone;

    bool hassent = false;

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
        if(QuestType == LayerOptions.Fetch)
        {
            dialouge =  fetchdialouge;
        }
        else if(QuestType == LayerOptions.Guide)
        {
            dialouge = Guiddialouge;
        }
        else if(QuestType == LayerOptions.Kill)
        {
            dialouge = Killdialouge;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hassent == false && questcomp)
        {
            hassent = true;
            GameObject.Find("QM").GetComponent<QuestManager>().AddNPC(this.gameObject);
        }

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
            if (Input.GetKeyUp("e") && talking == false && questcomp == false)
            {
                talkUI.SetActive(true);
                talkUI.GetComponentInChildren<TMP_Text>().text = dialouge;
                NPC.sprite = this.GetComponent<SpriteRenderer>().sprite;
                //talkUI.GetComponentInChildren<Button>().onClick.AddListener(Quest);
                talking = true;
            }
            else if(Input.GetKeyUp("e") && talking && questcomp == false)
            {
                talking = false;
                talkUI.SetActive(false);
                YNButton.SetActive(false);
            }
            else if (Input.GetKeyUp("e") && talking == false && questcomp)
            {
                talkUI.SetActive(true);
                talkUI.GetComponentInChildren<TMP_Text>().text = completedDialouge;
                NPC.sprite = this.GetComponent<SpriteRenderer>().sprite;
                talking = true;
                //YNButton.SetActive(false);
            }
            else if (Input.GetKeyUp("e") && talking && questcomp)
            {
                talking = false;
                talkUI.SetActive(false);
                YNButton.SetActive(false);
            }
        }

        if (talking && QuestGiver && questcomp == false)
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
            Questaccepted = true;
            Debug.Log("Quest Complete");
            transform.position = questdone.position;
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

        if(collision.name == areatogo.name)
        {
            atplace = true;
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
        if(QuestType == LayerOptions.Guide)
        {
            this.GetComponent<FollowMinion>().enabled = true;
            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

            // Remove constraints on the x-axis
            rb2d.constraints = rb2d.constraints & ~RigidbodyConstraints2D.FreezePositionX;
            rb2d.constraints = rb2d.constraints & ~RigidbodyConstraints2D.FreezePositionY;
        }
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
        if(QuestType == LayerOptions.Guide)
        {
            if (atplace)
            {
                questcomp = true;
                GetComponent<FollowMinion>().enabled = false;
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }

}
