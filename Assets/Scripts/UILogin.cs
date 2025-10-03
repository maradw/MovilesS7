using System;
using TMPro;
using Unity.Services.Authentication;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public partial class UILogin : MonoBehaviour
{
    [SerializeField] private Transform loginPanel;
    [SerializeField] private Transform userPanel;

    [SerializeField] private Button loginButton;
    [SerializeField] private TMP_Text playerIDTxt;
    [SerializeField] private TMP_Text playerNameTxt;

    [SerializeField] private TMP_InputField UpdateNameIF;
    [SerializeField] private Button updateNameBtn;

    [SerializeField] private Button changeNameButton;
    [SerializeField] private UnityPlayerAuth unityPlayerAuth;

    [SerializeField] GameObject mainMenu;
    void Start()
    {
        loginPanel.gameObject.SetActive(true);
        userPanel.gameObject.SetActive(false);
        changeNameButton.gameObject.SetActive(false);
        mainMenu.SetActive(false);
    }
    private void OnEnable()
    {
        loginButton?.onClick.AddListener(LoginButton);
        unityPlayerAuth.OnSingedIn += UnityPlayerOnSignedIn;

        updateNameBtn.onClick.AddListener(UpdateName);
        unityPlayerAuth.OnUpdateName += UpdateNameVisual;
    }

    

    private async void UpdateName()
    {
        await unityPlayerAuth.UpdateName(UpdateNameIF.text);
    }
    private void UpdateNameVisual(string newName)
    {
        playerNameTxt.text = newName;
    }
    private void UnityPlayerOnSignedIn(PlayerInfo playerInfo, string PlayerName)
    {
        loginPanel.gameObject.SetActive(false);
        changeNameButton.gameObject.SetActive(true);
        userPanel.gameObject.SetActive(true);
        mainMenu.SetActive(true);
        playerIDTxt.text = "ID: " + playerInfo.Id;
        playerNameTxt.text = PlayerName;
    }

    private async void LoginButton()
    {
        await unityPlayerAuth.InitSignIn();
        
    }

    private void OnDisable()
    {
        loginButton?.onClick.RemoveListener(LoginButton);
        unityPlayerAuth.OnSingedIn -= UnityPlayerOnSignedIn;
    }
}
