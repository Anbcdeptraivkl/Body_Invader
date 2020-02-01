using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Level Manager for the Level Selection Screen
// Managing the Lock/Unlocking processes in combination with the Levels Controller's Level COmplete Scripts
// (Will implement the Locking and Unlocking Levels features later)
public class LevelSelection : MonoBehaviour
{
    public GameObject[] levelPanels;
    public GameObject prepareScreen;

    static int openingLevel = 0;

    void Start() {
        int levels = PlayerPrefs.GetInt("LevelsDone", 0);

        // Unlocked levels based on approritate COmpleted ones
        for (int i = 0; i <= levels; i++) {
            UnlockLevel(i);
        }
    }

    // Open Pre-battle Preparation UI and setting the Level to open
    public void Prepare(int index) {
        openingLevel = index;
        prepareScreen.SetActive(true);
    }

    public void ReturnToSelect() {
        prepareScreen.SetActive(false);
        openingLevel = 0;
    }

    // Load Scenes (index-based)
    public static void LoadLevel() {
        string levelName = "Level" + openingLevel.ToString();
        SceneManager.LoadScene(levelName);
        Debug.Log("Loaded " + levelName);
    }

    // Go to Shop Scene Additively
    public void AddLoadShopScene() {
        // If not loaded yet, load
        if (!SceneManager.GetSceneByName("Shop").isLoaded) {
            SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
        }
    }

    // Reset Level COmpletion Pref to Default 0
    public void ResetLevelPrefs() {
        PlayerPrefs.SetInt("LevelsDone", 0);

        // Re-lock Reseted levels, outside of the default First Lv
        for (int i = 1; i < levelPanels.Length; i++) {
            LockLevel(i);
        }
    }

    void UnlockLevel(int lvIndex) {
        // Lock Sprite
        levelPanels[lvIndex].transform.Find("Lock").gameObject.SetActive(false);
        // Fade COlor Cover
        levelPanels[lvIndex].transform.Find("LockCover").gameObject.SetActive(false);
        // Interactable
        levelPanels[lvIndex].GetComponent<Button>().interactable = true;
    }

    void LockLevel(int lvIndex) {
        levelPanels[lvIndex].transform.Find("Lock").gameObject.SetActive(true);
        levelPanels[lvIndex].transform.Find("LockCover").gameObject.SetActive(true);
        levelPanels[lvIndex].GetComponent<Button>().interactable = false;
    }
}
