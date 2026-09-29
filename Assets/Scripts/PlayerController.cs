using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;


    private Rigidbody rb;
    private float moveX;
    private float moveY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnMove(InputValue moveValue)
    {
      Vector2 movementVector = moveValue.Get<Vector2>();
      
      moveX = movementVector.x;
      moveY = movementVector.y;
    }
    
    void FixedUpdate()
    {
      Vector3 movement = new Vector3(moveX, 0.0f, moveY);

      rb.AddForce(movement * speed);

    }
}
