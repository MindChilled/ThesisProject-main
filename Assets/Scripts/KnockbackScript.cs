using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackScript : MonoBehaviour
{

    public float thrust;
    public int playerDamage;
    public float floatTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log(other + " : this is what knockback detects" );
            Rigidbody enemy = other.GetComponent<Rigidbody>();
            //CombatEnemy combatEnemy = other.GetComponent<CombatEnemy>();
            DummyEnemyScript dummyEnemyScript = other.GetComponent<DummyEnemyScript>();
            dummyEnemyScript.TakeDamage(playerDamage);
            Debug.Log("Knocking enemy back");
            //combatEnemy.ReceiveDamage(playerDamage);
            //Debug.Log(enemy + " : this is enemy GO");
            if (enemy != null)
            {
                //enemy.isKinematic = false;
                Debug.Log("Knocking enemy back");
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode.Impulse);
                //enemy.isKinematic = true;
                StartCoroutine(KnockCo(enemy));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(floatTime);
            enemy.velocity = Vector2.zero;
            //enemy.isKinematic = true;
        }
    }
}
