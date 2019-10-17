using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Shop Component to Manipulate Menu Elements
// - Switching Tabs
// - Selecting Panels
// - Buying
// - Debugging Functions
public class ShopMenuController: MonoBehaviour {
    public GameObject[] tabs;

    public Text shopCoinText;

    [SerializeField]
    float moneyTiming = 0.2f;

    int currentMoney;

    // Tagged ItemPanel that are being selected
    static GameObject selectingPanel;


    void Start() {
        ActivateTab();

        // Only use in Shop, still available in other scenes, though:
        currentMoney = PlayerPrefs.GetInt("Money", 0);

        selectingPanel = null;
    }

    void Update() {
        InputHandler();
        UpdateCoinText();
    }

    public void ActivateTab(int index = 0) {
        // Disable all, then re-activate only the current one
        foreach( GameObject tab in tabs) {
            tab.SetActive(false);
        }

        tabs[index].SetActive(true);
    }

    // Return to Menu after Unloading the Additive Shop Scene
    public void BackToMainMenu() {
        // set Current Money to Prefs
        PlayerPrefs.SetInt("Money", currentMoney);

        SceneManager.UnloadSceneAsync("Shop");
    }

    // Buy on clicking the Buy Button (Button Click Events)
    // Will be attached to the Main Buy Button
    public void BuySelectingItem() {
        // Get Component Ref
        ItemPanel item = selectingPanel.GetComponent<ItemPanel>();

        // Deplete Money - using Item Price
        bool ableToBuy = SpendMoney(item.GetItemPrice());

        if (!ableToBuy) {
            Debug.Log("Not enought money to buy");
            return;
        }

        // Setting PlayerPrefs (0: not Bought, 1: Bought) - using Item Name
        string prefKey = item.GetItemName() + "Bought";
        Debug.Log("Buying... Setting " + prefKey);
        PlayerPrefs.SetInt(prefKey, 1);

        // Sold Effects
        item.Sold();

        // Reset Selecting Item to Null (can now buy others)
        selectingPanel = null;
    }

    public void Debug_SpendMoney(int amount) {
        SpendMoney(amount);
    }

    bool SpendMoney(int amount) {
        // Valid amount:
        if (currentMoney >= amount) {
            StartCoroutine(DepleteMoneyGradually(amount));
            Debug.Log("Spent " + amount + " Coins!");
            return true;
        } else {
            Debug.Log("Insufficient amount of money");
            return false;
        }
    }

    // Increase money for Debugging and Testing purpose
    public void Debug_GetMoney(int amount) {
        currentMoney += amount;
         // Re-set the Money Bank:
        PlayerPrefs.SetInt("Money", currentMoney);
    }

    public void Debug_GetBoughtStatus() {
        if (selectingPanel == null) {
            Debug.Log("No Selection available");
            return;
        }

        ItemPanel item = selectingPanel.GetComponent<ItemPanel>();

        // Getting Bought Status PlayerPrefs - using Item Name
        string prefKey = item.GetItemName() + "Bought";
        Debug.Log("Getting " + prefKey);

        // Check and Report
        int bought = PlayerPrefs.GetInt(prefKey, 0);
        if (bought == 1) {
            Debug.Log(item.GetItemName() + " is Bought");
        } else if (bought == 0) {
            Debug.Log(item.GetItemName() + " isn't Bought yet");
        }
    }

    public void Debug_ResetAllPurchases() {
        // Loop through all ItemPanel in the Scene
        ItemPanel[] items = FindObjectsOfType<ItemPanel>();

        foreach (ItemPanel item in items) {
            // Reset Prefs
            // Setting PlayerPrefs - using Item Name
            string prefKey = item.GetItemName() + "Bought";
            Debug.Log("Resetting " + prefKey);

            int boughtBefore = PlayerPrefs.GetInt(prefKey, 0);

            PlayerPrefs.SetInt(prefKey, 0);

            // If Bought Before
            if (boughtBefore == 1) {
                // Unsold
                item.Debug_Unsold();
                // Restore Money
                currentMoney += item.GetItemPrice();
            }
        }
    }

    void InputHandler() {
        // Select on left mouse click
        if (Input.GetMouseButtonDown(0)) {
            SelectPanel();
        }
    }

    void UpdateCoinText() {
        shopCoinText.text = currentMoney.ToString();
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
                        selectingPanel.GetComponent<ItemPanel>().Toggle();
                    }

                    hit.gameObject.GetComponent<ItemPanel>().Toggle();
                    // Place-Holding
                    selectingPanel = hit.gameObject;

                    // Terminated
                    break;
                }
            }
        }
    }

    IEnumerator DepleteMoneyGradually(int amount) {
        int targetCount = currentMoney - amount;
        float incermentWait = moneyTiming / amount;
        while (currentMoney > targetCount) {
            // Deplete with Increment
            currentMoney -= 10;

            yield return new WaitForSeconds(incermentWait);
        }

        // Re-set the Money Bank:
        PlayerPrefs.SetInt("Money", currentMoney);
    }
}