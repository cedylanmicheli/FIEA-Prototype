using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromeCarEnemies : MonoBehaviour
{
    [SerializeField]
    private TrainCar trainCar;

    [SerializeField]
    private float enemyDuplicateTimer; //Time it takes after spawning to duplicate
    private EnemyController parentController;
    private bool scriptActive;
    public bool isDuplicate;

    void Awake()
    {
        trainCar = GameController.instance.activeCar;
        parentController = GetComponent<EnemyController>();
    }

    void Update()
    {
        if (!scriptActive && isDuplicate == false) //Duplicated Enemies can't duplicate further
        {
            scriptActive = true;
            StartCoroutine(Duplicate());
        }
        else if (!scriptActive && isDuplicate == true && parentController.agent.speed == 0)
        {
            scriptActive = true;
            StartCoroutine(SetSpeed());
        }
    }

    private IEnumerator Duplicate()
    {
        yield return new WaitForSeconds(enemyDuplicateTimer);

        EnemyController enemy = Instantiate(trainCar.enemyPrefab, transform.position, Quaternion.Euler(0, 0, 0)).GetComponent<EnemyController>();
        enemy.trainCar = trainCar;
        trainCar.ActiveEnemies.Add(enemy);

        ChromeCarEnemies chromeScript = enemy.GetComponent<ChromeCarEnemies>();
        chromeScript.isDuplicate = true;
        chromeScript.parentController.agent.speed = 0;
    }

    public IEnumerator SetSpeed()
    {
        yield return new WaitForSeconds(2f); //Pause for a moment to separate the parent enemy and the duplicate
        parentController.agent.speed = trainCar.enemyPrefab.GetComponent<EnemyController>().agent.speed;
    }
}


