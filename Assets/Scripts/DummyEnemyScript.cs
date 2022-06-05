using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemyScript : EnemyScript
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homeposition;

    [Header("Animator")]
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            //Debug.Log("Chasing");
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            animator.SetBool("IsMove", true);
        }
        else
        {
            //animator.SetBool("IsMove", false);
        }
    }

    public void TakeDamage(int damageTaken)
    {
        health = health - damageTaken;
        Debug.Log("Damaging " + this.gameObject + " for " + damageTaken + " damage");
        if (health <= 0)
        {
            //Debug.Log("Health is 0");
            Destroy(this.gameObject);
        }
    }
}
