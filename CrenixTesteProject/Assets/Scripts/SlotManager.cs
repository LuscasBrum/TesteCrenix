using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlotManager : MonoBehaviour
{
    Slot[] slots; //array com os slots das engrenagens.
    public static event Action Reset;//evento de reset, para quando o botão for pressionado determinadas funções aconteçam. 

    private void Awake()
    {
        slots = GetComponentsInChildren<Slot>();//pegando os componenetes do array dentro desse objeto.
    }

    public void ResetPosition()
    {
        Reset();//chamando o evento.
        for (int i = 0; i < slots.Length; i++)//resetando as posições das engrenagens.
        {
            GearHolderManager.complete = false;//trocando a variável statica para false.
            slots[i].gear.transform.SetParent(slots[i].gear.GetComponentInParent<GearHolderManager>().transform); //trocando o parent das engrenagens.
            slots[i].gear.GetComponent<RectTransform>().anchoredPosition = slots[i].GetComponent<RectTransform>().anchoredPosition;//trocando a posição das engrenagens.
        }
    }
}
