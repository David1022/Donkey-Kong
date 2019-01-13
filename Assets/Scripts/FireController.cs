using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {

    private const float LINEAL_SPEED = 1f;

    public float linealSpeed;
    private Rigidbody2D rgbody;

    // Use this for initialization
    void Start () {
        rgbody = GetComponent<Rigidbody2D>();
        linealSpeed = LINEAL_SPEED;
        GetComponent<SpriteRenderer>().flipX = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        rgbody.velocity = new Vector2(linealSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Fire") {
            ChangeDirection();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireLimit"))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (linealSpeed > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        linealSpeed = (-1) * linealSpeed;
    }
}