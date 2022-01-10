using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControllerHandler : MonoBehaviour
{
    [SerializeField] SteamVR_Action_Boolean inputAction;
    SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    private void OnEnable() {
        inputAction.AddOnStateDownListener(OnPress, inputSource);
    }

    private void OnDisable() {
        inputAction.RemoveOnStateDownListener(OnPress, inputSource);
    }

    private void OnPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        Debug.Log(fromSource + " " + fromAction.state);
    }

    private void Update() {
        Debug.DrawRay(transform.position, transform.forward, Color.green);
    }
}
