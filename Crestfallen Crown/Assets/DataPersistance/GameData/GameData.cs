using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public List<Item2> items = new List<Item2>();
    public Sprite playerSPR;
    public Sprite addonSPR;
    public Vector3 playerPosition;
    public GameObject SL1;
    public GameObject SL2;
    public List<string> chests = new List<string>();
    public List<string> completequests = new List<string>();


    public GameData()
    {
        playerPosition = new Vector3 (-107, -1, 0);
        items = new List<Item2>();
        chests = new List<string>();
        playerSPR = null;
        addonSPR = null;
        SL1 = null;
        SL2 = null;
        foreach (string i in chests)
        {
            Debug.Log(i);
        }
        foreach (string i in completequests)
        {
            Debug.Log(i);
        }
    }
}
