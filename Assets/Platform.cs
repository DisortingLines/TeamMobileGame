using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
        }
    }
}
