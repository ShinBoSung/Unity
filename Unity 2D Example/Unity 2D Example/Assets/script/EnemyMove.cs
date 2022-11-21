using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    Animator anim;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();        
        //Invoke() : 주어진 시간이 지난 뒤, 지정된 함수를 실행하는 함수

        Invoke("Think", 5);
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //Platform Check
        Vector2 forntVec = new Vector2(rigid.position.x + nextMove * 0.3f, rigid.position.y);

        Debug.DrawRay(forntVec, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(forntVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider == null)
        {
            Turn();
        }
    }
    
    //재귀함수 : 자신을 호출하는 함수
    void Think()
    {
        nextMove = Random.Range(-1, 2);

        anim.SetInteger("walkSpeed", nextMove);

        if (nextMove != 0)
        {
            spriteRenderer.flipX = nextMove == 1;
        }

        float nextMoveTime = Random.Range(2f, 5f);

        Invoke("Think", nextMoveTime);

    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
        CancelInvoke();
        Invoke("Think", 2);
    }
}
