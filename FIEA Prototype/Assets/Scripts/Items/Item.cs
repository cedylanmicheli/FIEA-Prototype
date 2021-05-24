using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private string itemDesc;


    [Header("Item Stats")]
    public int itemMaxHealth;
    public float itemMoveSpeed;
    public float itemDamage;
    public float itemAttackSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            this.GetComponent<Collider>().enabled = false;
            transform.SetParent(Inventory.instance.transform);
           
            StartCoroutine(GameController.instance.SetItemText(itemName, itemDesc));
           
            //gameObject.SetActive(false);

            Inventory.instance._Inventory.Add(this);
            Inventory.instance.CalcNewItem(this);
        }
    }

}
