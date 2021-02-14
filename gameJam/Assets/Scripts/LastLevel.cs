using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevel : MonoBehaviour
{
    public GameObject oldMan, player, effect ;
    public float oldManHealt = 100, TabutHealt = 100;
    float cooldown = 3f;
    Animator oldManAnim, effectAnim;
    float nextAttack=3f;
    private void Start()
    {
        effectAnim = effect.GetComponent<Animator>();
        oldManAnim = oldMan.GetComponent<Animator>();
    }
    private void Update()
    { if(nextAttack <= Time.timeSinceLevelLoad)
        {
            nextAttack = Time.timeSinceLevelLoad + cooldown;
            Attack();
        }
        
    }
    void Attack()
    {
        oldManAnim.SetTrigger("attack");
        effectAnim.SetTrigger("attack");
        TabutHealt -=20;
        if (TabutHealt <= 0)
        {
            //kaybettik

        }
    }
    public void getDamage()
    {
        oldManHealt -= 30;
        if( oldManHealt <= 0)
        {
            //kazandık
        }
    }
}
