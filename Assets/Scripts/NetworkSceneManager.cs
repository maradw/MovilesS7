using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkSceneManager : MonoBehaviour
{
    private void Awake()
    {

            if (NetworkManager.Singleton == null) return;
            NetworkManager.Singleton.SceneManager.OnSceneEvent += HandleSceneEvent;
    }
    private void OnDestroy()
    {
        if (NetworkManager.Singleton == null) return;
        NetworkManager.Singleton.SceneManager.OnSceneEvent -= HandleSceneEvent;
    }


    void HandleSceneEvent(SceneEvent sceneEvent)
    {
        switch (sceneEvent.SceneEventType)
        {
            case SceneEventType.LoadComplete:
                Debug.Log("Termino de cargar" + sceneEvent.SceneName + " ,");
            break;

            case SceneEventType.LoadEventCompleted:
                Debug.Log("todos terminaron de cargar" + sceneEvent.SceneName + " ,");
                break;

            default:
                break;
        }
    }
    public void LoadGameScene(string sceneName)
    {
        if (!NetworkManager.Singleton.IsHost)
        {
            Debug.Log("Solo el host puede cambiar de escena");
            return;
        }
        NetworkManager.Singleton.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }














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
