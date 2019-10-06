using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Generate Prefabs Panel to Populate Grid Layout Panels
public class GridPopulating: MonoBehaviour {

    // The Prefab
    public GameObject itemPanel;

    // Number of Objects to Create
    public int panelAmount;

    //Custom Panel COlors
    public Color32 panelColor = new Color32(139, 138, 173, 100);

    void Start() {
        Populate();
    }

    void Populate() {
        GameObject panelObj;

        for (int i = 0; i < panelAmount; i++) {
            // Instantiate
            panelObj = Instantiate(
                itemPanel,
                transform
            ) as GameObject;

            // Set Color
            panelObj.GetComponent<Image>().color = panelColor;
        }
    }
}