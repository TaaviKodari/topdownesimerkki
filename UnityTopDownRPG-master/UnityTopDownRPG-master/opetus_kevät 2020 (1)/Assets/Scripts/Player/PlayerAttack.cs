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
        attackAnimation.GetComponent<Animator>().SetTrigger("Attack");
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
