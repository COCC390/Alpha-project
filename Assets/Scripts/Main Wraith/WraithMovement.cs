using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithMovement : MonoBehaviour
{
    private float runSpeed = 10.5f;
    private float moveInputHorizontal;
    private float moveInputVertical;
    private Rigidbody2D wraith;
    private Animator anim;

    private bool isAttack;
    public bool isFacingRight = true;
    void Start()
    {
        wraith = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isAttack = gameObject.GetComponent<WraithAttack>().isAttack;
    }

    void Update()
    {
        WraithMoveHorizontal();
        WraithMoveVertical();
        ClampMovement();

        isAttack = gameObject.GetComponent<WraithAttack>().isAttack;
        if (moveInputHorizontal == 0 && moveInputVertical == 0 && !isAttack)
            Invoke("Blink", 5);
        else
        {
            anim.SetBool("isBlink", false);
            CancelInvoke("Blink");
        }
    }

    void WraithMoveHorizontal()
    {
        moveInputHorizontal = Input.GetAxisRaw("Horizontal") * runSpeed;
        wraith.velocity = new Vector2(moveInputHorizontal, wraith.velocity.y);

        if (moveInputHorizontal != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && isFacingRight == true || Input.GetKeyDown(KeyCode.RightArrow) && isFacingRight == false)
            Flip();
    }

    void WraithMoveVertical()
    {
        moveInputVertical = Input.GetAxisRaw("Vertical") * runSpeed;
        wraith.velocity = new Vector2(wraith.velocity.x, moveInputVertical);

        if (moveInputVertical != 0)
        {
            anim.SetBool("isMoving", true);
        }
    }

    private void ClampMovement()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.86f, 24.4f),
                                         Mathf.Clamp(transform.position.y, -3.8f, 4.519f));
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 localTransform = transform.localScale;
        localTransform.x *= -1;
        transform.localScale = localTransform;
    }

    void Blink()
    {
        anim.SetBool("isBlink", true);
    }
}
