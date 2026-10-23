using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;


    private Rigidbody rb;
    private int count;
    private float moveX;
    private float moveY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        
        SetCountText();
        winTextObject.SetActive(false);
  
    }
    
    void OnMove(InputValue moveValue)
    {
      Vector2 movementVector = moveValue.Get<Vector2>();
      
      moveX = movementVector.x;
      moveY = movementVector.y;
    }

    void SetCountText()
    {
      countText.text = "Count: " + count.ToString();
      if (count >= 12)
      {
        winTextObject.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
      }
    }
    
    void FixedUpdate()
    {
      Vector3 movement = new Vector3(moveX, 0.0f, moveY);

      rb.AddForce(movement * speed);

    }
    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("PickUp"))
      {
        other.gameObject.SetActive(false);
        count = count + 1;
        SetCountText();
      }
    }

    private void OnCollisionEnter(Collision collision)
    {
      Debug.Log($"{collision.transform.name} Collision");
      if (collision.gameObject.CompareTag("Enemy"))
      {
        Destroy(gameObject);

        winTextObject.gameObject.SetActive(true);
        winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
      }
    }
}
