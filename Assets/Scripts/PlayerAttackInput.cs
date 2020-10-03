using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimation;

    public GameObject attackPoint;

    private PlayerShield shield;

    private CharacterSoundFX soundFX;
    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        shield = GetComponent<PlayerShield>();
        shield.ActivateShield(false);

        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    void Update()
    {
        //Defend input (key J)
        if(Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.Defend(true);

            shield.ActivateShield(true);
        }

        //Stop blocking with shield
        if(Input.GetKeyUp(KeyCode.J))
        {
            playerAnimation.UnFreezeAnimation();
            playerAnimation.Defend(false);

            shield.ActivateShield(false);
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            if(Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack_1();

                soundFX.Attack_1();
            }
            else
            {
                playerAnimation.Attack_2();

                soundFX.Attack_2();
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
