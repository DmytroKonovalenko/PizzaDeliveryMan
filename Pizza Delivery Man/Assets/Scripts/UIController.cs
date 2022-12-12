using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    public GameObject jostickImage;
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        jostickImage.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        jostickImage.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Play()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        jostickImage.SetActive(true);
    }
   
}
