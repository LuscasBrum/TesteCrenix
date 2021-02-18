using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gear : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler//add as determinandas interfaces.
{
    Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    private void Awake()
    {
        //pegando os determinados componenetes no objeto e em seus parents.
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)//evento para quando o objeto começar a ser arrastado.
    {
        canvasGroup.alpha = 0.5f;//deixando o objeto transparente.
        canvasGroup.blocksRaycasts = false;
        GearHolderManager.complete = false;//garantindo que a variável de fim de task esteja falsa.
        if(transform.parent.GetComponent<GearHolder>()) //se a gear estiver filha do holder, limpar o holder e trocar o parent e a mensagem.
        {
            transform.parent.GetComponent<GearHolder>().myGear = null;
            transform.parent.GetComponent<GearHolder>().manager.dialogueBox.text = "ENCAIXE AS ENGRENAGENS EM QUALQUER ORDEM!";
            transform.SetParent(GetComponentInParent<GearHolderManager>().transform);
        }
    }

    public void OnEndDrag(PointerEventData eventData)//quando acabar de arrastar o objeto...
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)//enquanto objeto estiver sendo arrastado...
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;//deixando objeto na mesma posição do mouse, e diminuindo a distancia em relação a escala do canvas.
    }
}
