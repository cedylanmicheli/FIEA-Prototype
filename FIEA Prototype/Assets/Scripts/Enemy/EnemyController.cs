using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public TrainCar trainCar;
    
    [Header("Enemy Info")]
    public float enemyHealth = 50f, damage;
    public Transform target;
    public NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
        target = PlayerManager.instance.player.transform;
        trainCar = GameController.instance.activeCar;
    }

    void Update()
    {
        if(target != null)agent.SetDestination(target.position);
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
