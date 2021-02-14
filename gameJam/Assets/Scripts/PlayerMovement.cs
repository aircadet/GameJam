using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator PlayerAnim;
    public GameObject player;
    public float jumpForce;
    public float speed, acceleration;
    public bool isGround = true;
    public bool swordUpgrade = false;
    public bool knifeUpgrade=false;
    float coolDown= 1f;
    float nextJumpTime=0;
    float nextAttackTime = 0;

   
    void Start()
    {
        PlayerAnim = gameObject.GetComponent<Animator>();
        playerRB = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float tempVelocity = Mathf.Abs(playerRB.velocity.x);
        PlayerAnim.SetFloat("velocity", tempVelocity);
        PlayerAnim.SetBool("JumpAnim", !isGround);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            playerRB.velocity = new Vector2(Mathf.Lerp(playerRB.velocity.x, speed, acceleration), playerRB.velocity.y);

            SoundManager.PlaySound("adim");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            playerRB.velocity = new Vector2(Mathf.Lerp(playerRB.velocity.x, -speed, acceleration), playerRB.velocity.y);

            SoundManager.PlaySound("adim");
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space) && isGround && nextJumpTime <= Time.timeSinceLevelLoad)
        {
            playerRB.AddRelativeForce(Vector2.up * jumpForce);
            nextJumpTime = Time.timeSinceLevelLoad + coolDown;
        }
        if (Input.GetKey(KeyCode.F) && nextAttackTime <= Time.timeSinceLevelLoad)
        { 
            if(swordUpgrade)
            {
                PlayerAnim.SetTrigger("SwordAttack");
                nextAttackTime = Time.timeSinceLevelLoad + coolDown;

                SoundManager.PlaySound("sword");
            }
            else if (knifeUpgrade)
            {
                PlayerAnim.SetTrigger("kilic");
                nextAttackTime = Time.timeSinceLevelLoad + coolDown;
            }
        }
    }
    
}
