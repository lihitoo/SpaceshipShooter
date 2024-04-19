using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // Start is called before the first frame update
    public static float screenWidth;
    public static float screenHeight;
    private void Awake()
    {
        screenHeight = Camera.main.orthographicSize * 2f;
        //Debug.Log(screenHeight);
        screenWidth = screenHeight * ((float)Screen.width / (float)Screen.height);
    }

}
