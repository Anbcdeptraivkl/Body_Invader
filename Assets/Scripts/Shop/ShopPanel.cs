using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Shop Panel
//  - Hovering and Exiting Events with Effects
//  - Need Colliders and Cursors Effects
[RequireComponent(typeof(Collider2D))]
public class ShopPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public ShopItemType itemType;
    public int price;

    // The Cursor Effect that will take place when you are hovering and selecting the Panel
    public GameObject selectingCursor;
    // Blocking Masks that will be actived when Panels are Unselectable
    public GameObject blockingOverlay;

    public GameObject selectingOverlay;

    [SerializeField]
    bool selectable = true;
    bool hovering;
    bool selecting;

    void Start() {
        hovering = false;
        selecting = false;
    }

    void Update() {
        // Selecting Panel will always have Cursor Activated
        if (!selecting) {
            // Hovering Effects
            if (hovering && !selectingCursor.activeSelf) {
                ActivateCursor();
            } else if (!hovering && selectingCursor.activeSelf){
                DeactivateCursor();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        hovering = false;
    }

    public void Activate() {
        selectable = true;
        blockingOverlay.SetActive(false);
    }

    public void Deactivate() {
        selectable = false;
        blockingOverlay.SetActive(true);
        selectingCursor.SetActive(false);
    }

    public bool CheckSelectable() {
        return selectable;
    }

    public void ActivateCursor() {
        selectingCursor.SetActive(true);
    }

    public void DeactivateCursor() {
        selectingCursor.SetActive(false);
    }

    public void Select() {
        if (!selecting) {
            ActivateCursor();
            selectingOverlay.SetActive(true);
            selecting = true;
        }
    }

    public void Deselect() {
        if (selecting) {
            DeactivateCursor();
            selectingOverlay.SetActive(false);
            selecting = false;
        }
    }
}