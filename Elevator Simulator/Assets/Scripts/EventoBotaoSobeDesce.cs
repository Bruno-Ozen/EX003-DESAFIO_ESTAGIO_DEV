using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoBotaoSobeDesce
{
    private Usuario usuario_que_disparou;
    private Morador morador_que_disparou;
    private AndarUsuario andarUsuario;
    private AndarMorador andarMorador;
    // Essa variável deverá ser um vetor de 2 posições, que poderá ser:
    // [true, false] -> apenas subir
    // [false, true] -> apenas descer
    // [true, true] -> subir e descer
    private Boolean[] subir_ou_descer;
    private Boolean evento_concluido;
    private Boolean foi_um_morador;

    public EventoBotaoSobeDesce(Usuario usuario_disparou, Morador morador_disparou, AndarUsuario andar_usuario, AndarMorador andar_morador, Boolean[] subir_ou_descer)
    {
        this.evento_concluido = false;
        this.usuario_que_disparou = usuario_disparou;
        this.morador_que_disparou = morador_disparou;
        this.andarUsuario = andar_usuario;
        this.getAndarMorador = andar_morador;
        this.Subir_ou_descer = subir_ou_descer;

        if (this.usuario_que_disparou != null && this.morador_que_disparou == null)
        {
            getFoi_um_morador = false;
        }
        else if (this.usuario_que_disparou == null && this.morador_que_disparou != null)
        {
            getFoi_um_morador = true;
        }

    }

    public bool[] Subir_ou_descer { get => subir_ou_descer; set => subir_ou_descer = value; }
    public bool Evento_concluido { get => evento_concluido; set => evento_concluido = value; }
    public AndarUsuario getAndarUsuario { get => andarUsuario; set => andarUsuario = value; }
    public AndarMorador getAndarMorador { get => andarMorador; set => andarMorador = value; }
    public bool getFoi_um_morador { get => foi_um_morador; set => foi_um_morador = value; }

    public String usuario_ou_morador()
    {
        String quem_disparou = "ninguem";

        if (usuario_que_disparou != null ^ morador_que_disparou != null)
        {
            if (usuario_que_disparou != null)
            {
                quem_disparou = "usuario";
            }
            else if (morador_que_disparou != null)
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
