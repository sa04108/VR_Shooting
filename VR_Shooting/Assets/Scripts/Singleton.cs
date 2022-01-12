using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Singleton<T> : MonoBehaviourPunCallbacks where T : MonoBehaviour
{
    private static T instance;
    public static T Instance { get => instance; }

    private void Awake() {
        if (instance == null) {
            instance = FindObjectOfType(typeof(T)) as T;
        }
        else {
            Destroy(gameObject);
        }
    }
}
