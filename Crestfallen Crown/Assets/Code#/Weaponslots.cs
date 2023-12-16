using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class Weaponslots : MonoBehaviour
{

    private Camera maincam;
    private Vector3 mousepos;
    public int EQ1id = 0;
    public int EQ2id = 0;
    SelectedITEM sele;
    GameObject equiped;
    GameObject player;
    public GameObject CommetATK;
    [SerializeField] GameObject BOXATK;

    public Image cooldownImage;
    public Image cooldownImage2;

    public float cooldownTime = 1f;
    private float timer = 0f;
    private bool isCooldown = false;

    public float cooldownTime2 = 1f;
    private float timer2 = 0f;
    private bool isCooldown2 = false;


    // Start is called before the first frame update
    void Start()
    {
        if (cooldownImage != null)
        {
            cooldownImage.fillAmount = 0f; 
        }

        if (cooldownImage2 != null)
        {
            cooldownImage2.fillAmount = 0f;
        }

        sele = GameObject.Find("SelectedOBJ").GetComponent<SelectedITEM>();
        equiped = GameObject.Find("PlayerEquip");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (isCooldown)
        {
            timer -= Time.deltaTime;

            if (cooldownImage != null)
            {
                cooldownImage.fillAmount = timer / cooldownTime;
            }

            if (timer <= 0f)
            {
                isCooldown = false;
                timer = 0f;

                if (cooldownImage != null)
                {
                    cooldownImage.fillAmount = 0f;
                }
            }
        }

        if (isCooldown2)
        {
            timer2 -= Time.deltaTime;

            if (cooldownImage2 != null)
            {
                cooldownImage2.fillAmount = timer2 / cooldownTime2;
            }

            if (timer2 <= 0f)
            {
                isCooldown2 = false;
                timer2 = 0f;

                if (cooldownImage2 != null)
                {
                    cooldownImage2.fillAmount = 0f;
                }
            }
        }

        if (Input.GetKey("1"))
        {
            //if (EQ1id == 1)
            //{
                if (!isCooldown)
                {
                    PerformAttack();

                    StartCooldown();
                }
                else
                {
                    Debug.Log("Cooldown in progress. Wait for it!");
                }
            //}

        }

        if (Input.GetKey("2"))
        {
            if (!isCooldown2)
            {
                PerformAttack2();

                StartCooldown2();
            }
            else
            {
                Debug.Log("Cooldown in progress. Wait for it!");
            }
        }
    }

    void PerformAttack()
    { 
         if (EQ1id == 1)
         {
             GameObject atk = Instantiate(CommetATK, GameObject.Find("Shot").transform.position, GameObject.Find("Aim").transform.rotation);
             Rigidbody2D rb = atk.GetComponent<Rigidbody2D>();
             rb.AddForce(GameObject.Find("Aim").transform.right * 4, ForceMode2D.Impulse);
             Debug.Log(EQ1id);
         }
         if(EQ1id == 2)
         {
            GameObject atk = Instantiate(BOXATK, GameObject.Find("Shot").transform.position, GameObject.Find("Aim").transform.rotation);
            Rigidbody2D rb = atk.GetComponent<Rigidbody2D>();
            rb.AddForce(GameObject.Find("Aim").transform.right * 4, ForceMode2D.Impulse);
            Debug.Log(EQ1id);
        }
    }


    void PerformAttack2()
    {
        if (EQ2id == 1)
        {
            GameObject atk = Instantiate(CommetATK, GameObject.Find("Shot").transform.position, GameObject.Find("Aim").transform.rotation);
            Rigidbody2D rb = atk.GetComponent<Rigidbody2D>();
            rb.AddForce(GameObject.Find("Aim").transform.right * 4, ForceMode2D.Impulse);
            Debug.Log(EQ1id);
        }
        if (EQ2id == 2)
        {
            GameObject atk = Instantiate(BOXATK, GameObject.Find("Shot").transform.position, GameObject.Find("Aim").transform.rotation);
            Rigidbody2D rb = atk.GetComponent<Rigidbody2D>();
            rb.AddForce(GameObject.Find("Aim").transform.right * 4, ForceMode2D.Impulse);
            Debug.Log(EQ1id);
        }
    }

    void StartCooldown()
    {
        if(EQ1id == 1)
        {
            timer = 0.5f;
            cooldownTime = 0.5f;
            isCooldown = true;
        }
        if(EQ1id == 2)
        {
            timer = 3;
            cooldownTime = 3;
            isCooldown = true;
        }

    }

    void StartCooldown2()
    {
        if (EQ2id == 1)
        {
            timer2 = 0.5f;
            cooldownTime2 = 0.5f;
            isCooldown2 = true;
        }
        if (EQ2id == 2)
        {
            timer2 = 3;
            cooldownTime2 = 3;
            isCooldown2 = true;
        }

    }

}
