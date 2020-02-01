using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Items Names Table
// Will be used to Setting and Getting Prefs, and as references to check for available Upgrades in Level Prepare UIs
public enum ItemID {
    Dash, Drone, Shield,
    Gun, Flame, Beam,
    Missile, HPPack, ENPack,
    Default = -1
}

// The Individual Panel Functions on Spawning, Selecting and Toggling (for each Item Panel)
public class ItemPanel: MonoBehaviour {
    public GameObject panelHighlight;
    public GameObject soldRibbon;

    // Properties
    [SerializeField]
    ItemID itemName = ItemID.Default;

    [SerializeField]
    int price = 0;

    // Selection State
    bool selecting;
    bool sold;

    void Start() {
        selecting = false;
        sold = false;
    }

    // Toggling selecting and highlighting
    public void Toggle() {
        if (!sold) {
            selecting = !selecting;
            CheckSelect();
        }
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
        // Re-Toggle
        Toggle();
        // Update Sold status
        sold = true;
        // Sold Ribbons
        soldRibbon.SetActive(true);
        // Colored Layer
    }
    
    public string GetItemName() {
        return itemName.ToString();
    }

    public int GetItemPrice() {
        if (price < 0) {
            Debug.Log("Error: Negative item's price");
            return 0;
        }
        return price;
    }

    public void Debug_Unsold() {
        soldRibbon.SetActive(false);
        sold = false;
    }

}