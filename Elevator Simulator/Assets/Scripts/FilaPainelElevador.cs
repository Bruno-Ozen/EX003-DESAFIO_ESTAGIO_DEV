using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaPainelElevador
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
        else
        {
            if (evento_painel_elevador.getFoi_um_morador)
            {
                this.getFilaPainelElevador.Add(evento_painel_elevador);
            }
            else
            {
                int i = 0;

                while(i < (this.filaEventosPainelElevador.Count - 1))
                {
                    if (!this.filaEventosPainelElevador[i].getFoi_um_morador)
                    {
                        i++;
                    }
                }

                this.getFilaPainelElevador.Insert(ponteiro_do_primeiro + i, evento_painel_elevador);
            }

        }

    }

    public EventoPainelElevador desenfileira()
    {
        EventoPainelElevador desenfileirado = this.filaEventosPainelElevador[ponteiro_do_primeiro];

        if (ponteiro_do_primeiro == (getFilaPainelElevador.Count - 1) && ponteiro_do_primeiro != 0)
        {
            ponteiro_do_primeiro = 0;
            getFilaPainelElevador.Clear();
        }
        else if (ponteiro_do_primeiro < (getFilaPainelElevador.Count - 1))
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
