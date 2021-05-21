using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Collections;

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

    public GameObject trainCar;

    public int carCount;
    private Vector3 initalSpawn = new Vector3(0, 0, 0);
    private float itemDescTime = 7.5f;

    public TextMeshProUGUI carName;
    public TextMeshProUGUI carDescription;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    private void Start()
    {
        carName.text = "";
        carDescription.text = "";
        itemDescription.text = "";
        itemName.text = "";
    }

    public void SetRoomText(string name, string desc)
    {
        carName.text = name;
        carDescription.text = desc;
    }

    void GenerateCars()
    {
        GameObject currentCar = Instantiate(trainCar, initalSpawn, Quaternion.Euler(0, 0, 0));

        for (int i = 0; i < carCount - 1; i++)
        {
            GameObject previousCar = currentCar;
            currentCar = Instantiate(trainCar, previousCar.GetComponent<TrainCar>().backOfCar.position, Quaternion.Euler(0, 0, 0));
        }

        UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }

    public IEnumerator SetItemText(string _itemName, string _itemDescription )
    {
        itemDescription.text = _itemDescription;
        itemName.text = _itemName;
         
        yield return new WaitForSeconds(itemDescTime);
        
        itemDescription.text = "";
        itemName.text = "";
    }
}
