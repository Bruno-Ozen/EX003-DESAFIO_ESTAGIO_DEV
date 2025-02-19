using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoBotaoSobeDesce
{
    private Usuario usuario_disparou;
    private Morador morador_disparou;
    private Boolean subir;

    public EventoBotaoSobeDesce(Usuario usuario_disparou, Morador morador_disparou, Boolean subir)
    {
        this.usuario_disparou = usuario_disparou;
        this.morador_disparou = morador_disparou;
        this.subir = subir;
    }

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
