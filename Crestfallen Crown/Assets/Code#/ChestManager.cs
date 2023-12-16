using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestManager : MonoBehaviour, IDataPersistence
{
    public List<GameObject> chests = new List<GameObject>();
    public List<string> chestname = new List<string>();
    
    void Start()
    {

    }

    public void AddChest(GameObject newchest)
    {
        chests.Add(newchest);
        Debug.Log("Added");
    }

    public void RemoveChest(GameObject newchest)
    {
        chests.Remove(newchest);
    }


    public void SaveData(ref GameData data)
    {
        foreach (GameObject i in chests)
        {
            chestname.Add(i.name);
        }
        data.chests = chestname;
    }
    public void LoadData(GameData data)
    {
        foreach(string i in data.chests)
        {
            chests.Add(GameObject.Find(i));
        }
        foreach(GameObject i in chests)
        {
            i.GetComponent<Chest>().IsOpened = true;
        }
    }

}
