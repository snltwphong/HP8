using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int live = 3;
    public Image Heart;
    public Image brokenHeart;

    public void TakeDamage(int damage)
    {
        if(live > 0)
        {
            live -= damage;
            StartCoroutine(DamageAnimation());
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
