using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform throwSpellPoint;
    public GameObject spell;

    private GameObject gameController;
    private float enemySpeed = 7.5f;
    private float enemySpellSpeed = 15.2f;
    private Animator anim;
    private GameObject wraith;
    private float spellLimit = 1;

    void Start()
    {
        wraith = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
        Attack();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        anim.SetBool("isGetDamage", true);
        Destroy(this.gameObject, 0.4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "IceBall")
        {
            anim.SetBool("isGetDamage", true);
            Destroy(this.gameObject);
            enemySpeed = 0f;
            gameController.GetComponent<GameController>().score += 1;
        }
    }

    private void Attack()
    {
        Vector3 distanceToAttack;
        distanceToAttack = transform.position - wraith.transform.position;
        if (distanceToAttack.x > 0 && distanceToAttack.x < 10 && spellLimit == 1)
        {
            anim.SetBool("isAttack", true);
            GenerateSpell();
            spellLimit--;
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
    }

    private void GenerateSpell()
    {
        GameObject enemySpell = Instantiate(spell, throwSpellPoint.position, Quaternion.identity);
        Rigidbody2D enemySpellBody = enemySpell.GetComponent<Rigidbody2D>();
        enemySpellBody.AddForce(-transform.right * enemySpellSpeed, ForceMode2D.Impulse);
    }
}
