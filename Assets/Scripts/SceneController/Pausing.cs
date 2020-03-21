using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    //Static checker var for pausing state:
    public static bool isPausing;
    public GameObject pauseMenu;

    public GameObject confirmMessage;

    //Reference:
    private PlayerController playerController;

    void Start()
    {
        isPausing = false;
        //Get player controller reference:
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        //Pause and Unpause on key pressed:
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPausing)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        playerController.enabled = false;
        isPausing = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        playerController.enabled = true;
        isPausing = false;
    }

    public void LoadMenuFromPause()
    {
        Time.timeScale = 1f;
        playerController.enabled = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void Alert() {
        confirmMessage.SetActive(true);
    }

    public void ReturnAlert() {
        confirmMessage.SetActive(false);
    }
}
