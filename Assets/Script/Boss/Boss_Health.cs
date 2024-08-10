using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Health : MonoBehaviour
{
    public int health = 300;
    public Image healthBar;
    public float healthAmount = 100f;


    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            


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
        Animator bossAnimator = GameObject.Find("Boss").GetComponent<Animator>();
        Boss script = bossAnimator.GetComponent<Boss>();

        bossAnimator.SetBool("isDead", true);
        yield return new WaitForSeconds(0.5f);
        bossAnimator.enabled = false;
        script.enabled = false;
    }



}
