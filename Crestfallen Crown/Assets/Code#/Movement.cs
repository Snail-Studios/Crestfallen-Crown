using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //movement

    Vector2 movement;
    [SerializeField] public float move;
    private Rigidbody2D rb;


    //character_check

    public bool IsFallen = false;
    public bool IsElf = false;
    public bool IsDwarf = false;
    public bool IsNecromancer = false;
    public bool IsTroll = false;

    //misc

    public Animator anim;

    //stats
    public int Magic_Stat = 10;
    public int Strength_Stat = 10;
    public int Stealth_Stat = 10;
    public int Inteligence_Stat = 10;
    public int Connection_Stat = 10;
    public GameObject Magic_text;
    public GameObject Strength_text;
    public GameObject Stealth_text;
    public GameObject Inteligence_text;
    public GameObject Connection_tex;

    //inventory

    public bool canpickup;
    public GameObject inven;
    public bool invenopen = false;
    public InventoryManager IM;

    //weapons

    public GameObject Slot1E;
    public GameObject Slot2E;
    public int EQ1 = 0;
    public int EQ2 = 0;
    SelectedITEM sele;

    // Start is called before the first frame update
    void Start()
    {
        inven = GameObject.Find("Inventory");
        Slot1E = GameObject.Find("Slot1");
        Slot2E = GameObject.Find("Slot2");
        Magic_text = GameObject.Find("Magic");
        Strength_text = GameObject.Find("Strength");
        Stealth_text = GameObject.Find("Stealth");
        Inteligence_text = GameObject.Find("Inteligence");
        Connection_tex = GameObject.Find("Connection");
        //sele = GameObject.Find("SelectedOBJ").GetComponent<SelectedITEM>();
        //inven.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Magic_text.GetComponent<TMP_Text>().SetText("MAG: " + Magic_Stat);
        //Strength_text.GetComponent<TMP_Text>().SetText("STR: " + Strength_Stat);
        //Stealth_text.GetComponent<TMP_Text>().SetText("STL: " + Stealth_Stat);
        //Inteligence_text.GetComponent<TMP_Text>().SetText("INT: " + Inteligence_Stat);
        //Connection_tex.GetComponent<TMP_Text>().SetText("CON: " + Connection_Stat);

        Debug.Log(canpickup);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        rb.velocity = new Vector2(0.0f, 0.0f);

        rb.MovePosition(rb.position + movement * move * Time.fixedDeltaTime);


    }
}
