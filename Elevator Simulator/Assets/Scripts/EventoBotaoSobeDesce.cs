using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoBotaoSobeDesce
{
    private Usuario usuario_disparou;
    private Morador morador_disparou;
    // Essa variável deverá ser um vetor de 2 posições, que poderá ser:
    // [true, false] -> apenas subir
    // [false, true] -> apenas descer
    // [true, true] -> subir e descer
    private Boolean[] subir_ou_descer;
    private int de_qual_andar_veio;
    private Boolean evento_concluido;

    public EventoBotaoSobeDesce(Usuario usuario_disparou, Morador morador_disparou, int de_qual_andar_veio, Boolean[] subir_ou_descer)
    {
        this.evento_concluido = false;
        this.usuario_disparou = usuario_disparou;
        this.morador_disparou = morador_disparou;
        this.Subir_ou_descer = subir_ou_descer;
        this.De_qual_andar_veio = de_qual_andar_veio;
    }

    public int De_qual_andar_veio { get => de_qual_andar_veio; set => de_qual_andar_veio = value; }
    public bool[] Subir_ou_descer { get => subir_ou_descer; set => subir_ou_descer = value; }
    public bool Evento_concluido { get => evento_concluido; set => evento_concluido = value; }

    public String usuario_ou_morador()
    {
        String quem_disparou = "ninguem";

        if (usuario_disparou != null ^ morador_disparou != null)
        {
            if (usuario_disparou != null)
            {
                quem_disparou = "usuario";
            }
            else if (morador_disparou != null)
            {
                quem_disparou = "morador";
            }
        }

        return quem_disparou;
    }

    public String sobe_desce_ou_ambos()
    {
        String resposta = "";

        if (Subir_ou_descer[0] == true && Subir_ou_descer[1] == false)
        {
            resposta = "sobe";
        }
        else if(Subir_ou_descer[0] == false && Subir_ou_descer[1] == true)
        {
            resposta = "desce";
        }
        else if (Subir_ou_descer[0] == true && Subir_ou_descer[1] == true)
        {
            resposta = "ambos";
        }
        else
        {
            resposta = "nenhum";
        }

        return resposta;
    }

}
