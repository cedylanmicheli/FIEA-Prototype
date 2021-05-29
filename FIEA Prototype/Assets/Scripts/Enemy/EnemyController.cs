using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemyHealth = 50f;
    public float enemySpeed = 3f;
    public float lookRadius = 10f;

    public TrainCar trainCar;

    public Transform target;
    public NavMeshAgent agent;

    public float damage;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;

        trainCar =GameController.instance.activeCar;
    }

    void Update()
    {
        if(target != null)agent.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


   private void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.CompareTag("Bullet"))
       {
            enemyHealth -= PlayerManager.instance.PlayerStats.damage;

            if (enemyHealth <= 0)
            {
                trainCar.ActiveEnemies.Remove(this);
                trainCar.FinishCheck();
                Destroy(gameObject);
            }
        }
   }
}
