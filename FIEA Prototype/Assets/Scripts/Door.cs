using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private enum TriggerType
    { 
        EnterTrigger,
        ExitTrigger
    }

    private enum DoorType
    {
        Entrance,
        Exit
    }

    [SerializeField]
    private TriggerType _triggerType;
    [SerializeField]
    private DoorType _doorType;
    [SerializeField]
    private GameObject doorModelObj;

    [SerializeField]
    private TrainCar parentCar;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (_doorType == DoorType.Entrance && _triggerType == TriggerType.EnterTrigger)
            {
                doorModelObj.GetComponent<BoxCollider>().enabled = false;
                doorModelObj.GetComponent<MeshRenderer>().enabled = false;
            }
            else if (_doorType == DoorType.Exit && _triggerType == TriggerType.EnterTrigger)
            {
                if(parentCar.activeCar == false)
                {
                    doorModelObj.GetComponent<BoxCollider>().enabled = false;
                    doorModelObj.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_doorType == DoorType.Entrance && _triggerType == TriggerType.ExitTrigger)
            {
                doorModelObj.GetComponent<BoxCollider>().enabled = true;
                doorModelObj.GetComponent<MeshRenderer>().enabled = true;

                parentCar.ActivateCar();

                GetComponent<Collider>().enabled = false;
            }
            else if (_doorType == DoorType.Exit && _triggerType == TriggerType.ExitTrigger)
            {
                doorModelObj.GetComponent<BoxCollider>().enabled = true;
                doorModelObj.GetComponent<MeshRenderer>().enabled = true;

                parentCar.EndRoomEffects();
                GetComponent<Collider>().enabled = false;
            }
        }

    }

}
