using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Prep Item Catagories
public enum PrepItemCate {
    Weapon,
    Equip,
    Consume
}

// Prep Items Properties and FUnctionalities
// - IDs, Catagories, Index
// - Names, Descriptions
// - Highlight, Tick, Pass to Level Prep Main Controller
public class PrepItem: MonoBehaviour {
    [SerializeField]
    PrepItemCate itemCate = PrepItemCate.Weapon;    
    [SerializeField]
    int itemIndex = 0;    // See Documentation for Prefs References
    [SerializeField]
    ItemID itemName = ItemID.Default;    // See Documentation for Item Prefs References
    [SerializeField]
    string itemDesc = "";

    bool bought = false;
    bool interactive = true;

    // Hierachy References using Event Systems
    // - Highlight
    // - Item Icon
    // - Lock SPrite

    void Start() {
        CheckBoughtStatus();
        // Unlock Self if the Item is Bought already (in the Shop)
        if (bought)
            UnlockSelf();
        else
            LockSelf();
    }

    public void MouseEnterHighlight() {
        // !ticked && 
        if (interactive) {
            HighlightSelf();
        }
    }

    public void MouseExitHighlight() {
        DehighlightSelf();
    }

    public PrepItemCate GetCategory() {
        return itemCate;
    }

    public int GetItemIndex() {
        // Set the Prefs of the Selected one and use them In-game
        return itemIndex;
    }

    public void CheckBoughtStatus() {
        string boughtPrefName = itemName + "Bought";
        bought = PlayerPrefs.GetInt(boughtPrefName, 0).Equals(1);
    }

    // Toggling Select Highlight Object (alongside its Animations)
    void HighlightSelf() {
        if (!transform.Find("SelectHighlight").gameObject.activeSelf)
            transform.Find("SelectHighlight").gameObject.SetActive(true);
    }
    void DehighlightSelf() {
        if (transform.Find("SelectHighlight").gameObject.activeSelf)
            transform.Find("SelectHighlight").gameObject.SetActive(false);
    }

    // Effects when Self Selected
    public void TickSelf() {
        DehighlightSelf();
        transform.Find("SelectTick").gameObject.SetActive(true);
    }

    public void UntickSelf() {
        transform.Find("SelectTick").gameObject.SetActive(false);
    }

    void UnlockSelf() {
        interactive = true;
        // Remove Lock Sprite
        transform.Find("Lock").gameObject.SetActive(false);
        // Remove Grey Cover
        transform.Find("LockCover").gameObject.SetActive(false);
        // Interactable
        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    void LockSelf() {
        interactive = false;
        // Lock SPrite
        transform.Find("Lock").gameObject.SetActive(true);
        // Grey Cover
        transform.Find("LockCover").gameObject.SetActive(true);
        // Not Interactable
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
