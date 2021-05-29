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

    public Transform itemSpawnLocation;

    [Header("Enemy Info")]
    public int MaxEnemiesInCar;
    [SerializeField]
    private float enemiesToSpawn, timeBtwnEnemySpawn;


    [Header("Plater Stat Changes")]
    [Range(0, 2)]
    public float carDamage = 1;
    [Range(0, 2)]
    public float carAttackSpeed = 1;
    [Range(0, 2)]
    public float carMoveSpeed = 1;
    public Vector3 carPlayerScale = new Vector3(1, 1, 1);


    private Vector3 defaultPlayerScale;

    private Stats _playerStats;

    [Header("Enemy Stat Changes")]
    [Range(0, 2)]
    public float enemyAddDamage = 1;
    [Range(0, 2)]
    public float enemyMoveSpeed = 1;
    public Vector3 enemyScale = new Vector3(1, 1, 1);


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

        defaultPlayerScale = PlayerManager.instance.player.transform.localScale;

    }

    
    void Update()
    {
        if (activeCar)
        {
            if (SpawnTimer && ActiveEnemies.Count < MaxEnemiesInCar && enemiesToSpawn > 0)
                StartCoroutine(EnemySpawner());
            else FinishCheck();
        }
    }

    private IEnumerator EnemySpawner()
    {
        int index = UnityEngine.Random.Range(0, SpawnPoints.Length);
        EnemyController enemy = Instantiate(enemyPrefab, SpawnPoints[index].transform.position, Quaternion.Euler(0, 0, 0)).GetComponent<EnemyController>();
        //enemy.gameObject.transform.parent = Enemies;
        enemy.trainCar = this;

        ChangeEnemyStats(enemy);

        ActiveEnemies.Add(enemy);

        enemiesToSpawn--;

        SpawnTimer = false;
        yield return new WaitForSeconds(timeBtwnEnemySpawn);
        SpawnTimer = true;
    }

    public void FinishCheck()
    {
        if(ActiveEnemies.Count == 0 && enemiesToSpawn <= 0)
        {
            activeCar = false;
            if (gameObject.name.Equals("Tutorial Car(Clone)") == false) // this is kinda gross, fix this
            {
                GameController.instance.SetRoomText("car complete!", "get your item on the way out!");
                //play audio chime
                GameController.instance.SpawnItem();
            }
            carCompleted = true;
        }
    }

    public void ActivateCar()
    {
        GameController.instance.SetRoomText(carName, carDescription);
        CalcRoomEffects();
        
        activeCar = true;
        GameController.instance.activeCar = this;
    }


    #region Start/End Room Effects
    public void CalcRoomEffects()
    {
        _playerStats = PlayerManager.instance.PlayerStats;

        _playerStats.moveSpeed *= carMoveSpeed;
        _playerStats.damage *= carDamage;
        _playerStats.attackSpeed *= carAttackSpeed;

        PlayerManager.instance.player.transform.localScale = carPlayerScale;
        if (carAttackSpeed > 1) PlayerManager.instance.player.GetComponent<Weapon>().bulletForce *= carAttackSpeed;

        PlayerManager.instance.PlayerStats = _playerStats;
        PlayerManager.instance.PlayerStats.UpdateCurrentInEditor();
    }

    public void EndRoomEffects()
    {
        _playerStats = PlayerManager.instance.PlayerStats;

        _playerStats.moveSpeed /= carMoveSpeed;
        _playerStats.damage /= carDamage;
        _playerStats.attackSpeed /= carAttackSpeed;

        PlayerManager.instance.player.transform.localScale = defaultPlayerScale;
        if (carAttackSpeed > 1) PlayerManager.instance.player.GetComponent<Weapon>().bulletForce /= carAttackSpeed;

        PlayerManager.instance.PlayerStats = _playerStats;
        PlayerManager.instance.PlayerStats.UpdateCurrentInEditor();
    }

    private void ChangeEnemyStats(EnemyController enemy)
    {
        enemy.damage *= enemyAddDamage;
        enemy.agent.speed *= enemyMoveSpeed;
        enemy.transform.localScale = enemyScale;
    }
    #endregion
}
