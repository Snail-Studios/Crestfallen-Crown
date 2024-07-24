// InventoryUIScript.cs
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryUIScript : MonoBehaviour
{
    //public TMP_Text inventoryText;
    public Inventory inventory;  // Assuming you have an Inventory2 script
    public GameObject ITEM;
    public Transform ItemContent;
    public Transform content;
    public GameObject invent;
    public Sprite NULLICON;
    GameObject DESC;
    public  bool isDESC;
    public Transform Slot1E;
    public Transform Slot2E;
    public GameObject Content;

    public GameObject selected;
    public TMP_Text Name;
    public TMP_Text Description;
    public Image sprite;
    public Item2 item2;
    public bool isweapon;
    public bool isarmour;
    public bool isuseable;
    public int damage;
    public int Armour;
    public int regen;
    public int Cooldown;
    public int Value;
    public GameObject ATK;
    Move2_0 player;

    GameObject EQ;
    bool EQOpen;
    TMP_Text DMG;
    TMP_Text Cool;
    TMP_Text VAL;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Move2_0>();
        EQ = GameObject.Find("EQ1/2");
        EQ.SetActive(false);
        DMG = GameObject.Find("DamageTXT").GetComponent<TMP_Text>();
        Cool = GameObject.Find("CooldownTXT").GetComponent<TMP_Text>();
        VAL = GameObject.Find("ValueTXT").GetComponent<TMP_Text>();
        content = GameObject.Find("Content").transform;
        DESC = GameObject.Find("DESC_Panel");
        DESC.SetActive(false);
        invent = GameObject.Find("Inventory");
        invent.SetActive(false);
        //UpdateInventoryUI();
    }



    public void DescriptOpen()
    {
        if (isDESC == false)
        {
            Debug.Log("open");
            DESC.SetActive(true);
            isDESC = true;

        }
        else
        {
            Debug.Log("closed");
            DESC.SetActive(false);
            isDESC = false;
        }
    }
    public void UpdateItemSelect(string name, string description, Sprite icon, int ID, GameObject Sel,bool weapon, bool armour, bool use, int dmg, int arm, int hp, int cooldown, int val, GameObject atk, Item2 it2)
    {
        Name.text = name;
        Description.text = description;
        sprite.sprite = icon;
        regen = hp;
        item2 = it2;
        damage = dmg;
        Armour = arm;
        selected = Sel;
        isweapon = weapon;
        isuseable = use;
        isarmour = armour;
        Cooldown = cooldown;
        Value = val;
        ATK = atk;

    }

    // Call this method to update the UI whenever the inventory changes
    public void UpdateInventoryUI()
    {
        // Clear existing UI text
        //inventoryText.text = "Inventory:\n";

        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        // Iterate through the items in the inventory and add them to the UI text
        foreach (Item2 item in inventory.items)
        {

            //inventoryText.text += item.itemName + "\n";
            GameObject obj = Instantiate(ITEM, ItemContent.position , Quaternion.identity);
            obj.transform.SetParent(content);
            obj.transform.localScale = new Vector3(1, 1, 1);
            obj.GetComponent<Image>().sprite = item.itemIcon;
            obj.GetComponentInChildren<TMP_Text>().text = item.itemName;
            obj.GetComponent<ItemSelect>().itemIcon = item.itemIcon; 
            obj.GetComponent<ItemSelect>().itemName = item.itemName; 
            obj.GetComponent<ItemSelect>().itemDescription = item.itemDescription; 
            obj.GetComponent<ItemSelect>().itemID = item.itemID; 
            obj.GetComponent<ItemSelect>().isweapon = item.isweapon; 
            obj.GetComponent<ItemSelect>().isarmour = item.isarmour; 
            obj.GetComponent<ItemSelect>().isuseable = item.isuseable;
            obj.GetComponent<ItemSelect>().Damage = item.Damage;
            obj.GetComponent<ItemSelect>().Armour = item.Armour;
            obj.GetComponent<ItemSelect>().HealthRegen = item.HealthRegen;
            obj.GetComponent<ItemSelect>().cooldown = item.cooldown;
            obj.GetComponent<ItemSelect>().value = item.VALUE;
            obj.GetComponent<ItemSelect>().ATK = item.ATK;
            obj.GetComponent<ItemSelect>().IT2 = item;

            // You can customize this to display additional item information
        }
    }

    public void OpenEquip()
    {
        if(EQOpen == false)
        {
            EQ.SetActive(true);
            EQOpen = true;
        }
        else
        {
            EQ.SetActive(false);
            EQOpen = false;
        }
    }

    

    public void OnApplicationQuit()
    {
        Transform Old = Slot2E.GetChild(0);
        inventory.AddItem(Old.GetComponent<ItemSelect>().IT2);

        GameObject Old2 = Slot1E.GetChild(0).gameObject;
        inventory.AddItem(Old2.GetComponent<ItemSelect>().IT2);
    }



}
