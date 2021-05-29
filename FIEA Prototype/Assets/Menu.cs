using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private string openScene;

    public void StartGame()
    {
        SceneManager.LoadScene(openScene);
    }
}
