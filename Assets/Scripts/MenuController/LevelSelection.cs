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

    static int openingLevel = 0;

    void Start() {
        int levels = PlayerPrefs.GetInt("LevelsDone", 0);

        // Unlocked levels based on approritate COmpleted ones
        for (int i = 0; i <= levels; i++) {
            UnlockLevel(i);
        }
    }

    // Load Scenes (index-based)
    public void LoadLevel(int index) {
        string levelName = "Level" + index.ToString();
        SceneManager.LoadScene(levelName);
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
