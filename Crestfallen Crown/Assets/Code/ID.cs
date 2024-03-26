using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ID : MonoBehaviour
{
    public int id = 0;
    public TMP_Text Name;
    public Image Image;
    public bool isweapon;
    public Sprite CometStaff;
    public Sprite BOD;
    public Sprite HP;
    SelectedITEM sel;
    GameObject info;
    [SerializeField]GameObject thisParent;
    public TMP_Text DMG;
    public TMP_Text ROF;
    public TMP_Text VAL;
    public TMP_Text REQ;
    public Item it;
    [SerializeField] Item comet;
    [SerializeField] Item BOX;
    [SerializeField] Item heart;



    private void Start()
    {
        Name = GameObject.Find("Name").GetComponent<TMP_Text>();
        DMG = GameObject.Find("DMG").GetComponent<TMP_Text>();
        ROF = GameObject.Find("COL").GetComponent<TMP_Text>();
        VAL = GameObject.Find("VAL").GetComponent<TMP_Text>();
        REQ = GameObject.Find("REQ").GetComponent<TMP_Text>();
        Image = GameObject.Find("ImageOFT").GetComponent<Image>();
        sel = GameObject.Find("SelectedOBJ").GetComponent<SelectedITEM>();
        it = this.GetComponent<ItemController>().item;
        thisParent = transform.parent.gameObject;
        info = this.gameObject;
    }

    public void Null()
    {
        sel.selected = null;
        Name.text = "Nothing";
        Image.sprite = null;
        DMG.text = "N/A";
        ROF.text = "N/A";
        VAL.text = "N/A";
        REQ.text = "N/A";
        it = null;
    }

    void DO() { 
    }

    public void INFO()
    {
        sel.EquipUI.enabled = false;
        sel.USEUI.enabled = false;

        if (id == 1)
        {
            //thisParent.GetComponent<Image>().enabled = false;
            sel.selected = thisParent;
            Name.text =  "Comet Staff";
            Image.sprite = CometStaff;
            DMG.text = "DMG: 3";
            ROF.text = "COL: mid";
            VAL.text = "VAL: 10 gold";
            REQ.text = "REQ: 10 Mag";
            it = comet;

        }
        else if(id == 2)
        {
            //thisParent.GetComponent<Image>().enabled = false;
            sel.selected = thisParent;
            Name.text = "Box of Destiny";
            Image.sprite = BOD;
            DMG.text = "DMG: 999";
            ROF.text = "COL: high";
            VAL.text = "VAL: 999 gold";
            REQ.text = "REQ: 2 Mag 4 STR";
            it = BOX;
        }
        else if(id == 3)
        {
            //thisParent.GetComponent<Image>().enabled = false;
            sel.selected = thisParent;
            Name.text = "Severed Heart";
            Image.sprite = HP;
            DMG.text = "Effect:";
            ROF.text = "Plus 20HP";
            VAL.text = "";
            REQ.text = "";
            it = heart;
        }
    }
}
