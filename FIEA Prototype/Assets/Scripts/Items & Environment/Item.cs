using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private string itemDesc;

    [SerializeField]
    private Transform model;

    private int rotateSpeed = 20;


    [Header("Item Stats")]
    public int itemMaxHealth;
    [Range(1, 2)]
    public float itemMoveSpeed;
    [Range(1, 2)]
    public float itemDamage;
    [Range(1, 2)]
    public float itemAttackSpeed;

    [Range(1, 2)]
    public float bulletScale;
    public float bulletForce;

    private void Update()
    {
        model.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0), Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            transform.SetParent(Inventory.instance.transform);
           
            StartCoroutine(GameController.instance.SetItemText(itemName, itemDesc, this));
            
            if(bulletScale > 1)
            {
                Weapon weaponScript = PlayerManager.instance.gameObject.GetComponent<Weapon>();
                weaponScript.bulletScale = new Vector3(weaponScript.bulletScale.x * bulletScale, weaponScript.bulletScale.y * bulletScale, weaponScript.bulletScale.z * bulletScale);
            }

            if(bulletForce > 0)
            {
                Weapon weaponScript = PlayerManager.instance.gameObject.GetComponent<Weapon>();
                weaponScript.bulletForce += bulletForce;
            }
           
            model.gameObject.SetActive(false);

            Inventory.instance._Inventory.Add(this);
            Inventory.instance.CalcNewItem(this);
        }
    }

}
