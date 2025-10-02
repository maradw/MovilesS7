using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int clickCount = 0;
    public void OnClick(InputAction.CallbackContext click)
    {

        if (click.performed)
        {
            Debug.Log("Clicked " );
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit " + hit.collider.name);
                Debug.DrawLine(ray.origin, hit.point, Color.green, 0.5f);
                if (hit.collider.CompareTag("Blover"))
                {
                    EnemyMovement enemy = hit.collider.GetComponent<EnemyMovement>();
                    enemy.HandleClicked();
                    clickCount++;
                }
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 5f, Color.red, 0.5f);
            }
        }

    }
    void Update()
    {
        
    }
}
