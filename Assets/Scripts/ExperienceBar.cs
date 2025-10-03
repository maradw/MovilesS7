using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
 
    void Update()
    {
        LifeInGame();
        UpdateLevel();
        Remain();
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
    void Remain()
    {
        Debug.Log(currentLife + "/" + maxLife);
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
            level++;
        }
    }

}
