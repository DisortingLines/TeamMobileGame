using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    public float timeDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(other.gameObject.GetComponent<PlayerController>().SpeedBoost(timeDuration));

            Destroy(gameObject);
        }
    }
}
