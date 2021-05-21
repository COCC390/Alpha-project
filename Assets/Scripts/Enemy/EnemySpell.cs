using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    void Update()
    {
        DestroySpell();
    }

    private void DestroySpell()
    {
        Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "IceBall")
            Destroy(this.gameObject);
    }
}
