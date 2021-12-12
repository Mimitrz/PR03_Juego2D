using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    float speed; //Velocidad en X a la que me muevo
    [SerializeField] float maxSpeed; //Velocidad de desplazamiento máxima

    float desplX;

    float jumpForce;

    bool alive = true;

    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        maxSpeed = 3.5f;
        jumpForce = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        desplX = Input.GetAxis("Horizontal");
        if (alive)
        {
            Girar();

            Saltar();

            Crouch();

            Roll();

            Run();
        }
    }

    private void FixedUpdate()
    {
        if (alive)
        {
            Caminar();
        }

    }

    void Caminar()
    {
        rb.velocity = new Vector2(desplX * maxSpeed, rb.velocity.y);
        speed = rb.velocity.x;
        speed = Mathf.Abs(speed);
        animator.SetFloat("SpeedX", speed);
    }

    void Girar()
    {
        if (desplX < 0 && facingRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            facingRight = false;
        }
        else if (desplX > 0 && !facingRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            facingRight = true;
        }
    }

    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("IsGrounded"))
        {
            rb.AddForce(new Vector2(0f,1f) * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.15f);
        if (hit.collider != null)
        {
            animator.SetBool("IsGrounded", true);
        }
        else
        {
            animator.SetBool("IsGrounded", false);
        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Crouch", false);
        }
    }

   void Roll()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            animator.SetBool("Roll", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            animator.SetBool("Roll", false);
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Run", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Run", false);
        }
    }

    //Control de suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //print("Estoy tocando suelo");
            animator.SetBool("IsGrounded", true);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //print("NO Estoy tocando suelo");
            animator.SetBool("IsGrounded", false);
        }

    }

}

