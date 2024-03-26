using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour, IDataPersistence
{
    public List<GameObject> quests = new List<GameObject>();
    public List<string> questsname = new List<string>();

    public void AddNPC(GameObject NPC)
    {
        quests.Add(NPC);
        Debug.Log("Added");
    }

    public void SaveData(ref GameData data)
    {
        foreach (GameObject i in quests)
        {
            questsname.Add(i.name);
        }
        data.completequests = questsname;
    }

    public void LoadData(GameData data)
    {
        foreach (string i in data.completequests)
        {
            quests.Add(GameObject.Find(i));
        }
        foreach (GameObject i in quests)
        {
            i.GetComponent<NPC_Talk>().questcomp = true;
        }
    }
}
