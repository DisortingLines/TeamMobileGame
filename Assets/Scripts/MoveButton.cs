using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerDownHandler
{
    public PlayerController player;

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(player.Move());
    }
}
