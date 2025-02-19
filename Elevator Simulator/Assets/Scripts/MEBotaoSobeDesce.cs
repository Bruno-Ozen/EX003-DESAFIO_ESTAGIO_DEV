using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEBotaoSobeDesce
{

    public void dispararEvento(EventoBotaoSobeDesce evento, Elevador elevador)
    {
        elevador.enfileiraEventoSobeOuDesce(evento);
    }

}
