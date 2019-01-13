using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MovementDirection
{
    RIGHT,
    LEFT
}

public class MarioController : MonoBehaviour {

    private const float LINEAL_SPEED = 2f;
    private const float JUMP_FORCE = 10000;
    private const float DISTANCE_TO_GROUND = 10f;
    private const float GOING_UP_VELOCITY = 0.5f;

    private MovementDirection movementDirection;
    private static bool canPlay;
    private float linealSpeed;
    private float jumpForce;
    private bool isInStairs;

    private Animator anim;
    private Rigidbody2D rgbodyMario;
    private AudioSource audio;
    public AudioClip jumpAudio;
    public AudioClip deadAudio;

    public LayerMask groundLayer;

    // Use this for initialization
    void Start () {
        initialize();

        canPlay = false;
        linealSpeed = LINEAL_SPEED;
        jumpForce = JUMP_FORCE;
        isInStairs = false;
        movementDirection = MovementDirection.RIGHT;
    }

    void initialize() {
        rgbodyMario = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay) {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isInStairs)
                {
                    GoUp();
                }
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                if (isInStairs)
                {
                    Stop();
                }
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (isInStairs)
                {
                    GoDown();
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    private void MoveRight()
    {
        if (movementDirection == MovementDirection.LEFT)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            movementDirection = MovementDirection.RIGHT;
        }
        rgbodyMario.velocity = new Vector2(transform.right.x * linealSpeed, rgbodyMario.velocity.y);
    }

    private void MoveLeft()
    {
        if (movementDirection == MovementDirection.RIGHT)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            movementDirection = MovementDirection.LEFT;
        }
        rgbodyMario.velocity = new Vector2(-(transform.right.x * linealSpeed), rgbodyMario.velocity.y);
    }

    private void GoUp() {
        if (isInStairs) {
            rgbodyMario.bodyType = RigidbodyType2D.Kinematic;
            rgbodyMario.velocity = new Vector2(0, transform.up.y * GOING_UP_VELOCITY);
            anim.SetBool("isGoingUp", true);
        }
    }

    private void GoDown() {
        if (isInStairs) {
            rgbodyMario.bodyType = RigidbodyType2D.Kinematic;
            rgbodyMario.velocity = new Vector2(0, transform.up.y * -GOING_UP_VELOCITY);
            anim.SetBool("isGoingUp", true);
        }
    }

    private void Stop() {
        rgbodyMario.velocity = Vector2.zero;
        anim.SetBool("isGoingUp", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Fire") {
            Dead();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            Dead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stair")
        {
            isInStairs = true;
        }
        if (collision.tag == "DeadZone" || collision.tag == "Barrel" || collision.tag == "DonkeyKong") {
            Dead();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Stair")
        {
            isInStairs = false;
            rgbodyMario.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void Jump()
    {
        if (IsTouchingTheGround())
        {
            anim.SetBool("isJumping", true);
            rgbodyMario.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            audio.PlayOneShot(jumpAudio);
        }
    }

    private bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, DISTANCE_TO_GROUND, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetCanPlay() {
        canPlay = true;
    }

    private void Dead() {
        canPlay = false;
        anim.SetBool("isDead", true);
        GameManager.StopAudio();
        audio.PlayOneShot(deadAudio);
        StartCoroutine("ChangeToFinalScreen");
    }

    IEnumerator ChangeToFinalScreen() {
        yield return new WaitForSeconds(1f);
        SaveLoad.Save(GameManager.instance.time.ToString(), GameManager.instance.score.ToString(), false);
        SceneManager.LoadScene("EndScreen");
    }
}