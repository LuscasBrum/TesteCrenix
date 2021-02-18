using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler//add as determinandas interfaces.
{
    public Gear gear;//engrenagem

    public void OnDrop(PointerEventData eventData)//quando um objeto for colocado...
    {
        if(eventData.pointerDrag != null) 
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; //trocando a posição da engrenagem.
        }
    }
}
