using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventoPainelElevador
{

    private Usuario usuario_disparou;
    private Morador morador_disparou;
    private List<int> andares_desejados;
    private Boolean evento_concluido;

    public EventoPainelElevador(Usuario usuario_disparou, Morador morador_disparou, List<int> andares_desejados)
    {
        this.usuario_disparou = usuario_disparou;
        this.morador_disparou = morador_disparou;
        this.andares_desejados = andares_desejados;
        this.Evento_concluido = false;
    }

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

}
