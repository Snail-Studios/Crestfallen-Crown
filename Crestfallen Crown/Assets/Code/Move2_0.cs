using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move2_0 : MonoBehaviour, IDataPersistence
{
    #region variables
    //movement
    public float dodgeCooldown = 0f; // Adjust the cooldown time as needed
    private bool isDodging = false;
    Vector2 movement;
    [SerializeField] public float move;
    private Rigidbody2D rb;


    //character_check

    public bool IsFallen = false;
    public bool IsElf = false;
    public bool IsDwarf = false;
    public bool IsNecromancer = false;
    public bool IsTroll = false;
    public PlayerControler PC;
    public SpriteRenderer SR;
    public SpriteRenderer ASR;
    PlayerSprite PS;
    //misc
    public static Move2_0 instance;
    public Camera cam;
    public Animator anim;
    bool inMech = false;
    public GameObject[] Array;

    //==inventory/equip==//

    public int HP = 25;

    public InventoryUIScript inventoryUIScript;
    public Inventory inventory;
    public Weapon currentWeapon;
    public Armor currentArmor;

    public GameObject inven;
    public bool invenopen = false;

    public float cooldownTime = 1f;
    public float timer = 0f;
    public bool isCooldown = false;

    public float cooldownTime2 = 1f;
    public float timer2 = 0f;
    public bool isCooldown2 = false;

    public int Cooldown;
    public int Damage;
    public GameObject Atk;

    public int Cooldown2;
    public int Damage2;
    public GameObject Atk2;

    public Image cooldownImage;
    public Image cooldownImage2;

    public bool isATK1 = false;
    public bool isATK2 = false;

    //stats
    //public int Magic_Stat = 10;
    //public int Strength_Stat = 10;
    //public int Stealth_Stat = 10;
    //public int Inteligence_Stat = 10;
    //public int Connection_Stat = 10;
    //public GameObject Magic_text;
    //public GameObject Strength_text;
    //public GameObject Stealth_text;
    //public GameObject Inteligence_text;
    //public GameObject Connection_tex;
    #endregion
    #region setting variables
    private void Awake()
    {
        if (GameObject.Find("PlayerControler") == null)
        {
            SceneManager.LoadScene("StartScreen");
        }
        inven = GameObject.Find("Inventory");
        PC = GameObject.Find("PlayerControler").GetComponent<PlayerControler>();
        //if (!PC.playerspr == null)
        //{
            //SR.sprite = PC.playerspr;
        //}
        PS = GameObject.Find("SpriteCon").GetComponent<PlayerSprite>();
    }

    void OnEnable()
    {
        SR = gameObject.GetComponent<SpriteRenderer>();
        ASR = GameObject.Find("Addons'").GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //SR.sprite = PC.playerspr;
        //ASR.sprite = PC.addonspr;
        //Magic_text = GameObject.Find("Magic");
        //Strength_text = GameObject.Find("Strength");
        //Stealth_text = GameObject.Find("Stealth");
        //Inteligence_text = GameObject.Find("Inteligence");
        //Connection_tex = GameObject.Find("Connection");
        rb = GetComponent<Rigidbody2D>();
        if (instance != null && instance != this)
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
        else
        {
            // Set the instance to this GameObject
            instance = this;
        }
        //inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        inventoryUIScript = GameObject.Find("UImanager").GetComponent<InventoryUIScript>();
        anim = GetComponent<Animator>();
        cooldownImage.fillAmount = 0;
        cooldownImage2.fillAmount = 0;

    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PC.playerspr.ToString());


        if (Input.GetKeyDown(KeyCode.Space) && !isDodging && !inMech)
        {
            StartCoroutine(Dodge());
        }

        PC.playerspr = SR.sprite;

        if (isCooldown)
        {
            timer -= Time.deltaTime;

            if (cooldownImage != null)
            {
                cooldownImage.fillAmount = timer / cooldownTime / Cooldown;
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
                cooldownImage2.fillAmount = timer2 / cooldownTime2 / Cooldown2;
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
        //Magic_text.GetComponent<TMP_Text>().SetText("MAG: " + Magic_Stat);
        //Strength_text.GetComponent<TMP_Text>().SetText("STR: " + Strength_Stat);
        //Stealth_text.GetComponent<TMP_Text>().SetText("STL: " + Stealth_Stat);
        //Inteligence_text.GetComponent<TMP_Text>().SetText("INT: " + Inteligence_Stat);
        //Connection_tex.GetComponent<TMP_Text>().SetText("CON: " + Connection_Stat);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        rb.velocity = new Vector2(0.0f, 0.0f);

        rb.MovePosition(rb.position + movement * move * Time.fixedDeltaTime);

        if (Input.GetKey("1") && isCooldown == false && inMech == false)
        {
            Attack(Cooldown, Damage, Atk);
        }

        if (Input.GetKey("2") && isCooldown2 == false && inMech == false)
        {
            Attack2(Cooldown2, Damage2, Atk2);
        }

        if (Input.GetKeyDown("tab"))
        {
            Debug.Log("in");
            if (invenopen == false)
            {
                inven.SetActive(true);
                invenopen = true;
                inventoryUIScript.UpdateInventoryUI();
            }
            else
            {
                inven.SetActive(false);
                invenopen = false;
            }
        }

        if(HP <= 0)
        {
            Debug.Log("dead");
        }

    }

    public void PickupItem(Item2 item)
    {
        // Add the item to the inventory
        inventory.AddItem(item);

        // Optionally, you can provide feedback to the player (e.g., display a message)
        Debug.Log("Picked up: " + item.itemName);

        inventoryUIScript.UpdateInventoryUI();
    }

    IEnumerator Dodge()
    {
        isDodging = true;

        // Save the current speed for restoration after the dodge
        float originalMoveSpeed = move;

        // Modify the movement speed during the dodge
        move *= 2f; // You can adjust the dodge speed multiplier

        // Perform the dodge movement (you may want to add animation)
        Vector2 dodgeDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = dodgeDirection * move;

        // Wait for a short duration for the dodge
        yield return new WaitForSeconds(0.5f); // You can adjust the dodge duration

        // Restore the original movement speed
        move = originalMoveSpeed;

        // Reset velocity and cooldown
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dodgeCooldown);
        isDodging = false;
    }

    #region attacks
    void Attack(int cooldown, int damage, GameObject ATK)
    {
        //if ()
        //{
            //return;
        //}
        //else
        //{
        Debug.Log(damage);
        Debug.Log(cooldown);
        Debug.Log(ATK);
        isCooldown = true;
        timer = cooldown;

        // Get the mouse position in screen coordinates
        Vector3 mousePosScreen = Input.mousePosition;

        // Convert the screen coordinates to world coordinates, including the camera's movement
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosScreen.x, mousePosScreen.y, Mathf.Abs(Camera.main.transform.position.z)));

        // Calculate the direction from the object to the mouse
        Vector3 direction = mousePos - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the object towards the mouse
        // Instantiate the object at the specified position with no rotation
         GameObject obj = Instantiate(ATK, GameObject.Find("Shot").transform.position, Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), 1));

        if (obj.CompareTag("Melee"))
        {
            // Set the object as a child of this transform
            obj.transform.SetParent(transform);
            obj.transform.position = transform.position;
            // Destroy the object after a delay
            Destroy(obj, 0.7f);
        }
        if (obj.CompareTag("Magic"))
        {
            Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;

            // Set the velocity of the object in the direction of its rotation
            float speed = 5f; // You can adjust the speed as needed
            rb.velocity = obj.transform.right * speed;
        }
        if (obj.CompareTag("Arrow"))
        {
            Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;

            // Set the velocity of the object in the direction of its rotation
            float speed = 5f; // You can adjust the speed as needed
            rb.velocity = obj.transform.right * speed;
        }
        if (obj.CompareTag("Mech"))
        {
            inMech = true;
        }
        if (obj.CompareTag("Minion"))
        {
            obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Attack2(int cooldown, int damage, GameObject ATK)
    {
        Debug.Log(damage);
        Debug.Log(cooldown);
        Debug.Log(ATK);
        isCooldown2 = true;
        timer2 = cooldown;

        // Get the mouse position in screen coordinates
        Vector3 mousePosScreen = Input.mousePosition;

        // Convert the screen coordinates to world coordinates, including the camera's movement
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosScreen.x, mousePosScreen.y, Mathf.Abs(Camera.main.transform.position.z)));

        // Calculate the direction from the object to the mouse
        Vector3 direction = mousePos - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the object towards the mouse
        // Instantiate the object at the specified position with no rotation
        GameObject obj = Instantiate(ATK, GameObject.Find("Shot").transform.position, Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), 1));

        if (obj.CompareTag("Melee"))
        {
            // Set the object as a child of this transform
            obj.transform.SetParent(transform);
            obj.transform.position = transform.position;
            // Destroy the object after a delay
            Destroy(obj, 0.7f);
        }
        if (obj.CompareTag("Magic"))
        {
            Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;

            // Set the velocity of the object in the direction of its rotation
            float speed = 5f; // You can adjust the speed as needed
            rb.velocity = obj.transform.right * speed;
        }
        if (obj.CompareTag("Arrow"))
        {
            Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;

            // Set the velocity of the object in the direction of its rotation
            float speed = 5f; // You can adjust the speed as needed
            rb.velocity = obj.transform.right * speed;
        }
        if (obj.CompareTag("Mech"))
        {
            inMech = true;
        }
        if (obj.CompareTag("Minion"))
        {
            obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Equipslot1(int cooldown, int damage, GameObject ATK)
    {
        Cooldown = cooldown;
        timer = cooldown;
        Damage = damage;
        Atk = ATK;
    }

    public void Equipslot2(int cooldown, int damage, GameObject ATK)
    {
        Cooldown2 = cooldown;
        timer2 = cooldown;
        Damage2 = damage;
        Atk2 = ATK;
        //Attack2(cooldown, damage, ATK);
    }

    public IEnumerator ATK1(int cool, int dmg, GameObject shoot)
    {
        Debug.Log("ATK");
        isATK1 = true;
        yield return new WaitForSeconds(cool);
        isATK1 = false;
        Debug.Log("Done");
        //isCooldown = true;
    }

    public IEnumerator ATK2(int cool, int dmg, GameObject shoot)
    {
        Debug.Log("ATK");
        isATK2 = true;
        //isCooldown2 = true;
        yield return new WaitForSeconds(cool);
        isATK2 = false;
        Debug.Log("Done");
    }

    public void PDMG(int damage)
    {
        if (!isDodging)
        {
            HP -= damage;
            StartCoroutine(Invincible());
            if (HP <= 0)
            {
                Debug.Log("DED");
            }
        }
    }

    public IEnumerator Invincible()
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
        Physics2D.IgnoreLayerCollision(3, 2, true);
        yield return new WaitForSeconds(0.6f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        Physics2D.IgnoreLayerCollision(3, 2, false);
    }
    #endregion

    #region Data
    public void LoadData(GameData data)
    {
        SR = this.GetComponent<SpriteRenderer>();
        this.transform.position = data.playerPosition;
        if(data.playerSPR == null)
        {
            SetSprite(PC.playerspr);
        }
        else
        {
            SR.sprite = data.playerSPR;
        }

        if (data.addonSPR == null)
        {
            ASR.sprite = PC.addonspr;
            Debug.Log("new Char");
        }
        else
        {
            ASR.sprite = data.addonSPR;
            Debug.Log("old Char");
        }
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
        data.playerSPR = this.SR.sprite;
        data.addonSPR = ASR.sprite;
        Debug.Log(data.playerSPR);
    }

    void SetSprite(Sprite SPR)
    {
        SR.sprite = SPR;
    }

    #endregion
}
