using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    Debug.Log("AH");
        //    EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        //    enemy.enemyHealth -= PlayerManager.instance.PlayerStats.damage;
        //    enemy.HitCheck();
        //}

        if(collision.collider.CompareTag("Bouncer") == false && collision.collider.CompareTag("Bullet") == false)
        {
            Destroy(gameObject);
        }
      
    }
}
