using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Parameters")]
    public float attackPower = 1f;
    public float attackCooldown = 1f;
    public float attackRange = 1f;

    public GameObject attackAnimation;

    public Transform downAttackPos, leftAttackPos, upAttackPos, rightAttackPos;

    public LayerMask Enemies;

    private bool canAttack = true;
    PlayerLookDir lookDir;
    Player playerscript;

    // Start is called before the first frame update
    void Start()
    {
        playerscript = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canAttack == true)
        {
            //DO Attack
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        lookDir = playerscript.GetPlayerLookDirection();

        switch(lookDir)
        {
            case PlayerLookDir.Down:
                attackAnimation.transform.localRotation = Quaternion.Euler(0, 0, 270);
            break;
            case PlayerLookDir.Left:
                attackAnimation.transform.localRotation = Quaternion.Euler(0, 0, 180);
                break;
            case PlayerLookDir.Up:
                attackAnimation.transform.localRotation = Quaternion.Euler(0, 0, 90);
                break;
            case PlayerLookDir.Right:
                attackAnimation.transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;
        }

        attackAnimation.GetComponent<Animator>().SetTrigger("Attack");
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void DealDamage()
    {
        Collider2D[] enemiesToDamage;

        switch(lookDir)
        {
            case PlayerLookDir.Down:
                Debug.Log("Hyökkään alas");
                enemiesToDamage = Physics2D.OverlapCircleAll(downAttackPos.position, attackRange, Enemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    //Varsinainen vahingon teko
                }
                break;
            case PlayerLookDir.Left:
                Debug.Log("Hyökkään vasemmalle");
                enemiesToDamage = Physics2D.OverlapCircleAll(leftAttackPos.position, attackRange, Enemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    //Varsinainen vahingon teko
                }
                break;
            case PlayerLookDir.Up:
                Debug.Log("Hyökkään ylös");
                enemiesToDamage = Physics2D.OverlapCircleAll(upAttackPos.position, attackRange, Enemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    //Varsinainen vahingon teko
                }
                break;
            case PlayerLookDir.Right:
                Debug.Log("Hyökkään oikealle");
                enemiesToDamage = Physics2D.OverlapCircleAll(rightAttackPos.position, attackRange, Enemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    //Varsinainen vahingon teko
                }
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(downAttackPos.position, attackRange);

        Gizmos.DrawWireSphere(leftAttackPos.position, attackRange);

        Gizmos.DrawWireSphere(upAttackPos.position, attackRange);

        Gizmos.DrawWireSphere(rightAttackPos.position, attackRange);
    }

}
