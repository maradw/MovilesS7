using UnityEngine;
using System;
using Unity.Services.CloudSave;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class CloudSave : MonoBehaviour
{
    [Button]
    public async void SaveData(string key, string value)
    {
        var playerData = new Dictionary<string, object>()
        {
            {key, value}
        };

        await CloudSaveService.Instance.Data.Player.SaveAsync(playerData);
    }
    [Button]
    public async void LoadData(string key)
    {
        var playerData = await CloudSaveService.Instance.Data.Player.LoadAsync(
           new HashSet<string> { key }
            );
        if (playerData.TryGetValue(key, out var value))
        {
            Debug.Log(key + " value : " + value.Value.GetAs<String>());
        }

    }
    [Button]
    public async void DeleteData(string key)
    {
        await CloudSaveService.Instance.Data.Player.DeleteAsync(key, new Unity.Services.CloudSave.Models.Data.Player.DeleteOptions());
    }

}
