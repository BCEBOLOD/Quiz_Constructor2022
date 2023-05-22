using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenshoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    ScreenCapture.CaptureScreenshot("screenshot.png");
        //    Debug.Log("A screenshot was taken!");
        //}
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ScreenCapture.CaptureScreenshot("screenshot.png");
            Debug.Log("A screenshot was taken!");
        }
    }
}
