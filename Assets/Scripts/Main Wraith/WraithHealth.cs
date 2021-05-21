using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithHealth : MonoBehaviour
{
    public int health = 5;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Dead();
        Invoke("CancelHurt", 0.35f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemySpell")
        {
            health -= 1;
            anim.SetBool("isDamaged", true);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            CancelInvoke("CancelHurt");
        }
    }

    private void CancelHurt()
    {
        anim.SetBool("isDamaged", false);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(194, 194, 194);
    }

    private void Dead()
    {
        anim.SetInteger("heatlh", health);
    }

}
