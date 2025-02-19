using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEPainelElevador : MonoBehaviour
{

    public void dispararEvento(EventoPainelElevador evento, Elevador elevador)
    {
        elevador.enfileiraEventoPainelElevador(evento);
    }

}
