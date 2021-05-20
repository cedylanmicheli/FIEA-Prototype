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

    public void FullRecalculate()
    {
        foreach(Item item in _Inventory)
        {
            PlayerManager.instance.currentAttackSpeed += item.itemAttackSpeed;
        }
    }

    public void CalcNewItem(Item item)
    {
        PlayerManager.instance.currentMaxHealth += item.itemMaxHealth;
        PlayerManager.instance.currentMoveSpeed += item.itemMoveSpeed;
        PlayerManager.instance.currentDamage += item.itemDamage;
        PlayerManager.instance.currentAttackSpeed += item.itemAttackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
