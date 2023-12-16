using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public string Name;
    public int id;
    public int value;
    public Sprite icon;
    public bool IsWeapon = false;
    public int damage;
    public float Cooldown;
}
