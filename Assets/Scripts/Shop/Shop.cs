using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Item Types that are Purchasable
public enum ShopItemType {
    HPPack,
    ENPack,
    Missiles,
    DashCooldown,
    ShieldDuration
}

// The References will be Saved into File and Deserilaized then Passed into Player to Process the Necessary Data
[System.Serializable]
public class ShopData {
    public bool HPPack;
    public bool ENPack;
    // Missiles can be bought to maximum 3 per level
    //  - A little Expensive!
    public int Missiles;
    public bool DashCooldown;
    public bool ShieldDuration;
}

// Shop Canvas Behaviours: Managing UIs, Effects and Events inside the Shop Screen
//  - Activating and De-activating Panels based on SHop Infos
//  - Buying and Saving Shopping Data
public class Shop: MonoBehaviour {
    public TextAsset baseShopData;
    public ShopData shopData;
    public int maxMissiles = 3;

    public Text moneyText;

    [SerializeField]
    int money = 0;
    // List of All Panels Components as Children of the Shop UI

    [SerializeField]
    ShopPanel[] itemPanels;

    GraphicRaycaster raycaster;
    ShopPanel selectingPanel;


    void Start() {
        money = PlayerPrefs.GetInt("Money", 0);
        ShowTextMoney();
        // Getting the Shop Data from JSON
        //  - The Data will be Overrided right when there are anything bought, then save back to the JSON file
        SetupShopData();
        // Rayvaster for Selecting Shop Panels
        this.raycaster = gameObject.GetComponent<GraphicRaycaster>();
        // Getting all Panels References
        itemPanels = gameObject.GetComponentsInChildren<ShopPanel>();
        SetPanelsStatus();
        // At the start
        selectingPanel = null;
    }

    void Update() {
        // Detect Mouse Clicks on Shop Item Panels to Set and Reset Selecting Item
        //  - Using Raycast and UI Graphic Methods
        if (Input.GetMouseButtonDown(0)) {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();

            pointerEventData.position = Input.mousePosition;
            raycaster.Raycast(pointerEventData, results);
            
            foreach(RaycastResult result in results) {
                Debug.Log("Casted " + result.gameObject.name);
                ShopPanel clickingPanel = result.gameObject.GetComponent<ShopPanel>();
                // Select Behaviours for Casted Clicked Panel
                if ( clickingPanel != null && clickingPanel.CheckSelectable()) {
                    if (selectingPanel != null)
                        selectingPanel.Deselect();
                    selectingPanel = clickingPanel;
                    selectingPanel.Select();
                }
            }
        }
    }

    void OnDisable() {
        ResetSelectingPanel();
    }

    // Buy the Selected Item when clicking the Buy Button: Behaviours changed on the type of Item Purchasing
    public void BuyItem() {
        switch (selectingPanel.itemType) {
            case ShopItemType.Missiles: {
                if (shopData.Missiles < 3 && money >= selectingPanel.price) {
                    shopData.Missiles++;
                    // Deplete Money
                    money -= selectingPanel.price;
                }
            }
            break;

            case ShopItemType.HPPack: {
                bool bought = shopData.HPPack;
                if (!bought) {
                    shopData.HPPack = true;
                    money -= selectingPanel.price;
                }
            }
            break;

            case ShopItemType.ENPack: {
                bool bought = shopData.ENPack;
                if (!bought) {
                    shopData.ENPack = true;
                    money -= selectingPanel.price;
                }
            }
            break;

            case ShopItemType.DashCooldown: {
                bool bought = shopData.DashCooldown;
                if (!bought) {
                    shopData.DashCooldown = true;
                    money -= selectingPanel.price;
                }
            }
            break;

            case ShopItemType.ShieldDuration: {
                bool bought = shopData.ShieldDuration;
                if (!bought) {
                    shopData.ShieldDuration = true;
                    money -= selectingPanel.price;
                }
            }
            break;
        }
        ResetSelectingPanel();
        // Set New Amount of Money
        PlayerPrefs.SetInt("Money", money);
        ShowTextMoney();
        // Saving the Newly Bought Data back to the File
        //  - The Data will be Overrided right when there are anything bought, then save back to the JSON file
        string newShopData = JsonUtility.ToJson(shopData, true);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/shop-data.json", newShopData);
        SetPanelsStatus();
    }

    // For Debugging Purpose only
    public void Debug_Get1000Money() {
        money += 1000;
        PlayerPrefs.SetInt("Money", money);
        ShowTextMoney();
    }

    public void ResetShopData() {
        shopData.HPPack = false;
        shopData.ENPack = false;
        shopData.DashCooldown = false;
        shopData.Missiles = 0;
        shopData.ShieldDuration = false;
       // Saving the Newly Bought Data back to the File
        //  - The Data will be Overrided right when there are anything bought, then save back to the JSON file
        ResetSelectingPanel();
        string newShopData = JsonUtility.ToJson(shopData, true);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/shop-data.json", newShopData);
        SetPanelsStatus();
    }

    void ShowTextMoney() {
        moneyText.text = money.ToString();
    }

    void SetPanelsStatus() {
        for (int i = 0; i < itemPanels.Length; i++) {
            // Activate first by Default
            itemPanels[i].Activate();
            // Checking Data to Deactivate
            switch(itemPanels[i].itemType) {
                // Missiles COunt
                case ShopItemType.Missiles: {
                    if (shopData.Missiles >= 3) {
                        itemPanels[i].Deactivate();
                    }
                }
                break;

                // Permanent Bought
                default: {
                    string typeName = itemPanels[i].itemType.ToString();
                    bool bought = (bool)shopData.GetType().GetField(typeName).GetValue(shopData);
                    if (bought) {
                        itemPanels[i].Deactivate();
                    }
                }
                break;
            }
        }
    }

    void SetupShopData() {
        shopData = new ShopData();
        // Read File from Persistent Path
        string dataFilePath = Application.persistentDataPath + "/shop-data.json";
        if (System.IO.File.Exists(dataFilePath)) {
            string data = File.ReadAllText(dataFilePath);
            shopData = JsonUtility.FromJson<ShopData>(data);
        } else {
            //  - Or from Original Format if no Data had been saved in the client yet
            shopData = JsonUtility.FromJson<ShopData>(baseShopData.text);
        }
    }

    void ResetSelectingPanel() {
        // Reset Selecting
        selectingPanel.Deselect();
        selectingPanel = null;
    }
}