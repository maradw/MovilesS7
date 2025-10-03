using System.Globalization;
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
                // Está sobre UI ? no cuentes el click
                return;
            }
            Debug.Log("Clicked " );
            clickCount++;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            experienceBar.CurrentLifeInGame(1);

            /* if (Physics.Raycast(ray, out hit))
            {
                
               
                

                
                 Debug.DrawLine(ray.origin, hit.point, Color.green, 0.5f);
                if (hit.collider.CompareTag("Blover"))
                 {
                     EnemyMovement enemy = hit.collider.GetComponent<EnemyMovement>();
                     enemy.HandleClicked();
                     clickCount++;
                 }
        
        else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 5f, Color.red, 0.5f);
            }*/
        }
        level = experienceBar.GetlevelData();
    }
    public int GetClickCount() 
    { return clickCount; }

}
