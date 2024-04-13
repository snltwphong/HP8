using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public Image healthBar;
    public float healthAmount = 100f;

    public void TakeDamage(int damage)
    {
        if(health > 0)
        {
            health -= damage;
            StartCoroutine(DamageAnimation());
            healthAmount -= damage;
            healthBar.fillAmount = healthAmount / 100f;

        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(EndGameEffect());
    }
    IEnumerator EndGameEffect()
    {
        Animator playerAnimator = GameObject.Find("Knight").GetComponent<Animator>();
        Animator bossAnimator = GameObject.Find("Boss").GetComponent <Animator>();
        Player_script script_Player = playerAnimator.GetComponent<Player_script>();
        Boss_Run scriptBoss = bossAnimator.GetComponent<Boss_Run>();

        playerAnimator.SetBool("isHurting", false);
        playerAnimator.SetBool("isDead", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.enabled = false;
        script_Player.enabled = false;
    }
    IEnumerator DamageAnimation()
    {
        Animator playerAnimator = GameObject.Find("Knight").GetComponent<Animator>();
        playerAnimator.SetBool("isHurting", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("isHurting", false);
    }


}
