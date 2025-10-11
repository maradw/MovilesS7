using NUnit.Framework;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine;
using System.Threading.Tasks;
public class AdvanceSave : MonoBehaviour
{
    [SerializeField]private PlayerData playerData;
    private async void Start()
    {
        await UnityServices.InitializeAsync();
    }
    [Button]
    public async void Test()
    {
        var name = await AuthenticationService.Instance.GetPlayerNameAsync();
        print("Advance save" + name);
    }
    [Button]
    public async Task SavePlayerData()
    {
        var playerDataJson = JsonUtility.ToJson(playerData);
        await CloudSaveService.Instance.Data.Player.SaveAsync(
            new Dictionary<string, object> { { "player_profile", playerDataJson } });
    }
    [Button]
    public async Task LoadPlayerData()
    {
        var key = new HashSet<string>() { "player_profile" };
        var data = await CloudSaveService.Instance.Data.Player.LoadAsync(key);

        if (data.TryGetValue("player_profile", out var profile))
        {
            string json = profile.Value.GetAs<string>();
            PlayerData loadPlayerData = JsonUtility.FromJson<PlayerData>(json);
            SetData(loadPlayerData);
        }
    }

    public void SetData(PlayerData newData)
    {
        playerData = newData;
    }
    public async Task SaveDataAndQuit()
    {
        await SavePlayerData();
        Application.Quit();
    }

    ////
    ///
    public PlayerData GetData() => playerData;
}

[Serializable]
public class PlayerData
{
    public string characterName;
    public int level;
    public int gold;
    public int schemaVersion = 1;

    // Nuevos datos del sistema de experiencia
    public int currentClicks;
    public int abilityLevel;
    public int strengthLevel;
    public int armorLevel;
    public int fortuneLevel;
    public int damageLevel;

    public List<ItemData> Inventory = new();

}
[Serializable]
public class ItemData
{
    public string ItemId;
    public int quantity;
}
