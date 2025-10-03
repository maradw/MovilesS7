using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
       #if UNITY_EDITOR
       UnityEditor.EditorApplication.isPlaying = false;

       #else
            Application.Quit();
       #endif
    }
    public void Menu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
