using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

// Level Preparation - attached as COmponent to the Level Prep UI
// - Setting Item Prefs Unlocking States based on SHop Bought Prefs (excluding the default ones)
// - Picking Items
// - Load Level Scenes
// - Return to Selection Menu
public class LevelPrepare: MonoBehaviour {
    public GameObject[] weaponsPanels;
    public GameObject[] equipsPanels;
    public GameObject[] consumesPanels;

    GameObject selectedWeapon, selectedEquip, selectedConsume;

    //References
    GraphicRaycaster rayCaster;

    void Start() {
        // THe Default ones are always Activated
        // Default Equipment
        PlayerPrefs.SetInt("DashBought", 1);
        // Default Weapon
        PlayerPrefs.SetInt("GunBought", 1);
        // Default Consumable Pack
        PlayerPrefs.SetInt("MissileBought", 1);
        // Default Tick
        selectedWeapon = weaponsPanels[0];
        selectedEquip = equipsPanels[0];
        selectedConsume = consumesPanels[0];
        selectedWeapon.GetComponent<PrepItem>().TickSelf();
        selectedEquip.GetComponent<PrepItem>().TickSelf();
        selectedConsume.GetComponent<PrepItem>().TickSelf();

        this.rayCaster = GetComponent<GraphicRaycaster>();
    }

    void Update() {
        // Raycasting mouse position
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            // Setting up Event Properties
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> hitResults = new List<RaycastResult>();
            pointerData.position = Input.mousePosition;
            this.rayCaster.Raycast(pointerData, hitResults);

            if (hitResults.Count > 0) {
                foreach(RaycastResult result in hitResults) {
                    // Tagging
                    if (result.gameObject.CompareTag("PrepItem")) {
                        Debug.Log("Casted: " + result.gameObject.name);
                        // Swapping between Selecting and Last Selected (based on the Item Categories)
                        switch(result.gameObject.GetComponent<PrepItem>().GetCategory()) {
                            case PrepItemCate.Weapon:
                                SelectingWeapon(result.gameObject);
                            break;

                            case PrepItemCate.Equip:
                                SelectingEquip(result.gameObject);
                            break;

                            case PrepItemCate.Consume:
                                SelectingConsume(result.gameObject);
                            break;
                        }
                    break;
                    }
                }
            }
        }
    }

    public void StartStage() {
        SetItemsUsing();
        LevelSelection.LoadLevel();
    }

    // Checking
    public void Debug_CheckUsing() {
        Debug.Log("Weapon: " + selectedWeapon.gameObject.name);
        Debug.Log("Equip: " + selectedEquip.gameObject.name);
        Debug.Log(" Consume: " + selectedConsume.gameObject.name);
    }

    void SelectingWeapon(GameObject selecting) {
        if (selectedWeapon) {
            // UNtick
            selectedWeapon.GetComponent<PrepItem>().UntickSelf();
            // Swap
            selectedWeapon = selecting;
            // Tick the newly Swapped
            selectedWeapon.GetComponent<PrepItem>().TickSelf();
        } else {  // If currently not selecting anything yet
            selectedWeapon = selecting;
        }

        Debug.Log("Selecting: " + selectedWeapon.gameObject.name);
    }

    void SelectingEquip(GameObject selecting) {
        if (selectedEquip) {
            // UNtick
            selectedEquip.GetComponent<PrepItem>().UntickSelf();
            // Swap
            selectedEquip = selecting;
            // Tick the newly Swapped
            selectedEquip.GetComponent<PrepItem>().TickSelf();
        } else {  // If currently not selecting anything yet
            selectedEquip = selecting;
        }
    }

    void SelectingConsume(GameObject selecting) {
        if (selectedConsume) {
            // UNtick
            selectedConsume.GetComponent<PrepItem>().UntickSelf();
            // Swap
            selectedConsume = selecting;
            // Tick the newly Swapped
            selectedConsume.GetComponent<PrepItem>().TickSelf();
        } else {  // If currently not selecting anything yet
            selectedConsume = selecting;
        }
    }

    void SetItemsUsing() {
        PlayerPrefs.SetInt("UsingWeapon", selectedWeapon.GetComponent<PrepItem>().GetItemIndex());
        PlayerPrefs.SetInt("UsingEquip", selectedEquip.GetComponent<PrepItem>().GetItemIndex());
        PlayerPrefs.SetInt("UsingConsume", selectedConsume.GetComponent<PrepItem>().GetItemIndex());
    }
 
}