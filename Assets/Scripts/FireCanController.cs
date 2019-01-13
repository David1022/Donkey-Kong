using UnityEngine;

public class FireCanController : MonoBehaviour {

    public Rigidbody2D fire;
    Rigidbody2D fireInstance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barrel")
        {
            CreateNewFire();
            Destroy(collision.gameObject);
        }
    }

    private void CreateNewFire() {
        Vector3 initialPosition = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.3f, transform.position.z);
        fireInstance = Instantiate(fire, initialPosition, transform.rotation) as Rigidbody2D;
    }
}
