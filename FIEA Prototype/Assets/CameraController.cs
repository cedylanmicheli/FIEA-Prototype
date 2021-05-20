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
        Player = GameObject.FindGameObjectWithTag("Player");
        offset = Player.transform.position + this.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
