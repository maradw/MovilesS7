using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int clickCount = 0;
    [SerializeField] ExperienceBar experienceBar;
    int level;
    public void OnClick(InputAction.CallbackContext click)
    {

        if (click.performed)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Debug.Log("Clicked " );
            clickCount++;
            experienceBar.CurrentClicksInGame(1);
        }
        level = experienceBar.GetlevelData();
    }
    public int GetClickCount() 
    { return clickCount; }

}
