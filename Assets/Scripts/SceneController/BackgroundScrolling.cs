using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stage moving for Spawning Routinely
public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed = -1;
    bool scrolling = true;

    //Referenes:

    // Start is called before the first frame update
    void Start()
    {
        StartScrolling();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (scrolling) {
            transform.Translate(new Vector2(0, scrollSpeed * Time.deltaTime));
        }
    }

    // Stop Scrolling on Bosses / Interests Spawned
    public void StopScrolling() {
        scrolling = false;
    }

    public void StartScrolling() {
        scrolling = true;
    }
}


