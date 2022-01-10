using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Valve.VR;

public class ControllerHandler : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
            gameObject.AddComponent<SteamVR_Behaviour_Pose>();
    }
}
