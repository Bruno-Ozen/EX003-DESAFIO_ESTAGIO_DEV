using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEBotaoSobeDesce
{

    public void dispararEvento(EventoBotaoSobeDesce evento, Elevador elevador)
    {
        Debug.Log("CAIU AQUI 4");
        elevador.enfileiraEventoSobeOuDesce(evento);
    }

}
