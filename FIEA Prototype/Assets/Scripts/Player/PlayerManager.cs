using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region SINGLETON
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;

        StartCurrentStats();
    }
    #endregion

    public GameObject player;
    private void StartCurrentStats()
    {
        currentMaxHealth = baseMaxHealth;
        currentMoveSpeed = baseMoveSpeed;
        currentDamage = baseDamage;
        currentAttackSpeed = baseAttackSpeed;
    }

    #region PLAYER STATS
    [Header("Base Stats")]
    public float baseMaxHealth;
    public float baseMoveSpeed;
    public float baseDamage;
    public float baseAttackSpeed;

    [Header("Current Stats")]
    public float currentMaxHealth;
    public float currentMoveSpeed;
    public float currentDamage;
    public float currentAttackSpeed;
    #endregion
}
