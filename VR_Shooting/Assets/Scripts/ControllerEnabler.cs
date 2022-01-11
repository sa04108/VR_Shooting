using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Valve.VR;

public class ControllerEnabler : MonoBehaviourPun
{
    SteamVR_Behaviour_Pose behaviourPose;
    ControllerHandler handler;

    // Start is called before the first frame update
    void Start()
    {
        behaviourPose = GetComponent<SteamVR_Behaviour_Pose>();
        handler = GetComponent<ControllerHandler>();

        if (photonView.IsMine) {
            behaviourPose.enabled = true;

            handler.enabled = true;
        }
    }
}
