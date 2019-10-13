using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Individual Panel Functions on Spawning, Selecting and Toggling (for each Item Panel)
public class ItemPanelBehaviours: MonoBehaviour {
    public GameObject panelHighlight;
    public GameObject soldRibbon;

    // Selection State
    bool selecting;

    void Start() {
        selecting = false;
    }

    // Toggling selecting and highlighting
    public void Toggle() {
        selecting = !selecting;
        CheckSelect();
    }

    // Select and Deselect
    void CheckSelect() {
        if (selecting) {
            panelHighlight.SetActive(true);
            Debug.Log("Selected: " + gameObject.name);
        } else {
            panelHighlight.SetActive(false);
            Debug.Log("Deselected: " + gameObject.name);
        }
    }

    // Using Bought Data stored in Prefs to show SOLD ribbons on Item Panels
    public void Sold() {

    }

    public void Unsold() {

    }
}