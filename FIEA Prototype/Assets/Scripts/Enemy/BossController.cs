using UnityEngine;

public class BossController : MonoBehaviour
{

    [Header("Transform/Prefab")]
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private int damage;
    private float shootTimer, TimeToShoot = 3f, enemyMaxHealth, speed = 0;
    private EnemyController enemyController;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        enemyController.agent.speed = speed;

        enemyMaxHealth = enemyController.enemyHealth;
        bulletPrefab.GetComponent<Bullet>().enemyDamage = damage;
    }

    private void Update()
    {
        transform.LookAt(enemyController.target);
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0) Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * 60f, ForceMode.Impulse);
        shootTimer = Mathf.Clamp(enemyController.enemyHealth / enemyMaxHealth * TimeToShoot, 1, TimeToShoot); //Gets faster with lower health
        
    }
}
