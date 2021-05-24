using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflektorVariant : MonoBehaviour
{

    private int deflectChance = 25;
    private EnemyController parentEnemy;
    private TrainCar trainCar;
    private bool bulletReflected = false;

    Rigidbody bulletRB;

    private void Awake()
    {
        parentEnemy = GetComponent<EnemyController>();
        trainCar = parentEnemy.trainCar;
    }

    private void Update()
    {
        if(bulletReflected) bulletRB.position = Vector3.MoveTowards(bulletRB.position, trainCar.ActiveEnemies[1].GetComponent<Rigidbody>().position, 2);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            if (trainCar.ActiveEnemies.Count > 1)
            {
                bulletRB = other.gameObject.GetComponent<Rigidbody>();
                //bulletRB.MovePosition(trainCar.ActiveEnemies[1].GetComponent<Rigidbody>().position);
                bulletRB.velocity = Vector3.zero;
                bulletReflected = true;
                
            }
        }
    }
}
