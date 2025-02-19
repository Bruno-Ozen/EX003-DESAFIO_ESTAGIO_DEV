using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaAndar
{
    private Morador[] fila;
    private int qtd_moradores;
    private int qtd_max_moradores_na_fila;

    public FilaAndar(int numero_andar, List<Transform> moradores) {
        this.qtd_moradores = 0;
        this.qtd_max_moradores_na_fila = 4;
        this.fila = new Morador[moradores.Count];
        for (int i = 0; i < moradores.Count; i++)
        {
            fila[i] = new Morador(moradores[i].transform);
        }

    }

    public void adicionarMoradorNaFila(AndarMorador andar, Elevador elevador)
    {
        if (qtd_moradores < qtd_max_moradores_na_fila)
        {
            if (qtd_moradores == 0)
            {
                this.fila[qtd_moradores].getGameObjectMorador.SetActive(true);
                this.fila[qtd_moradores].sortearSubirOuDescer(andar, elevador);
                this.fila[qtd_moradores].enviarEventoAoBotaoSobeDesce(andar, elevador);
                this.qtd_moradores++;
            } else if(qtd_moradores == 1)
            {
                this.fila[qtd_moradores].getGameObjectMorador.SetActive(true);
                this.fila[qtd_moradores].sortearSubirOuDescer(andar, elevador);
                if ((fila[qtd_moradores - 1].sobe_desce_ou_ambos() == "sobe" && fila[qtd_moradores - 1].sobe_desce_ou_ambos() == "desce")
                    || (fila[qtd_moradores - 1].sobe_desce_ou_ambos() == "desce" && fila[qtd_moradores - 1].sobe_desce_ou_ambos() == "sobe")
                    )
                {
                    this.fila[0].pedir_para_subir();
                    this.fila[0].pedir_para_descer();
                }

                this.fila[0].enviarEventoAoBotaoSobeDesce(andar, elevador);
                this.qtd_moradores++;
            }
            else if(qtd_moradores > 1)
            {
                this.fila[qtd_moradores].getGameObjectMorador.SetActive(true);
                this.fila[qtd_moradores].sortearSubirOuDescer(andar, elevador);
                this.qtd_moradores++;
            }

        }

    }

    public void removerMoradorDaFila()
    {

    }

}
