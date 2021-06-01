using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Prefabs and Transforms")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform bulletParent;

    [Header("Force & Scale")]
    public float bulletForce = 20f;
    public Vector3 bulletScale;
    private float bulletTimer;

    private void Awake()
    {
        bulletScale = bulletPrefab.transform.localScale;
    }

    void Update()
    {
        bulletTimer -= PlayerManager.instance.PlayerStats.attackSpeed * Time.deltaTime;
        if(Input.GetButton("Fire1") && bulletTimer <= 0)
        {
            bulletTimer = .5f;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.localScale = bulletScale;

        bullet.transform.parent = bulletParent;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
