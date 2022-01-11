using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MultipleCameraEnabler : MonoBehaviour
{   
    public (int width, int height)[] resolution = new (int, int)[4];

    // Use this for initialization
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // 4보다 작으면 해당 디스플레이 수만큼 그보다 많으면 더 많이.
        for (int i = 1; i < ((Display.displays.Length <= 5) ? Display.displays.Length : 5); i++)
        {
            Display.displays[i].Activate(resolution[i].width, resolution[i].height, 30);
        }
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
