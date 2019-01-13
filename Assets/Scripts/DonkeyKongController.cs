using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKongController : MonoBehaviour {

    private Animator anim;
    private bool moving;
    private bool isFirstBarrel;

    public Rigidbody2D barrel;
    public Rigidbody2D firstBarrel;
    Rigidbody2D barrelInstance;
    Rigidbody2D firstBarrelInstance;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        isFirstBarrel = true;
        moving = false;
        Invoke("StartAnimLaunchBarel", 0.5f);
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

    private void StartAnimLaunchBarel() {
        anim.SetBool("launchBarrel", true);
    }

    private void LaunchBarrel()
    {
        if (isFirstBarrel)
        {
            firstBarrelInstance = Instantiate(firstBarrel, transform.position, transform.rotation) as Rigidbody2D;
            isFirstBarrel = false;
        }
        else {
            barrelInstance = Instantiate(barrel, transform.position, transform.rotation) as Rigidbody2D;
        }
        anim.SetBool("launchBarrel", false);
    }
}
