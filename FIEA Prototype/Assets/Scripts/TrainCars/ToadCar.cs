using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadCar : MonoBehaviour
{
    [SerializeField]
    private TrainCar parentCar;
    [SerializeField]
    private Transform toadObj;

    void Start()
    {
        parentCar = GetComponent<TrainCar>();
    }

   // public void OnTriggerEnter(Collider other)
   // {
   //     if(other.CompareTag("Enemy"))
   //     {
   //         ToadCarEnemies toadEnemy = other.gameObject.AddComponent<ToadCarEnemies>();
   //         toadEnemy.toadTarget = toadObj;
   //     }
   // }
}
