using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem explosion;
    private float lifetime = 10f;
    private AudioSource impact;
    public int enemyDamage = 0; //Only used when EnemyBullet

    private void Start()
    {
        StartCoroutine(DestroyTimer());
        impact = GetComponent<AudioSource>();
    }

    private void DestroyMe()
    {
        GetComponent<MeshRenderer>().enabled = false;
        impact.Play();
        ParticleSystem explosionObj = Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));

        Destroy(explosionObj.gameObject, explosion.main.duration);
        Destroy(gameObject, explosion.main.duration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bouncer") == false && collision.collider.CompareTag("EnemyBullet") == false)
        {
            DestroyMe();
        }
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(lifetime);
        DestroyMe();
    }
}
