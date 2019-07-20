using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

using UnityEngine;


public struct Food {
    public string name;
    public string type;

    public Food(string lName = "", string lType = "") {
        name = lName;
        type = lType;
    }
}

public enum Category {
    Healthy,
    Junk
}

public class XMLReader : MonoBehaviour
{
    XmlDocument xDoc;

    // Collections:
    List<Food> healthyFoodColle = new List<Food>();
    List<Food> junkFoodColle = new List<Food>();


    // Start is called before the first frame update
    void Start()
    {
        xDoc = new XmlDocument();
        xDoc.Load("Assets/Scripts/TestXML.xml");

        ParsingHealthyCollection();
        ParsingJunkCollection();

        PrintLists();
    }

    void ParsingHealthyCollection() {
        string categoryPath = "/Food/Healthy";

        XmlNode categoryNode = xDoc.DocumentElement.SelectSingleNode(categoryPath);

        foreach (XmlNode foodItemNode in categoryNode.ChildNodes) {
            string name = foodItemNode.InnerText;
            string type = foodItemNode.Attributes["type"]?.InnerText;

            Food tempElement = new Food(name, type);

            healthyFoodColle.Add(tempElement);
        }
    }

    void ParsingJunkCollection() {
        string categoryPath = "/Food/Junk";

        XmlNode categoryNode = xDoc.DocumentElement.SelectSingleNode(categoryPath);

        foreach (XmlNode foodItemNode in categoryNode.ChildNodes) {
            string name = foodItemNode.InnerText;
            string type = foodItemNode.Attributes["type"]?.InnerText;

            Food tempElement = new Food(name, type);

            junkFoodColle.Add(tempElement);
        }
    }

    void PrintLists() {
        foreach (Food foodItem in healthyFoodColle) {
            Debug.Log("Name: " + foodItem.name + " - Type: " + foodItem.type + ".");
        }

        foreach (Food foodItem in junkFoodColle) {
            Debug.Log("Name: " + foodItem.name + " - Type: " + foodItem.type + ".");
        }
    }
   
}
