using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;

public class CloudSave : MonoBehaviour
{
    [SerializeField] ExperienceBar experienceBar;
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
    public async void SaveAllPlayerData()
    {
        var data = experienceBar.GetPlayerData();
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
        Debug.Log("Datos guardados en la nube");
    }
    public async void LoadAllPlayerData()
    {
        var keys = new HashSet<string> { "level", "currentClicks", "abilityLevel", "strengthLevel", "armorLevel", "fortuneLevel", "damageLevel" };

        var playerData = await CloudSaveService.Instance.Data.Player.LoadAsync(keys);

        if (playerData.TryGetValue("level", out var lvl))
            experienceBar.SetLevel(lvl.Value.GetAs<int>());

        if (playerData.TryGetValue("currentClicks", out var clicks))
            experienceBar.SetCurrentClicks(clicks.Value.GetAs<int>());

        if (playerData.TryGetValue("abilityLevel", out var ability))
            experienceBar.SetAbility(ability.Value.GetAs<int>());

        if (playerData.TryGetValue("strengthLevel", out var strength))
            experienceBar.SetStrength(strength.Value.GetAs<int>());

        if (playerData.TryGetValue("armorLevel", out var armor))
            experienceBar.SetArmor(armor.Value.GetAs<int>());

        if (playerData.TryGetValue("fortuneLevel", out var fortune))
            experienceBar.SetFortune(fortune.Value.GetAs<int>());

        if (playerData.TryGetValue("damageLevel", out var damage))
            experienceBar.SetDamage(damage.Value.GetAs<int>());

        Debug.Log("Datos cargados desde la nube");
    }
    public async void SaveAndQuit()
    {
        await CloudSaveService.Instance.Data.Player.SaveAsync(experienceBar.GetPlayerData());
        Debug.Log("Datos guardados, cerrando juego...");
        Application.Quit();
    }
}