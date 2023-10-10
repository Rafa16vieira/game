using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Enemy Properties")]
    public float speed;
    public float attackDistance;
    [HideInInspector]
    public int direction;

    [Header("Raycast Properties")]
    public LayerMask layerGround;
    public float lengthGround;
    public float lengthWall;
    public Transform rayPointGround;
    public Transform rayPointWall;
    public RaycastHit2D hitGround;
    public RaycastHit2D hitWall;


    protected Animator animator;
    protected Rigidbody2D rb;


    protected Transform player;
    protected float playerXDistance;
    protected float playerYDistance;


    // Start is called before the first frame update
    protected virtual void Awake()
    {
        player = FindObjectOfType<Player>().transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        direction = (int)transform.localScale.x;
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        GetDistancePlayer();
    }

    protected virtual void Flip(){
        direction *= -1;
        transform.localScale = new Vector2(direction, transform.localScale.y);
    }

    protected virtual RaycastHit2D RayCastGround(){

        hitGround = Physics2D.Raycast(rayPointGround.position, Vector2.down, lengthGround, layerGround);

        Color color = hitGround ? Color.red : Color.green;

        Debug.DrawRay(rayPointGround.position, Vector2.down * lengthGround, color);

        return hitGround;
    }


    protected virtual RaycastHit2D RaycastWall(){
        hitWall = Physics2D.Raycast(rayPointWall.position, Vector2.right * direction, lengthWall, layerGround);

        Color color = hitWall ? Color.yellow : Color.blue;

        Debug.DrawRay(rayPointWall.position, Vector2.right * direction * lengthWall, color);

        return hitWall;
    }

    protected void GetDistancePlayer(){
        playerXDistance = player.position.x - transform.position.x;
        //Debug.Log("X = " + playerXDistance);
        playerYDistance = player.position.y - transform.position.y;
        //Debug.Log("Y = " + playerYDistance);
    }
}
