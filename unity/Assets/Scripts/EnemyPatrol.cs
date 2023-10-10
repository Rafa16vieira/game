using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{


    [Header("Attack Properties")]
    public float timerWaitAttack;
    public float timerShootAttack;

    private bool idle;
    private bool shoot;
    private bool die;
    private Weapon weapon;


    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }

    void Start(){
        weapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!RayCastGround().collider || RaycastWall().collider){
            Flip();
        }
    }

    private void FixedUpdate(){

        if (CanAttack()){
            Attack();
        } else{

        Movement();
        }
    }

    private void LateUpdate(){
        animator.SetBool("idle", idle);
    }

    private void Movement(){
        float horizontalVelocity = speed;
        horizontalVelocity = horizontalVelocity * direction;
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
        idle = false;
    }


    private bool CanAttack(){
        return ((int)Mathf.Abs(playerXDistance)) <= attackDistance;
    }

    private void Attack(){
        StopMovement();
        DistanciaFlipPlayer();
        CanShoot();
    }

    private void StopMovement(){
        rb.velocity = Vector3.zero;
        idle = true;
    }

    private void DistanciaFlipPlayer(){
        if (playerXDistance >= 0){
            if(direction == -1){
                Flip();
            }
        }else{
            if (direction == 1){
                Flip();
            }
        }
    }

    private void CanShoot(){
        if (!shoot){
            StartCoroutine("Shoot");
        }
    }

    private IEnumerator Shoot(){
        shoot = true;

        yield return new WaitForSeconds(timerWaitAttack);

        AnimationShoot();

        yield return new WaitForSeconds(timerShootAttack);

        shoot = false;
    }

    private void AnimationShoot(){
        animator.SetTrigger("shoot");
    }


    private void ShootPrefab(){
        if(weapon != null){
            weapon.Shoot();
        }
    }


    public void Die(){
        die = true;
        rb.velocity = Vector2.zero;
        StopMovement();
        animator.SetTrigger("die");
    }

    private void OnDisabled(){
        Destroy(gameObject, 3f);
    }
}
