using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public int damage = 1;
    public Vector2 direction;
    public float speed;
    public GameObject explosion;
    protected Animator animator;
    protected float livingTime = 3f;
    protected int direcao = 1;
    protected SpriteRenderer _renderer;
    protected Rigidbody2D rb;


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = explosion.GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, livingTime);
    }

    protected virtual void update(){
        if(direction.normalized.x == -1){
            flip();
        }
    }

    protected virtual void FixedUpdate()
    {
        Movement();
        
    }

    private void Movement()
    {
        Vector2 movement = direction.normalized * speed;
        
        rb.velocity = movement;

        
    }

    public void flip(){
        direcao *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= direcao;
        transform.localScale = scale;
    }

    public void Explode()
    {
        speed = 0f;
        _renderer.enabled = false;

        GetComponent<BoxCollider2D>().enabled = false;
        if (explosion!=null)
        {
            explosion.SetActive(true);
            Debug.Log("boom");

        }

        Destroy(gameObject, 1.5f);
    }
}
