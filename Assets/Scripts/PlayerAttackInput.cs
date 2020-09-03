using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimation;

    public GameObject attackPoint;
    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
    }

    void Update()
    {
        //Defend input (key J)
        if(Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.Defend(true);
        }

        //Stop blocking with shield
        if(Input.GetKeyUp(KeyCode.J))
        {
            playerAnimation.UnFreezeAnimation();
            playerAnimation.Defend(false);
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            if(Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack_1();
            }else
            {
                playerAnimation.Attack_2();
            }
        }
    }

    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void Deactivate_AttackPoint()
    {
        if(attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
