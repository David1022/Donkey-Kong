using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKongController : MonoBehaviour {

    private Animator anim;
    private bool moving;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        moving = true;
        InvokeRepeating("toggleAnim", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void toggleAnim()
    {
        moving = !moving;
        anim.SetBool("move", moving);
    }
}
