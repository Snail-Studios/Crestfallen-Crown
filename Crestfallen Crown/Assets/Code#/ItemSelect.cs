using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{
    InventoryUIScript UI;

    public string itemName;
    public int itemID;
    public string itemDescription;
    public Sprite itemIcon;
    public bool isweapon;
    public bool isarmour;
    public bool isuseable;
    public int Damage;
    public int Armour;
    public int HealthRegen;
    public int cooldown;
    public int value;
    public GameObject ATK;
    public Item2 IT2;


    private void Awake()
    {
        UI = GameObject.Find("UImanager").GetComponent<InventoryUIScript>();
    }
    public void Select()
    {
        Debug.Log("Selected");
        UI.UpdateItemSelect(itemName, itemDescription, itemIcon, itemID, this.gameObject, isweapon, isarmour, isuseable, Damage, Armour, HealthRegen, cooldown, value, ATK, IT2);
    }
}
