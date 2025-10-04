using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [HeaderAttribute(" Life variables")]
    public Image greenLifeBar;
   [SerializeField] int currentLife = 0;
   [SerializeField] int maxLife= 100;
   [SerializeField] int minLife= 0;
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
        LifeInGame();
        UpdateLevel();
        SetText();
    }

    void LifeInGame()
    {
        greenLifeBar.fillAmount = (float)currentLife / maxLife;
    }

    public void CurrentLifeInGame(int add)
    {
        currentLife += add;
        currentLife = Mathf.Clamp(currentLife, minLife, maxLife);
    }
    void SetText()
    {
        experiencie.text = currentLife + "/" + maxLife + " exp";
        currentLevel.text = "Level: " + level;
        ability.text = "Ability: " + abilityLevel;
        fortune.text = "Fortune: " + fortuneLevel;
        strength.text = "Strength: " + strengthLevel;
        armor.text = "Armor: " + armorLevel;
        damage.text = "Damage: " + damageLevel;
        Debug.Log(currentLife + "/" + maxLife);
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
        if (currentLife >= maxLife)
        {
           
            Debug.Log("Level Up!");
            currentLife = 0;
            abilityLevel += 5;
            level++;
        }
    }

}
