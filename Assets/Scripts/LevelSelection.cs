using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Level Manager for the Level Selection Screen:
// (Will implement the Locking and Unlocking Levels features later)
public class LevelSelection : MonoBehaviour
{
    public void LoadLevel1() {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2() {
        SceneManager.LoadScene("Level2");
    }

    // Go to Shop Scene Additively
    public void AddLoadShopScene() {
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }
}
