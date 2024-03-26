using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public string ColourandRace = "FallenPurple";
    public string Addon;

    public Sprite playerspr;
    public Sprite addonspr;

    private void Update()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
