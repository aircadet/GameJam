using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public bool walk;
    public Animator enemyAnim;
    public float enemySpeed;

    public float enemyAttackTime;

    public int enemyHealth;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemyAnim.SetBool("walk", walk);
        Vector2 playerPos = player.transform.position;
        Vector2 enemyPos = enemy.transform.position;

        walk = false;

        if (enemyPos.x < playerPos.x)
        {
            enemy.transform.localScale = new Vector3(-1, 1, 1);

            if (Mathf.Abs(enemyPos.x - playerPos.x) > 3 &&  Mathf.Abs(enemyPos.x - playerPos.x) < 7)
            {             
                enemy.transform.position = new Vector3(enemyPos.x + (enemySpeed * Time.deltaTime), enemyPos.y);
                walk = true;
            }

            
        }
        else if (enemyPos.x > playerPos.x)
        {
            enemy.transform.localScale = new Vector3(1, 1, 1);

            if (Mathf.Abs(enemyPos.x - playerPos.x) > 3 && Mathf.Abs(enemyPos.x - playerPos.x) < 7)
            {               
                enemy.transform.position = new Vector3(enemyPos.x - (enemySpeed * Time.deltaTime), enemyPos.y);
                walk = true;               

            }           
        }

        if (Mathf.Abs(enemyPos.x - playerPos.x) < 3) 
        {
            if (enemyAttackTime <= 0)
            {
                enemyAnim.SetBool("attack", true);
                enemyAttackTime = 1;
                GameObject.Find("Player").GetComponent<PlayerManager>().GetDamage();

                
            }
            else if (enemyAttackTime >= 0)
            {
                enemyAnim.SetBool("attack", false);
            }
        }
        else
        {
            enemyAnim.SetBool("attack", false);
        }

        if (enemyAttackTime > 0)
        {
            enemyAttackTime -= 0.3f * Time.deltaTime;
            
        }
        else if (enemyAttackTime < 0)
        {
            enemyAttackTime = 0;
        }

        

    }

    public void enemyHealthManager()
    {
        enemyHealth -= 25;
        if (enemyHealth <= 0)
        {
            enemyAnim.SetBool("Death", true);
        }
    }
}
