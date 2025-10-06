using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [HeaderAttribute(" Life variables")]
    public Image clicksBar;
   [SerializeField] int currentClicks = 0;
   [SerializeField] int maxClicks= 100;
   [SerializeField] int minClicks= 0;
    [SerializeField] string key = "exp";
    [SerializeField] PlayerController playerController;
    [SerializeField] int level = 1;
    [SerializeField] TextMeshProUGUI experiencie;
    [SerializeField] TextMeshProUGUI currentLevel;

    [SerializeField] TextMeshProUGUI ability;
    [SerializeField] TextMeshProUGUI strength;
    [SerializeField] TextMeshProUGUI armor;
    [SerializeField] TextMeshProUGUI fortune;
    [SerializeField] TextMeshProUGUI damage;
    int abilityLevel = 0;
    int strengthLevel = 0;
    int armorLevel = 0;
    int fortuneLevel = 0;
    int damageLevel = 0;
    void Update()
    {
        ClicksInGame();
        UpdateLevel();
        SetText();
    }

    void ClicksInGame()
    {
        clicksBar.fillAmount = (float)currentClicks / maxClicks;
    }

    public void CurrentClicksInGame(int add)
    {
        currentClicks += add;
        currentClicks = Mathf.Clamp(currentClicks, minClicks, maxClicks);
    }
    void SetText()
    {
        experiencie.text = currentClicks + "/" + maxClicks + " exp";
        currentLevel.text = "Level: " + level;
        ability.text = "Ability: " + abilityLevel;
        fortune.text = "Fortune: " + fortuneLevel;
        strength.text = "Strength: " + strengthLevel;
        armor.text = "Armor: " + armorLevel;
        damage.text = "Damage: " + damageLevel;
    }
    public void AddStrength()
    {
        if (abilityLevel <= 0) return;
        strengthLevel += 1;
        abilityLevel -= 1;
    }
    public void AddDamage()
    {
        if (abilityLevel <= 0) return;
        damageLevel += 1;
        abilityLevel -= 1;
    }
    public void AddFortune()
    {
        if (abilityLevel <= 0) return;
        fortuneLevel += 1;
        abilityLevel -= 1;
    }
    public void AddArmor()
    {
        if(abilityLevel <= 0) return;
        armorLevel += 1;
        abilityLevel -= 1;
    }
    public int GetlevelData()
    {
       return level;
    }
    void UpdateLevel()
    {
        if (currentClicks >= maxClicks)
        {
            currentClicks = 0;
            abilityLevel += 5;
            level++;
        }
    }
    public Dictionary<string, object> GetPlayerData()
    {
        var playerData = new Dictionary<string, object>()
    {
        {"level", level},
        {"currentClicks", currentClicks},
        {"abilityLevel", abilityLevel},
        {"strengthLevel", strengthLevel},
        {"armorLevel", armorLevel},
        {"fortuneLevel", fortuneLevel},
        {"damageLevel", damageLevel}
    };

        return playerData;
    }
    public void SetLevel(int value) => level = value;
    public void SetCurrentClicks(int value) => currentClicks = value;
    public void SetAbility(int value) => abilityLevel = value;
    public void SetStrength(int value) => strengthLevel = value;
    public void SetArmor(int value) => armorLevel = value;
    public void SetFortune(int value) => fortuneLevel = value;
    public void SetDamage(int value) => damageLevel = value;
}
