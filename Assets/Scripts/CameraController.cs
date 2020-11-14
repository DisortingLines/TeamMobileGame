using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public GameObject playerObj;

    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector3 desiredPos = playerObj.transform.position + offset;
        transform.position = desiredPos;
    }
}
