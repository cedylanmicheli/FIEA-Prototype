using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainCar : MonoBehaviour
{
    public Transform backOfCar;

    [SerializeField]
    private float enemyCount;

    public float carMaxHealth;
    public float carMoveSpeed;
    public float carDamage;
    public float carAttackSpeed;

    #region Dispaly Vars
    [Header("Display Information")]
    [SerializeField]
    private string carName;
    [SerializeField]
    private string carDescription;
    #endregion

    void Start()
    {
      
      
    }

    
    void Update()
    {
        
    }

    void setText()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameController.instance.SetText(carName, carDescription);
        }
    }
}
