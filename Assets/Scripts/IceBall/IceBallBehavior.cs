using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallBehavior : MonoBehaviour
{

    void Update()
    {
        DestroyIceBall();
    }

    private void DestroyIceBall()
    {
        Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemySpell")
            Destroy(this.gameObject);
    }

}
