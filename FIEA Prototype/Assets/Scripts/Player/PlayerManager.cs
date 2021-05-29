using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region SINGLETON
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;

        SetStartingStats();

        healthBar.SetMaxHealth(PlayerStats.maxHealth);
        healthBar.SetHealth(PlayerStats.health);
    }

    private void SetStartingStats()
    {
        PlayerStats = new Stats();
        PlayerStats.maxHealth = baseMaxHealth;
        PlayerStats.moveSpeed = baseMoveSpeed;
        PlayerStats.damage = baseDamage;
        PlayerStats.attackSpeed = baseAttackSpeed;
        PlayerStats.health = baseMaxHealth;

        PlayerStats.UpdateCurrentInEditor();
    }

    #endregion

    public GameObject player;
    public Stats PlayerStats;
    public HeathBar healthBar;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            DamagePlayer((int)enemy.damage);
            GameController.instance.activeCar.ActiveEnemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }
    }

    public void DamagePlayer(int damage)
    {
        PlayerStats.health -= damage;
        healthBar.SetHealth(PlayerStats.health);
        PlayerStats.UpdateCurrentInEditor();

        if(PlayerStats.health <= 0) //Game Over
        {
            GameController.instance.menuObj.SetActive(true);
            GameController.instance.activeCar.activeCar = false;
            Destroy(gameObject);
            //GameController.instance.activeCar.ActiveEnemies.Clear();
        }
    }

    #region PLAYER STATS
    //These are the base stats the player starts the game with
    [Header("Base Stats")]
    public int baseMaxHealth;
    public float baseMoveSpeed;
    public float baseDamage;
    public float baseAttackSpeed;

    //These are the player's stats at any given moment, including modifiers from items and the train car. Only used in-editor
    [Header("Current Stats")]
    public int currentMaxHealth;
    public float currentMoveSpeed;
    public float currentDamage;
    public float currentAttackSpeed;
    public float currentHealth;
    #endregion
}
