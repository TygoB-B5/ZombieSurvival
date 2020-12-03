using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;
    private EnemyAttack enemyAttack;

    private void Awake()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        anim = GetComponent<Animator>();
        GetComponent<EnemyDetectHit>().OnHit += Fall;
    }

    private void Update()
    {
        AttackAnimation();
    }

    private void AttackAnimation()
    {
        if (enemyAttack.hasShot)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
    }

    private void Fall()
    {
        anim.SetTrigger("fall");
    }
}
