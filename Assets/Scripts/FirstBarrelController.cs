using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBarrelController : MonoBehaviour {

    private const float LINEAL_SPEED = -1f;

    public float linealSpeed;
    private Rigidbody2D rgbody;

    // Use this for initialization
    void Start () {
        rgbody = GetComponent<Rigidbody2D>();
        linealSpeed = LINEAL_SPEED;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        rgbody.velocity = new Vector2(0, linealSpeed);
    }

}
