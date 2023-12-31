using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public GameObject Name;
    public GameObject Image;

    private void Awake()
    {
        instance = this;
    }

    public void add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("itemIcon").GetComponent<Image>();
            var ID = obj.transform.Find("IDStore").GetComponent<ID>();

            ID.id = item.id;
            itemName.text = item.Name;
            itemIcon.sprite = item.icon;
            ID.isweapon = item.IsWeapon;
            
        }
    }

    private void Update()
    {
        //ListItems();
    }


}
