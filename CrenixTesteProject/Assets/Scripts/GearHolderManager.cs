using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GearHolderManager : MonoBehaviour
{
    Gear[] gears;//array de engrenagens.
    public static bool complete;//variável statica que revela se a task foi completa ou não.
    public Text dialogueBox;//caixa de diálogo do Nugget.
    public Gear[] Gears //construtor.
    {
        get { return gears; }
    }
    [SerializeField]
    GearHolder[] holders;//array de suportes.
    public GearHolder[] Holders
    {
        get { return holders; }
    }//construtor.

    private void Awake()
    {
        //pegandos os componentes no objeto e em seus filhos.
        gears = GetComponentsInChildren<Gear>();
        holders = GetComponentsInChildren<GearHolder>();
        for (int i = 0; i < holders.Length; i++)
        {
            holders[i].manager = this;
        }
    }
   
    public void VerificationHolders() //função que verifica se os suportes tem engrenagens.
    {
        for (int i = 0; i < Holders.Length;)
        {
            if(holders[i].myGear != null) 
            {
                i++;
                if (i >= holders.Length) 
                {
                    complete = true;
                    dialogueBox.text = "YAY, PARABÉNS, TASK CONCLUIDA!";
                    StartCoroutine(RotateGears());//começando a coroutine que aciona as engrenagens.
                }
            }
            else 
            {
                return;
            }
        }
    }

    public void ClearHolders() //deixando os suportes sem engrenagens.
    {
        for (int i = 0; i < holders.Length; i++)
        {
            holders[i].myGear = null;
        }
    }

    //add as funções no event.
    private void OnEnable()
    {
        SlotManager.Reset += ClearHolders;
    }

    private void OnDisable()
    {
        SlotManager.Reset -= ClearHolders;
    }
    public IEnumerator RotateGears() //função que faz as engrenages rodarem.
    {
        while(complete) //enquanto a missão estiver concluida.
        {
            for (int i = 0; i < holders.Length; i++)
            {
                holders[i].transform.Rotate(0, 0, 5 * holders[i].rSpeed, Space.Self);//gira o holder em torno de si mesmo no eixo z.
            }
            yield return new WaitForFixedUpdate();//espera o proximo frame.
        }
        yield return null;
    }
}
