using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public bool walk;

    public float enemySpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 enemyPos = enemy.transform.position;

        walk = false;

        if (enemyPos.x < playerPos.x)
        {
            enemy.transform.localScale = new Vector3(-1, 1, 1);

            if (Mathf.Abs(enemyPos.x - playerPos.x) > 3)
            {
               
                enemy.transform.position = new Vector3(enemyPos.x + (enemySpeed * Time.deltaTime), enemyPos.y);

                

                walk = true;


            }

            
        }
        else if (enemyPos.x > playerPos.x)
        {
            enemy.transform.localScale = new Vector3(1, 1, 1);

            if (Mathf.Abs(enemyPos.x - playerPos.x) > 4)
            {

                
                enemy.transform.position = new Vector3(enemyPos.x - (enemySpeed * Time.deltaTime), enemyPos.y);
                walk = true;

                

            }
           
            
        }

        if (Mathf.Abs(enemyPos.x - playerPos.x) < 3) 
        {
          
            //attack
          
        }

        Debug.Log("Yürüme Durumu ---->" + walk);



    }
}
