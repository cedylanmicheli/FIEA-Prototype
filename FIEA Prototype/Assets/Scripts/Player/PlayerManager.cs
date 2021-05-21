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
    public Stats PlayerStats;

    private void StartCurrentStats()
    {
        PlayerStats = new Stats();
        PlayerStats.maxHealth = baseMaxHealth;
        PlayerStats.moveSpeed = baseMoveSpeed;
        PlayerStats.damage = baseDamage;
        PlayerStats.attackSpeed = baseAttackSpeed;
    }

    #region PLAYER STATS
    //These are the base stats the player starts the game with
    [Header("Base Stats")]
    public float baseMaxHealth;
    public float baseMoveSpeed;
    public float baseDamage;
    public float baseAttackSpeed;

    //These are the player's stats at any given moment, including modifiers from items and the train car. Only used in-editor
    [Header("Current Stats")]
    public float currentMaxHealth;
    public float currentMoveSpeed;
    public float currentDamage;
    public float currentAttackSpeed;
    #endregion
}
