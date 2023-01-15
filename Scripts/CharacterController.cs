using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 0.0f;
    private Rigidbody2D rd2;
    private Animator _animator;
    private Vector3 charPos;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _camera;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();//caching
        rd2 = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;

    }


    void FixedUpdate()
    {
        //rd2.velocity = new Vector2(x: speed, y: 0f);
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    speed = 1.0f;
        //    //Debug.Log(message: "Hýz 1.0f");
        //}
        //else
        //{
        //    speed = 0.0f;
        //    //Debug.Log(message: "Hýz 0.0f");
        //}

        charPos = new Vector3(x: charPos.x + (Input.GetAxis("Horizontal")* speed * Time.deltaTime), charPos.y);
        transform.position = charPos; //Hesapladýðým pozisyon karakterime iþlensin.
      

        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat(name: "speed", value: 0.0f);
        }
        else
        {
            _animator.SetFloat(name: "speed", value: 1.0f);
        }

        if (Input.GetAxis("Horizontal") > 0.01f) 
        {
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y, z: charPos.z - 1.0f);
    }
}
