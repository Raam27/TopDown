using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    
    public int health = 100;
    [SerializeField]
    int rotationSpeed;
    private Rigidbody2D r2d;
    public int movSpeed;
    float jumpForce;

    float horizontalInput;
    float verticalInput;
    float rotateInput;
    Vector3 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rotatePlayer();
    }
    private void FixedUpdate()
    {
        movePlayer();
        
    }
    private void movePlayer()
    {
        r2d.velocity = new Vector2(horizontalInput*movSpeed, verticalInput*movSpeed);
    }
    private void rotatePlayer()
    {
        //float rotation = worldPosition* rotationSpeed;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
