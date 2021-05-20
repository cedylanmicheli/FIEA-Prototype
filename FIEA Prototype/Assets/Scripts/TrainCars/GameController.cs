using UnityEngine;
using UnityEngine.AI;
using TMPro;

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
    private Vector3 initalSpawn = new Vector3(0, 0 , 0);

    public TextMeshProUGUI carName;
    public TextMeshProUGUI carDescription;

    public void SetText(string name, string desc)
    {
        carName.text = name;
        carDescription.text = desc;
    }

    void GenerateCars()
    {
        GameObject currentCar = Instantiate(trainCar, initalSpawn, Quaternion.Euler(0, 0, 0));
        
        for(int i = 0; i < carCount - 1; i++)
        {
            GameObject previousCar = currentCar;
            currentCar = Instantiate(trainCar, previousCar.GetComponent<TrainCar>().backOfCar.position, Quaternion.Euler(0, 0, 0));  
        }

        UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }
}
