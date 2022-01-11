using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MultipleCameraEnabler : MonoBehaviour
{
    [SerializeField]
    Camera FrontCamera;
    [SerializeField] [Tooltip("Width, Height, Framerate")]
    Vector3 FrontCameraResolution;
    [SerializeField]
    Camera RightCamera;
    [SerializeField] [Tooltip("Width, Height, Framerate")]
    Vector3 RightCameraResolution;
    [SerializeField]
    Camera BackCamera;
    [SerializeField] [Tooltip("Width, Height, Framerate")]
    Vector3 BackCameraResolution;
    [SerializeField]
    Camera LeftCamera;
    [SerializeField] [Tooltip("Width, Height, Framerate")]
    Vector3 LeftCameraResolution;
    [SerializeField]
    Camera BottomCamera;
    [SerializeField] [Tooltip("Width, Height, Framerate")]
    Vector3 BottomCameraResolution;
    public struct CameraData
    {
        public Camera camera;
        public Vector3 resolution;
        public CameraData(Camera _camera, Vector3 _resolution) {
            camera = _camera;
            resolution = _resolution;
        }
    }
    
    void Awake()
    {
        List<CameraData> cameraDataList = new List<CameraData>();
        cameraDataList.Add(new CameraData(FrontCamera, FrontCameraResolution));
        cameraDataList.Add(new CameraData(RightCamera, RightCameraResolution));
        cameraDataList.Add(new CameraData(LeftCamera, LeftCameraResolution));
        cameraDataList.Add(new CameraData(BackCamera, BackCameraResolution));
        cameraDataList.Add(new CameraData(BottomCamera, BottomCameraResolution));

        Debug.Log("displays connected: " + Display.displays.Length);
        // 4보다 작으면 해당 디스플레이 수만큼 그보다 많으면 더 많이.
        for (int i = 1; i < ((Display.displays.Length <= 5) ? Display.displays.Length : 5); i++)
        {
            Display.displays[i].Activate((int)cameraDataList[i].resolution.x, (int)cameraDataList[i].resolution.y, (int)cameraDataList[i].resolution.z);
        }
        
    }
}
