using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TrainCar : MonoBehaviour
{
    public Transform backOfCar;
    public GameObject enemyPrefab;
    

    [SerializeField]
    private Transform SpawnParent, Enemies;
    private Transform[] SpawnPoints;

    [Header("Enemy Info")]
    public int MaxEnemiesInCar;
    [SerializeField]
    private float enemiesToSpawn, timeBtwnEnemySpawn;


    [Header("Plater Stat Changes")]
    public float carDamage;
    [Range(0, 2)]
    public float carAttackSpeed = 1;
    [Range(0, 2)]
    public float carMoveSpeed = 1;

    private Stats _playerStats;
   

    public bool activeCar;
    public bool carCompleted = false;
    private bool SpawnTimer = true;
    public List<EnemyController> ActiveEnemies = new List<EnemyController>();

    #region Dispaly Vars
    [Header("Display Information")]
    [SerializeField]
    private string carName;
    [SerializeField]
    private string carDescription;
    #endregion

    void Start()
    {
        //Sets Waypoints in Car
        SpawnPoints = new Transform[SpawnParent.childCount];
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            SpawnPoints[i] = SpawnParent.GetChild(i);
        }

    }

    
    void Update()
    {
        if (activeCar)
        {
            if (SpawnTimer && ActiveEnemies.Count < MaxEnemiesInCar)
                StartCoroutine(EnemySpawner());
            else if (enemiesToSpawn <= 0) activeCar = false;
        }
    }

    private IEnumerator EnemySpawner()
    {
        int index = UnityEngine.Random.Range(0, SpawnPoints.Length);
        EnemyController enemy = Instantiate(enemyPrefab, SpawnPoints[index].transform.position, Quaternion.Euler(0, 0, 0)).GetComponent<EnemyController>();
        //enemy.gameObject.transform.parent = Enemies;
        enemy.trainCar = this;
        ActiveEnemies.Add(enemy);

        enemiesToSpawn--;
        if (enemiesToSpawn <= 0) activeCar = false;

        SpawnTimer = false;
        yield return new WaitForSeconds(5);
        SpawnTimer = true;
    }

  //  private void OnTriggerEnter(Collider other)
  //  {
  //      if(other.CompareTag("Player"))
  //      {
  //          ActivateCar();
  //      }
  //  }

    public void ActivateCar()
    {
        GameController.instance.SetRoomText(carName, carDescription);
        GetComponent<Collider>().enabled = false;
        CalcRoomEffects();
        activeCar = true;
    }

    #region Start/End Room Effects
    public void CalcRoomEffects()
    {
        _playerStats = PlayerManager.instance.PlayerStats;

        _playerStats.moveSpeed *= carMoveSpeed;
        _playerStats.damage += carDamage;
        _playerStats.attackSpeed *= carAttackSpeed;

        PlayerManager.instance.PlayerStats = _playerStats;
        PlayerManager.instance.PlayerStats.UpdateCurrentInEditor();
    }

    public void EndRoomEffects()
    {
        _playerStats = PlayerManager.instance.PlayerStats;

        PlayerManager.instance.PlayerStats.moveSpeed /= carMoveSpeed;
        PlayerManager.instance.PlayerStats.damage += carDamage;
        PlayerManager.instance.PlayerStats.attackSpeed /= carAttackSpeed;

        PlayerManager.instance.PlayerStats = _playerStats;
    }
    #endregion
}
