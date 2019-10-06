using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenuController: MonoBehaviour {
    public GameObject[] panels;

    void Start() {
        ActivatePanel();
    }

    public void ActivatePanel(int index = 0) {
        // Disable all, then re-activate only the current one
        foreach( GameObject panel in panels) {
            panel.SetActive(false);
        }

        panels[index].SetActive(true);
    }

    // Return to Menu after Unloading the Additive Shop Scene
    public void BackToMainMenu() {
        SceneManager.UnloadSceneAsync("Shop");
    }
}