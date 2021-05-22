using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromeCar : MonoBehaviour
{
    private TrainCar trainCar;

    [SerializeField]
    private float enemyDuplicateTimer;
    private bool scriptActive;

    void Awake()
    {
        trainCar = GetComponent<TrainCar>();
    }

    
    void Update()
    {
        if(trainCar.activeCar && !scriptActive)
        {
            scriptActive = true;
            StartCoroutine(EnemyDuplicator());
        }
    }

    private IEnumerator EnemyDuplicator()
    {
        yield return new WaitForSeconds(enemyDuplicateTimer);

        GameObject enemyToDupe = trainCar.ActiveEnemies[UnityEngine.Random.Range(0, trainCar.ActiveEnemies.Count)].gameObject;
        Transform spawnPosition = enemyToDupe.transform;

        yield return new WaitForSeconds(1);

        EnemyController enemy = Instantiate(trainCar.enemyPrefab, spawnPosition.position, Quaternion.Euler(0, 0, 0)).GetComponent<EnemyController>();
        enemy.trainCar = trainCar;
        trainCar.ActiveEnemies.Add(enemy);
    }
}


