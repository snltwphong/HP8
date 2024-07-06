using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Coliide : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public void HeartEffect()
    {
        anim.SetBool("IsTouching", true);
    }

}
