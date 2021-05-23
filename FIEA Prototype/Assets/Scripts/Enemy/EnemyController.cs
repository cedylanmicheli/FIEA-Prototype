using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemyHealth = 50;
    public float lookRadius = 10f;

    public TrainCar trainCar;

    public Transform target;
    public NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;

        trainCar =GameController.instance.activeCar;
    
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void HitCheck()
    {
        if(enemyHealth <= 0)
        {
            trainCar.ActiveEnemies.Remove(this);
            Destroy(gameObject);
        }
    }
}
