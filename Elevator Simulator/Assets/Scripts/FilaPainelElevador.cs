using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaPainelElevador : MonoBehaviour
{
    private List<EventoPainelElevador> filaEventosPainelElevador;
    int ponteiro_do_primeiro;

    public FilaPainelElevador()
    {
        this.getFilaPainelElevador = new List<EventoPainelElevador>();
    }

    public List<EventoPainelElevador> getFilaPainelElevador { get => filaEventosPainelElevador; set => filaEventosPainelElevador = value; }

    public void enfileira(EventoPainelElevador evento_painel_elevador)
    {
        if (this.esta_vazia())
        {
            this.getFilaPainelElevador.Add(evento_painel_elevador);
            this.ponteiro_do_primeiro = 0;
        }

    }

    public EventoPainelElevador desenfileira()
    {
        EventoPainelElevador desenfileirado = this.filaEventosPainelElevador[ponteiro_do_primeiro];

        if (ponteiro_do_primeiro == (getFilaPainelElevador.Count - 1))
        {
            ponteiro_do_primeiro = 0;
            getFilaPainelElevador.Clear();
        }
        else if (ponteiro_do_primeiro < getFilaPainelElevador.Count)
        {
            ponteiro_do_primeiro++;
        }

        return desenfileirado;
    }

    public Boolean esta_vazia()
    {
        return this.getFilaPainelElevador.Count == 0;
    }

}
