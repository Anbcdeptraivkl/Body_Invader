using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuReturning : MonoBehaviour
{
   public void ReturnToMainMenu()
   {
       SceneManager.LoadScene("MainMenu");
   }
}
