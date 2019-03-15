using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarting : MonoBehaviour
{
    //Restart the Scene / Level:
    public void OnScenceRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
