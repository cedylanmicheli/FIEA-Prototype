using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region SINGLETON
    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<Item> _Inventory;
    public Stats _playerStats;
    public int healthOnPickup = 15;

    public void CalcNewItem(Item item)
    {
        _playerStats = PlayerManager.instance.PlayerStats;

        _playerStats.maxHealth += item.itemMaxHealth;
        _playerStats.moveSpeed *= item.itemMoveSpeed;
        _playerStats.damage *= item.itemDamage;
        _playerStats.attackSpeed *= item.itemAttackSpeed;

        _playerStats.health += healthOnPickup;
        _playerStats.health = Mathf.Clamp(_playerStats.health, 0, _playerStats.maxHealth);

        PlayerManager.instance.healthBar.SetMaxHealth(_playerStats.maxHealth);
        PlayerManager.instance.PlayerStats = _playerStats;
        PlayerManager.instance.PlayerStats.UpdateCurrentInEditor();
    }

}
