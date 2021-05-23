using UnityEngine;

public class ToadCarEnemies : MonoBehaviour
{
    private EnemyController parent;
    private Transform playerTarget;
    public Transform toadTarget;

    private  int currentTarget = 0; //0 == player, 1 == frog

    void Awake()
    {
        parent = GetComponent<EnemyController>();   
        playerTarget = PlayerManager.instance.player.transform;
        toadTarget = GameObject.FindWithTag("Toad").transform;
    }

    // Maybe add a cooldown timer to prevent rapid switching
    void Update()
    {
        if(currentTarget!= 0 && Vector3.Distance(transform.position, playerTarget.position) < Vector3.Distance(transform.position, toadTarget.position))
        {
            parent.target = playerTarget;
            currentTarget = 0;
        }
        else if (currentTarget != 1 && Vector3.Distance(transform.position, playerTarget.position) > Vector3.Distance(transform.position, toadTarget.position))
        {
            parent.target = toadTarget;
            currentTarget = 1;
        }
    }
}
