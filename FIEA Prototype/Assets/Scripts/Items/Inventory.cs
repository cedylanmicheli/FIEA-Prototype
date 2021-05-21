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

    public void CalcNewItem(Item item)
    {
        _playerStats = PlayerManager.instance.PlayerStats;

        _playerStats.maxHealth += item.itemMaxHealth;
        _playerStats.moveSpeed *= item.itemMoveSpeed;
        _playerStats.damage += item.itemDamage;
        _playerStats.attackSpeed *= item.itemAttackSpeed;

        PlayerManager.instance.PlayerStats = _playerStats;
        PlayerManager.instance.PlayerStats.UpdateCurrentInEditor();
    }

}
