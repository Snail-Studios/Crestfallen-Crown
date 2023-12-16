using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnNewGame()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("CharacterCreation");
        Debug.Log("New");
    }
    public void OnContinueGame()
    {
        Debug.Log("continue");
        SceneManager.LoadSceneAsync("VillageOfBanished");
    }
}
