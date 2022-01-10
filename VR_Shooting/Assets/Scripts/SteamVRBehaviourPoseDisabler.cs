using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Valve.VR;

public class SteamVRBehaviourPoseDisabler : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
            GetComponent<SteamVR_Behaviour_Pose>().enabled = false;
    }
}
