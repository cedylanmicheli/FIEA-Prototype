using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

    #region SINGLETON
    public static GameController instance;
    private void Awake()
    {
        instance = this;
        GenerateCars();
    }
    #endregion

    public List<GameObject> trainCars = new List<GameObject>();

    public int carCount;
    
    private Vector3 initalSpawn = new Vector3(0, 0, 0);

    public TrainCar activeCar;
    

    [Header("TMP")][SerializeField]
    private float itemDescTime = 7.5f;
    [SerializeField]
    private TextMeshProUGUI carName, carDescription, itemName, itemDescription;

    private void Start()
    {
        carName.text = "";
        carDescription.text = "";
        itemDescription.text = "";
        itemName.text = "";
    }

    public void SetRoomText(string _carName, string _carDescription)
    {
        carName.text = _carName;
        carDescription.text = _carDescription;
    }

    void GenerateCars()
    {
        GameObject currentCar = Instantiate(trainCars[0], initalSpawn, Quaternion.Euler(0, 0, 0));
        trainCars.RemoveAt(0);

        for (int i = 0; i < carCount - 1; i++)
        {
            GameObject previousCar = currentCar;

            int index = UnityEngine.Random.Range(0, trainCars.Count );
            currentCar = Instantiate(trainCars[index], previousCar.GetComponent<TrainCar>().backOfCar.position, Quaternion.Euler(0, 0, 0));
            trainCars.RemoveAt(index);
        }

        UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }

    public IEnumerator SetItemText(string _itemName, string _itemDescription, Item item )
    {
        itemDescription.text = _itemDescription;
        itemName.text = _itemName;
         
        yield return new WaitForSeconds(itemDescTime);
        
        itemDescription.text = "";
        itemName.text = "";
        item.gameObject.SetActive(false);
    }
}
