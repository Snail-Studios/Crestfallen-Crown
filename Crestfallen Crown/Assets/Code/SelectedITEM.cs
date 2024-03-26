using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedITEM : MonoBehaviour
{

    public GameObject selected;
    public bool selectedisweapon;
    public GameObject Slot1;
    public GameObject Slot2;
    public Canvas EquipUI;
    public Canvas USEUI;
    [SerializeField] GameObject Slot1equip;
    GameObject Slot2equip;
    public GameObject inven;
    public bool slect1 = false;
    public bool slect2 = false;
    public Weaponslots player;
    InventoryManager invenman;

    // Start is called before the first frame update
    void Start()
    {
        invenman = GameObject.Find("ItemManager").GetComponent<InventoryManager>();
        player = GameObject.Find("SlotMan").GetComponent<Weaponslots>();
    }

    private void Update()
    {

    }

    public void Equip()
    {
        selectedisweapon = selected.GetComponentInChildren<ID>().isweapon;
        if (selectedisweapon)
        {
            if(EquipUI.enabled == true)
            {
                EquipUI.enabled = false;
            }
            else if(EquipUI.enabled == false)
            {
                EquipUI.enabled = true;
            }

        }
        
        if(selectedisweapon == false)
        {
            if(USEUI.enabled == true)
            {
                USEUI.enabled = false;
            }
            else
            {
                USEUI.enabled = true;
            }
        }
    }

    public void Use()
    {
        GameObject.Find("DMG").GetComponent<TMP_Text>().text = "N/A";
        GameObject.Find("VAL").GetComponent<TMP_Text>().text = "N/A";
        GameObject.Find("COL").GetComponent<TMP_Text>().text = "N/A";
        GameObject.Find("REQ").GetComponent<TMP_Text>().text = "N/A";
        GameObject.Find("Name").GetComponent<TMP_Text>().text = "N/A";
        GameObject.Find("ImageOFT").GetComponent<Image>().sprite = null;
        invenman.Remove(selected.GetComponentInChildren<ID>().it);
        Destroy(selected);
    }

    public void refresh()
    {

    }

    public void slot1Equip()
    {
        selectedisweapon = selected.GetComponentInChildren<ID>().isweapon;
        //var selec = selected.GetComponent<Image>();
        if (selectedisweapon == true)
        {
            if (Slot1equip == null)
            {
                Debug.Log("Nothing");
                Slot1equip = selected;
                Slot1equip.transform.SetParent(Slot1.transform);
                Slot1equip.transform.position = Slot1.transform.position;
                Slot1equip.GetComponent<Image>().enabled = false;
                Slot1equip.GetComponentInChildren<TMP_Text>().enabled = false;
                Slot1equip.GetComponent<Button>().enabled = false;
                player.EQ1id = Slot1equip.GetComponentInChildren<ID>().id;
                invenman.Remove(Slot1equip.GetComponentInChildren<ID>().it);
                //Slot1equip.GetComponentInChildren<ID>().Null();
                //Slot1equip.GetComponentInChildren<ID>().id = 0;
            }
            else
            {
                Debug.Log("something");
                Slot1equip.transform.SetParent(inven.transform);
                invenman.add(Slot1equip.GetComponentInChildren<ID>().it);
                Slot1equip.GetComponent<Image>().enabled = true;
                Slot1equip.GetComponentInChildren<TMP_Text>().enabled = true;
                Slot1equip.GetComponent<Button>().enabled = true;
                Slot1equip = selected;
                Slot1equip.GetComponent<Image>().enabled = false;
                Slot1equip.GetComponentInChildren<TMP_Text>().enabled = false;
                Slot1equip.GetComponent<Button>().enabled = false;
                Slot1equip.transform.SetParent(Slot1.transform);
                Slot1equip.transform.position = Slot1.transform.position;
                player.EQ1id = Slot1equip.GetComponentInChildren<ID>().id;
                invenman.Remove(Slot1equip.GetComponentInChildren<ID>().it);
                //Slot1equip.GetComponentInChildren<ID>().Null();
                //Slot1equip.GetComponentInChildren<ID>().id = 0;
            }
        }
    }

    public void slot2Equip()
    {
        selectedisweapon = selected.GetComponentInChildren<ID>().isweapon;
        if (selectedisweapon == true)
        {
            if (Slot2equip == null)
            { 
                Debug.Log("Nothing");
                Slot2equip = selected;
                Slot2equip.transform.SetParent(Slot2.transform);
                Slot2equip.transform.position = Slot2.transform.position;
                Slot2equip.GetComponent<Image>().enabled = false;
                Slot2equip.GetComponentInChildren<TMP_Text>().enabled = false;
                Slot2equip.GetComponent<Button>().enabled = false;
                player.EQ2id = Slot2equip.GetComponentInChildren<ID>().id;
                invenman.Remove(Slot2equip.GetComponentInChildren<ID>().it);
                //Slot1equip.GetComponentInChildren<ID>().Null();
                //Slot1equip.GetComponentInChildren<ID>().id = 0;
            }
            else
            {
                Debug.Log("something");
                Slot2equip.transform.SetParent(inven.transform);
                invenman.add(Slot2equip.GetComponentInChildren<ID>().it);
                Slot2equip.GetComponent<Image>().enabled = true;
                Slot2equip.GetComponentInChildren<TMP_Text>().enabled = true;
                Slot2equip.GetComponent<Button>().enabled = true;
                Slot2equip = selected;
                Slot2equip.GetComponent<Image>().enabled = false;
                Slot2equip.GetComponentInChildren<TMP_Text>().enabled = false;
                Slot2equip.GetComponent<Button>().enabled = false;
                Slot2equip.transform.SetParent(Slot2.transform);
                Slot2equip.transform.position = Slot2.transform.position;
                player.EQ2id = Slot2equip.GetComponentInChildren<ID>().id;
                invenman.Remove(Slot2equip.GetComponentInChildren<ID>().it);
                //Slot1equip.GetComponentInChildren<ID>().Null();
                //Slot1equip.GetComponentInChildren<ID>().id = 0;
            }
        }

    }

}
