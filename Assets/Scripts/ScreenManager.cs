using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
