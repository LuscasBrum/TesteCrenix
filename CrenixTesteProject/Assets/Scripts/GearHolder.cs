using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GearHolder : MonoBehaviour, IDropHandler//add as determinandas interfaces.
{
    public RectTransform rectTransform;
    public float rSpeed;//velocidade de rotação.
    public Gear myGear;
    public GearHolderManager manager;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)//quando um objeto for colocado...
    {
        if (eventData.pointerDrag != null)
        {
            if(myGear == null) 
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                myGear = eventData.pointerDrag.GetComponent<Gear>();
                myGear.GetComponent<RectTransform>().SetParent(transform);
                manager.VerificationHolders();//verifica se todos os suportes estão com engrenagens.
            }
        }
    }
}
