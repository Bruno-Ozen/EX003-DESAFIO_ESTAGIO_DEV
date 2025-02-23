using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaSobeOuDesce
{
    private List<EventoBotaoSobeDesce> filaEventosSobeOuDesce;
    int max_na_fila;
    int ponteiro_do_primeiro;
    public FilaSobeOuDesce()
    {
        this.max_na_fila = 4;
        this.getFilaEventosSobeOuDesce = new List<EventoBotaoSobeDesce> ();
    }

    public List<EventoBotaoSobeDesce> getFilaEventosSobeOuDesce { get => filaEventosSobeOuDesce; set => filaEventosSobeOuDesce = value; }

    public void enfileira(EventoBotaoSobeDesce evento_sobe_ou_desce)
    {
        if (this.esta_vazia())
        {
            this.getFilaEventosSobeOuDesce.Add(evento_sobe_ou_desce);
            this.ponteiro_do_primeiro = 0;
        }
        else
        {
            if (this.filaEventosSobeOuDesce.Count < max_na_fila)
            {
                this.getFilaEventosSobeOuDesce.Add(evento_sobe_ou_desce);
            }
        }

    }

    public EventoBotaoSobeDesce desenfileira()
    {
        EventoBotaoSobeDesce desenfileirado = this.filaEventosSobeOuDesce[ponteiro_do_primeiro];
        
        if(ponteiro_do_primeiro == (getFilaEventosSobeOuDesce.Count - 1) && ponteiro_do_primeiro != 0)
        {
            ponteiro_do_primeiro = 0;
            getFilaEventosSobeOuDesce.Clear();
        } else if (ponteiro_do_primeiro < (getFilaEventosSobeOuDesce.Count - 1))
        {
            ponteiro_do_primeiro++;
        }

        return desenfileirado;
    }

    public Boolean esta_vazia()
    {
        return this.getFilaEventosSobeOuDesce.Count == 0;
    }

    public Boolean nao_esta_vazia()
    {
        return !this.esta_vazia();
    }

}
