using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromeCarEnemies : MonoBehaviour
{
    [SerializeField]
    private TrainCar trainCar;

    [SerializeField]
    private float enemyDuplicateTimer;
    private bool scriptActive;
    public bool isDuplicate;

    void Awake()
    {
        trainCar = GameController.instance.activeCar;
    }

    
    void Update()
    {
        if (!scriptActive && isDuplicate == false)
        {
            scriptActive = true;
            StartCoroutine(Duplicate());
        }
    }

      private IEnumerator Duplicate()
      {
         yield return new WaitForSeconds(enemyDuplicateTimer);

         Transform spawnPosition = transform;
    
         EnemyController enemy = Instantiate(trainCar.enemyPrefab, spawnPosition.position, Quaternion.Euler(0, 0, 0)).GetComponent<EnemyController>();
         enemy.GetComponent<ChromeCarEnemies>().isDuplicate = true;
         enemy.trainCar = trainCar;
         trainCar.ActiveEnemies.Add(enemy);

         enemy.agent.speed = 0;
        
         yield return new WaitForSeconds(.75f);

         enemy.agent.speed = trainCar.enemyPrefab.GetComponent<EnemyController>().agent.speed;

    }
}


