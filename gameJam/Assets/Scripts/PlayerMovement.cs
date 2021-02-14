using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator PlayerAnim;
    GameObject tempGameObject;
    public GameObject player;
    public GameObject oldMan;
    public GameObject tabut;
    public float jumpForce;
    public float speed, acceleration;
    public bool isGround = true;
    public bool swordUpgrade = false;
    public bool knifeUpgrade = false;
    float coolDown = 1f;
    float nextJumpTime = 0;
    float nextAttackTime = 0;
    bool saldiri = true;
    public AudioSource audioSource;
    public AudioClip almak, click, kapiGicirti, kilic1, kilic2, kilic3, kilic4, kilic5, adim, sword, sword1, sword2;
    public AudioClip[] kiliclar;
    public AudioClip[] swords;

    public Slider slider;
    public Slider oldManSlider;
    public Slider tabutSlider;
    public Camera camera;

    void Start()
    {
        PlayerAnim = gameObject.GetComponent<Animator>();
        playerRB = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 camPos = camera.WorldToScreenPoint(player.transform.position);
        Vector3 camPos1 = camera.WorldToScreenPoint(oldMan.transform.position);
        Vector3 camPos2 = camera.WorldToScreenPoint(tabut.transform.position);

        float health = FindObjectOfType<PlayerManager>().healt;

        slider.value = health / 100;
        oldManSlider.value = FindObjectOfType<LastLevel>().oldManHealt / 100;
        tabutSlider.value = FindObjectOfType<LastLevel>().TabutHealt / 100;

        slider.transform.position = new Vector3(camPos.x, camPos.y + 250, camPos.z);
        oldManSlider.transform.position = new Vector3(camPos1.x, camPos1.y + 250, camPos1.z);
        tabutSlider.transform.position = new Vector3(camPos2.x, camPos2.y + 250, camPos2.z);


        float tempVelocity = Mathf.Abs(playerRB.velocity.x);
        PlayerAnim.SetFloat("velocity", tempVelocity);
        PlayerAnim.SetBool("JumpAnim", !isGround);
        //if((playerRB.velocity.x == 0 || !isGround )&& audioSource.isPlaying == adim)
        //{
        //    audioSource.Stop();
        //}

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            playerRB.velocity = new Vector2(Mathf.Lerp(playerRB.velocity.x, speed, acceleration), playerRB.velocity.y);

            //SoundManager.PlaySound("adim");

            PlaySound(adim);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            playerRB.velocity = new Vector2(Mathf.Lerp(playerRB.velocity.x, -speed, acceleration), playerRB.velocity.y);

            //SoundManager.PlaySound("adim");
            PlaySound(adim);
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
        if (Input.GetKey(KeyCode.F) && nextAttackTime <= Time.timeSinceLevelLoad && saldiri)
        {
            if (swordUpgrade)
            {
                PlayerAnim.SetTrigger("SwordAttack");
                nextAttackTime = Time.timeSinceLevelLoad + coolDown;

                //SoundManager.PlaySound("sword");

                PlaySound2(kilic3);
            }
            else if (knifeUpgrade)
            {
                PlayerAnim.SetTrigger("KnifeAttack");
                nextAttackTime = Time.timeSinceLevelLoad + coolDown;
                PlaySound2(sword);
            }
        }
        if (Input.GetKey(KeyCode.F) && nextAttackTime <= Time.timeSinceLevelLoad && !saldiri)
        {

            if (swordUpgrade)
            {
              
                PlayerAnim.SetTrigger("SwordAttack");
                nextAttackTime = Time.timeSinceLevelLoad + coolDown;
                //SoundManager.PlaySound("sword");
                tempGameObject.GetComponent<EnemyAttackScript>().enemyHealthManager();
                PlaySound2(kilic3);
            }
            else if (knifeUpgrade)
            {
                PlayerAnim.SetTrigger("KnifeAttack");
                nextAttackTime = Time.timeSinceLevelLoad + coolDown;
                tempGameObject.GetComponent<EnemyAttackScript>().enemyHealthManager();
                PlaySound2(sword);
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clip, 0.5f);
        }

    }

    public void PlaySound2(AudioClip clip)
    {

        audioSource.PlayOneShot(clip, 0.5f);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            tempGameObject = collision.gameObject;
            saldiri = false;
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            saldiri = false;
        }




    }
}