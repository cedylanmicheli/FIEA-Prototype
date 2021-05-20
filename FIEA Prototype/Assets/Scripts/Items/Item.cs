using UnityEngine;

public class Item : MonoBehaviour
{

    [Header("Item Stats")]
    public float itemMaxHealth;
    public float itemMoveSpeed;
    public float itemDamage;
    public float itemAttackSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            transform.SetParent(Inventory.instance.transform);
            gameObject.SetActive(false);

            Inventory.instance._Inventory.Add(this);
            Inventory.instance.CalcNewItem(this);
        }
    }

}
