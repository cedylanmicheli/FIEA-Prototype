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
    private AudioSource doorAudio;

    private void Awake()
    {
        doorAudio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (_doorType == DoorType.Entrance && _triggerType == TriggerType.EnterTrigger)
            {
                doorModelObj.GetComponent<BoxCollider>().enabled = false;
                doorModelObj.GetComponent<MeshRenderer>().enabled = false;

                doorAudio.Play();
            }
            else if (_doorType == DoorType.Exit && _triggerType == TriggerType.EnterTrigger)
            {
                if(parentCar.carCompleted == true)
                {
                    doorModelObj.GetComponent<BoxCollider>().enabled = false;
                    doorModelObj.GetComponent<MeshRenderer>().enabled = false;

                    doorAudio.Play();
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

                doorAudio.Play();
            }
            else if (_doorType == DoorType.Exit && _triggerType == TriggerType.ExitTrigger)
            {
                doorModelObj.GetComponent<BoxCollider>().enabled = true;
                doorModelObj.GetComponent<MeshRenderer>().enabled = true;

                parentCar.EndRoomEffects();
                GetComponent<Collider>().enabled = false;

                doorAudio.Play();
            }
        }

    }

}
