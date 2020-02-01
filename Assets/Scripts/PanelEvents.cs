using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelEvents : MonoBehaviour {   
    public void MouseEnterHighlight() {
        bool interactive = true;
        if (gameObject.GetComponent<Button>() != null)
            interactive = gameObject.GetComponent<Button>().interactable;
        // !ticked && 
        if (interactive) {
            HighlightSelf();
        }
    }

    public void MouseExitHighlight() {
        DehighlightSelf();
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
}
