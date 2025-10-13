using UnityEngine;
using Unity.Services.Lobbies;
using Sirenix.OdinInspector;
using Unity.Services.Lobbies.Models;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using System.Collections.Generic;

public class TestLobby : MonoBehaviour
{
    public Lobby HostLobby;
    public Lobby JoinLobby;
    private float heartBeatTimer;
    private async void Start()
    {
        //await UnityServices. InitializeAsync();
    }
    private void Update()
    {
        HandleLobbyHeartBeat();
    }
    public async void HandleLobbyHeartBeat()
    {
        if (HostLobby != null)

            heartBeatTimer -= Time.deltaTime;
        if(heartBeatTimer < 0)
        {
            float heartBeatTimerMax = 15;
            heartBeatTimer = heartBeatTimerMax;
            await LobbyService.Instance.SendHeartbeatPingAsync(HostLobby.Id);
        }
    }



    [Button]
    private async void CreateLobby(string lobbyName , int maxPlayers ,bool isPrivate, string gameMode = "CTF" ,string map = "Peru")
    {
        try
        {
            CreateLobbyOptions options = new CreateLobbyOptions()
            {

                IsPrivate = isPrivate,
                Player = GetPlayer().Result,

                Data = new Dictionary<string, DataObject>
                {
                    {"GameMode", new DataObject(DataObject. VisibilityOptions. Public, gameMode) },
                    { "Map", new DataObject(DataObject.VisibilityOptions.Public, map) },

                }
            };

                Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);

                HostLobby = lobby;
                JoinLobby = HostLobby;
                Debug.Log("Partida creada" + lobby.Name + "Max player : " + lobby.MaxPlayers + "Joincode: " + lobby.LobbyCode);

            }
        catch(LobbyServiceException ex)
        {
            Debug.LogException(ex);
        }
       

    }
    [Button]
    public async void ListLobbies()
    {
        try
        {
            QueryResponse queryResponse = await LobbyService.Instance.QueryLobbiesAsync();
            Debug.Log("Se encontraron los lobbies + " + queryResponse.Results.Count);

            foreach (Lobby lobby in queryResponse.Results)
            {
                Debug.Log("Lobby Name: " + lobby.Name+ " Max player : " + lobby.MaxPlayers + "joincode" + lobby.LobbyCode);
            }
        }
        catch (LobbyServiceException ex)
        {
            Debug.LogException(ex);
        }


    }
    public async void JoinLobbyByCode(string lobbyCode) 
    {
        try
        {
            JoinLobbyByCodeOptions joinLobbyByCodeOptions = new JoinLobbyByCodeOptions()
            {
                Player = GetPlayer().Result
            };

           Lobby lobby =  await LobbyService.Instance.JoinLobbyByCodeAsync(lobbyCode);
            JoinLobby = lobby;
            Debug.Log("t uniste al lobby " + lobbyCode);
        }
        catch (LobbyServiceException ex) 
        {
            Debug.LogException(ex);
        }

       
    }

    public void PrintPlayer()
    {
        PrintPlayers(HostLobby);
    }
    public void PrintPlayers(Lobby lobby)
    {
        Debug.Log("Lobby Name: " + lobby.Name + " Max player : " + lobby.MaxPlayers + "joincode" );
        foreach(Player player in lobby.Players)
        {
            Debug.Log(player.Id + "");
        }
    }
    public async Task<Player> GetPlayer()
    {
        var nickName = await AuthenticationService.Instance.GetPlayerNameAsync();
        return new Player
        {
            Data = new Dictionary<string, PlayerDataObject>
            {
                {"PlayerName" , new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, nickName)}
            }
        };
    }





        
}
