using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSprite : MonoBehaviour
{
    public bool Spriteconisam = false;
    PlayerControler PC;
    public Movement move;
    public Image player;
    public Image addons;
    public Sprite Dwarf;
    public Sprite DwarfB;
    public Sprite DwarfP;
    public Sprite DwarfGRE;
    public Sprite Fallen;
    public Sprite FallenG;
    public Sprite FallenGRE;
    public Sprite FallenB;
    public Sprite Troll;
    public Sprite TrollB;
    public Sprite TrollG;
    public Sprite TrollP;
    public Sprite Elf;
    public Sprite ElfP;
    public Sprite ElfG;
    public Sprite ElfGRE;
    public Sprite Necromancer;
    public Sprite NecromancerG;
    public Sprite NecromancerGRE;
    public Sprite NecromancerB;
    public Sprite Chicken;
    public Sprite Poop;
    public Sprite Monocle;
    public Sprite BMonocle;
    public bool isDwarf;
    public bool isFallen;
    public bool isTroll;
    public bool isElf;
    public bool isNecromancer;
    public bool Green;
    public bool Grey;
    public bool Blue;
    public bool Purple;
    public string playerLook;
    // Start is called before the first frame update
    void Start()
    {
        if (Spriteconisam)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        PC = GameObject.Find("PlayerControler").GetComponent<PlayerControler>();
        FallenSel();
        addons.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (isFallen)
        {
            if (Purple)
            {
                player.sprite = Fallen;
            }
            else if (Green)
            {
                player.sprite = FallenGRE;
            }
            else if (Grey)
            {
                player.sprite = FallenG;
            }
            else if (Blue)
            {
                player.sprite = FallenB;
            }
        }
        else if (isDwarf)
        {
            if (Purple)
            {
                player.sprite = DwarfP;
            }
            else if (Green)
            {
                player.sprite = DwarfGRE;
            }
            else if (Grey)
            {
                player.sprite = Dwarf;
            }
            else if (Blue)
            {
                player.sprite = DwarfB;
            }
        }
        else if (isElf)
        {
            if (Purple)
            {
                player.sprite = ElfP;
            }
            else if (Green)
            {
                player.sprite = ElfGRE;
            }
            else if (Grey)
            {
                player.sprite = ElfG;
            }
            else if (Blue)
            {
                player.sprite = Elf;
            }
        }
        else if (isNecromancer)
        {
            if (Purple)
            {
                player.sprite = Necromancer;
            }
            else if (Green)
            {
                player.sprite = NecromancerGRE;
            }
            else if (Grey)
            {
                player.sprite = NecromancerG;
            }
            else if (Blue)
            {
                player.sprite = NecromancerB;
            }
        }
        if (isTroll)
        {
            if (Purple)
            {
                player.sprite = TrollP;
            }
            else if (Green)
            {
                player.sprite = Troll;
            }
            else if (Grey)
            {
                player.sprite = TrollG;
            }
            else if (Blue)
            {
                player.sprite = TrollB;
            }
        }

        List<string> trueVariables = new List<string>();

        if (isFallen)
        {
            if (Purple) trueVariables.Add("FallenPurple");
            if (Green) trueVariables.Add("FallenGreen");
            if (Grey) trueVariables.Add("FallenGrey");
            if (Blue) trueVariables.Add("FallenBlue");
        }
        else if (isDwarf)
        {
            if (Purple) trueVariables.Add("DwarfPurple");
            if (Green) trueVariables.Add("DwarfGreen");
            if (Grey) trueVariables.Add("DwarfGrey");
            if (Blue) trueVariables.Add("DwarfBlue");
        }
        else if (isElf)
        {
            if (Purple) trueVariables.Add("ElfPurple");
            if (Green) trueVariables.Add("ElfGreen");
            if (Grey) trueVariables.Add("ElfGrey");
            if (Blue) trueVariables.Add("ElfBlue");
        }
        else if (isNecromancer)
        {
            if (Purple) trueVariables.Add("NecromancerPurple");
            if (Green) trueVariables.Add("NecromancerGreen");
            if (Grey) trueVariables.Add("NecromancerGrey");
            if (Blue) trueVariables.Add("NecromancerBlue");
        }
        if (isTroll)
        {
            if (Purple) trueVariables.Add("TrollPurple");
            if (Green) trueVariables.Add("TrollGreen");
            if (Grey) trueVariables.Add("TrollGrey");
            if (Blue) trueVariables.Add("TrollBlue");
        }

        // Concatenate the true variable names into playerLook
        //playerLook = "player: " + string.Join(", ", trueVariables) + ", addons: " + addons.sprite.ToString();

        //PC.ColourandRace = string.Join(", ", trueVariables);
        //PC.Addon = addons.sprite.ToString();

        PC.playerspr = player.sprite;
        PC.addonspr = addons.sprite;
    }

    public void ColourBlue()
    {
        Blue = true;
        Green = false;
        Grey = false;
        Purple = false;
    }

    public void ColourGreen()
    {
        Blue = false;
        Green = true;
        Grey = false;
        Purple = false;
    }


    public void ColourGrey()
    {
        Blue = false;
        Green = false;
        Grey = true;
        Purple = false;
    }


    public void ColourPurple()
    {
        Blue = false;
        Green = false;
        Grey = false;
        Purple = true;
    }

    public void FallenSel()
    {
        player.sprite = Fallen;
        isFallen = true;
        isTroll = false;
        isNecromancer = false;
        isElf = false;
        isDwarf = false;
    }

    public void TrollSel()
    {
        player.sprite = Troll;
        isFallen = false;
        isTroll = true;
        isNecromancer = false;
        isElf = false;
        isDwarf = false;
    }

    public void NecroSel()
    {
        player.sprite = Necromancer;
        isFallen = false;
        isTroll = false;
        isNecromancer = true;
        isElf = false;
        isDwarf = false;
    }

    public void ElfSel()
    {
        player.sprite = Elf;
        isFallen = false;
        isTroll = false;
        isNecromancer = false;
        isElf = true;
        isDwarf = false;
        if (Blue)
        {
            player.sprite = Elf;
        }
        else if (Grey)
        {
            player.sprite = ElfG;
        }
        else if (Green)
        {
            player.sprite = ElfGRE;
        }
        else if (Purple)
        {
            player.sprite = ElfP;
        }
    }

    public void DwarfSel()
    {
        player.sprite = Dwarf;
        isFallen = false;
        isTroll = false;
        isNecromancer = false;
        isElf = false;
        isDwarf = true;
    }

    public void MonocleAddon()
    {
        if(isTroll || isNecromancer)
        {
            addons.enabled = true;
            addons.sprite = BMonocle;
        }
        else
        {
            addons.enabled = true;
            addons.sprite = Monocle;
        }
    }

    public void PoopAddon()
    {
        addons.enabled = true;
        addons.sprite = Poop;
    }

    public void ChickenAddon()
    {
        addons.enabled = true;
        addons.sprite = Chicken;
    }

    public void NON()
    {
        addons.enabled = false;
        addons.sprite = null;
        PC.addonspr = null;
    }

    public void startgame()
    {
        SceneManager.LoadScene("VillageOfBanished");
        Debug.Log(player.sprite.ToString());
    }

}
