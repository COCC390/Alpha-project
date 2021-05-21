using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithAttack : MonoBehaviour
{
    public float fireSpeed = 5f;
    public GameObject iceBall;
    public Transform throwSpellPoint;

    public bool isAttack = false;
    public bool isFacingRight;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        fireSpeed = 10;
        isFacingRight = gameObject.GetComponent<WraithMovement>().isFacingRight;
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isAttack = true;
            anim.SetBool("isAttacking", true);
            GenerateIceSpell();
        }
        else
        {
            anim.SetBool("isAttacking", false);
            isAttack = false;
        }
    }

    private void GenerateIceSpell()
    {
        GameObject iceSpell = Instantiate(iceBall, throwSpellPoint.position, Quaternion.identity);
        Rigidbody2D iceBallBody = iceSpell.GetComponent<Rigidbody2D>();
        if(!isFacingRight)
            iceBallBody.AddForce(-transform.right * fireSpeed, ForceMode2D.Impulse);
        else
            iceBallBody.AddForce(transform.right * fireSpeed, ForceMode2D.Impulse);
    }

}
