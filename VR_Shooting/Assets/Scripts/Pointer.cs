using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    [SerializeField] GameObject PointerImagePrefab;
    GameObject pointerImage;

    // Start is called before the first frame update
    void Start()
    {
        pointerImage = Instantiate(PointerImagePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitEnemy;
        int layerMaskEnemy = 1 << LayerMask.NameToLayer("Monster"); // 1000 0000 = 128
        if (Physics.Raycast(transform.position, transform.forward, out hitEnemy, float.PositiveInfinity, layerMaskEnemy))
        {
            Debug.Log(hitEnemy.collider.transform.name);
        }

        RaycastHit hitScreen;
        int layerMaskScreen = 1 << LayerMask.NameToLayer("Screen"); // 0100 0000 = 64
        if (Physics.Raycast(transform.position, transform.forward, out hitScreen, float.PositiveInfinity, layerMaskScreen))
        {
            pointerImage.transform.SetPositionAndRotation(hitScreen.point, hitScreen.collider.transform.rotation);
        }
    }
}
