using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    private Vector3 offset;

    void Start()
    {
        Player = PlayerManager.instance.gameObject;
        offset = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Player != null)
        transform.position = Player.transform.position + offset;
    }
}
