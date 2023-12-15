using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController1 : MonoBehaviour
{
    private bool isAnimationPlayed = false;
    private float timer;
    Animator anim;
    void Start()
    { 
        anim = gameObject.GetComponent<Animator>();
        isAnimationPlayed = false;
        anim.SetInteger("isPlaying", 0);
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            anim.SetInteger("isPlaying", 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            anim.SetInteger("isPlaying", 1);
            timer = 2f;
        }
    }
} /*New Anima321214tion*/