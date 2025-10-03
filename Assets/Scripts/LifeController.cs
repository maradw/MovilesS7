using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LifeController : MonoBehaviour
{
    public ExperienceBar _newGameManager;
    public GameObject lifePrefab;
    public int quantityLifes;
    public GameObject newKillaReference;

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i< quantityLifes; i++)
        {
            GameObject temp =Instantiate(lifePrefab, transform.position, transform.rotation);
            temp.transform.SetParent(this.gameObject.transform);
        }*/
    }
    public void CreateLife()
    {
        for (int i = 0; i < quantityLifes; i++)
        {
            GameObject temp = Instantiate(lifePrefab, transform.position, transform.rotation);
            temp.transform.SetParent(this.gameObject.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }
    /*public void SetGameManger(GameManager lifeKillaManager)
    {
        _newGameManager = lifeKillaManager;

    }*/
    public void SetNewLife(GameObject killaReference)
    {
        newKillaReference = killaReference;
    }
}
