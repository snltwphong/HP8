using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public int attackDamage = 30;
    public float attackRange = 5f;
    public LayerMask attackMask;
    /*    public Vector3 attackOffset;*/

    public void Attack()
    {
        Vector3 pos = transform.position;
        /*        pos += transform.right * attackOffset.x;
                pos += transform.up * attackOffset.y;*/

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Boss_Health>().TakeDamage(attackDamage);
        }
    }
}
