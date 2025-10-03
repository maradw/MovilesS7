using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillaController : MonoBehaviour
{
    float horizontal;
    float vertical;
    Rigidbody2D _killaRigidBody;
    public float speedX;
    public float speedY;
    private Transform _compTransform;
    public GameObject WeaponPosition;
    public ExperienceBar _gameManagerForLife;
    public GameObject _littleEnemy;
    public Image _lifeBar;
    
    void Awake()
    {
        _compTransform = GetComponent<Transform>();
        _killaRigidBody = GetComponent<Rigidbody2D>();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "littleEnemy")
        {
           _gameManagerForLife.CurrentLifeInGame(5f);
        }
        else if (collision.gameObject.tag == "merek")
        {
            _gameManagerForLife.CurrentLifeInGame(10);
        }
    
    
    }
*/
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


    }
    private void FixedUpdate()
    {
        _killaRigidBody.linearVelocity = new Vector2(horizontal * speedX, vertical * speedY);
    }

    public void SetGameManager(ExperienceBar _firstGameManager)
    {
        _gameManagerForLife = _firstGameManager;
        
    }



}
