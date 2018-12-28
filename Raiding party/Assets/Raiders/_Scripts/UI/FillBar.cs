using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBar : MonoBehaviour
{
    Animator anim;
    int total;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Increase(int amount)
    {
        //total + amount
        //Math.Clamp(total, min, max)
        anim.SetInteger("percent", total);
    }

    void Decrease(int amount)
    {
        //total - amount
        //Math.Clamp(total, min, max)
        anim.SetInteger("percent", total);
    }
}
