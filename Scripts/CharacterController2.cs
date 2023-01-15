using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float jumpforce =150.0f;
    public float speed = 1.0f;
    public float moveDirection;

    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D _rigitbody2D;
    private Animator anim;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        anim = GetComponent<Animator>(); //caching animator
    }

    
    void Start()
    {
        _rigitbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(_rigitbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        _rigitbody2D.velocity = new Vector2(x: speed * moveDirection, _rigitbody2D.velocity.y);

        if (jump == true) {
            _rigitbody2D.velocity = new Vector2( _rigitbody2D.velocity.x, y: jumpforce);
            jump = false;
        }
    }

    private void Update()
    {
        if (grounded == true && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat(name: "speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat(name: "speed", speed);
            }
           
        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat(name: "speed", 0.0f);
        }
 
        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            Debug.Log("W basýldý");
            jump = true;
            grounded = false;
            anim.SetTrigger(name: "jump");
            anim.SetBool(name: "grounded", value: false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Zemin"))
        {
            Debug.Log("yere çarptýk");
            anim.SetBool(name: "grounded", value: true);
            grounded = true;
        }
    }
}
