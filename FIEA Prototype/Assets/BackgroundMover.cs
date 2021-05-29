using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField]
    private Transform resetPoint;
    [SerializeField]
    private float moveSpeed;

    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);    
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Background Reset"))
        {
            transform.position = resetPoint.position;
        }
    }
}
