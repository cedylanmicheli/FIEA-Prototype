using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem explosion;
    private float lifetime = 10f;

    private void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    private void DestroyMe()
    {
        ParticleSystem explosionObj = Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(explosionObj.gameObject, explosion.main.duration);
        Destroy(gameObject, explosion.main.duration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bouncer") == false)
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
