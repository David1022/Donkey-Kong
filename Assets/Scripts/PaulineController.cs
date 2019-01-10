using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulineController : MonoBehaviour {

    private Animator anim;
    private bool walking;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();    
        walking = true;
        InvokeRepeating("toggleAnim", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update () {
    }

    private void toggleAnim() {
        walking = !walking;
        anim.SetBool("walking", walking);
    }
}
