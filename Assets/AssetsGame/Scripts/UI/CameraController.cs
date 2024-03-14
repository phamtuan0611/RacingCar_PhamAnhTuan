using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject car;
    public Vector3 offer = new Vector3(0, 3, 5);

    public void LateUpdate()
    {
        transform.position = car.transform.position + offer;
    }
}
