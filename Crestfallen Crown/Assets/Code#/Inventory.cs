// Inventory.cs
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IDataPersistence
{
    public List<Item2> items = new List<Item2>();

    public void AddItem(Item2 item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item2 item)
    {
        items.Remove(item);
    }

    public void LoadData(GameData data)
    {
        this.items = data.items;
    }

    public void SaveData(ref GameData data)
    {
        data.items = this.items;
    }
}
