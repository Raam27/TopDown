using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D r2d;
    public float distance;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
            move();
            if (distance > 6)
            {
                player = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
        }
    }

    private void rotate()
    {
        Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        transform.up = direction;
    }
    private void move()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
        rotate();
    }
}
