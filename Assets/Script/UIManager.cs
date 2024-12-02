using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    // Start is called before the first frame update
    public GameObject pausePanel;
    public GameObject pauseButton;

    public void ShowPauseButton(bool buttonShow)
    {
        pauseButton.SetActive(buttonShow);
    }
    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
    }

    public void ShowPausePanel()
    {
        PauseSequence();
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        ResumeSequence();
        HidePausePanel();
    }
    public void BackTomMain()
    {
        ResumeSequence();
        HidePausePanel();
        Invoke("ReloadLevel",0f);
    }

    private void PauseSequence()
    {
        Time.timeScale = 0;
    }

    private void ResumeSequence()
    {
        Time.timeScale = 1;
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
