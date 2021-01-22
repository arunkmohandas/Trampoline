using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{


    public Image forceFillBar;
    public GameObject startButton;
    public GameObject pauseButton;
    public GameObject resumeButton;


    private void Start()
    {
        startButton.SetActive(true);
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
        Time.timeScale = 0;
    }



    public void StartGamePlay()
    {
        startButton.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void OnResume()
    {
        Time.timeScale = 1;
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }
}
