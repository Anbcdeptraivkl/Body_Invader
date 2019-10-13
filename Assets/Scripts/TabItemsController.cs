using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// The Tabs's Component to control and manipulate Item Panels
public class TabItemsController: MonoBehaviour {
    // List of tagged "ItemPanel" objects inside the Tabs
    static GameObject selectingPanel;

    void Start() {
        selectingPanel = null;
    }
    
    void Update() {
        // Select on left mouse click
        if (Input.GetMouseButtonDown(0)) {
            SelectPanel();
        }
    }

    // Using EventSystem's RaycastAll
    void SelectPanel() {
        //Pointer Event Data
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        // Raycast Objects List
        List<RaycastResult> hitsList = new List<RaycastResult>();

        // Raycasting All
        EventSystem.current.RaycastAll(pointer, hitsList);

        // If something got casted
        if (hitsList.Count > 0) {
            Debug.Log("Raycasted!");

            foreach(RaycastResult hit in hitsList) {
                // Checking Tag
                if (hit.gameObject.CompareTag("ItemPanel")) {
                    Debug.Log("Clicked: " + hit.gameObject.name);

                    // Selecting and highlighting
                    // Toggling 
                    if (selectingPanel) {
                        selectingPanel.GetComponent<ItemPanelBehaviours>().Toggle();
                    }

                    hit.gameObject.GetComponent<ItemPanelBehaviours>().Toggle();
                    // Place-Holding
                    selectingPanel = hit.gameObject;

                    // Terminated
                    break;
                }
            }
        }
    }

    // Buy on clicking the Buy Button (Button Click Events)
    public void BuySelectingItem() {

    }
}