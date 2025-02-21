using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndarUsuario : Andar
{
    private Usuario usuario;
    private MEBotaoSobeDesce manipulador_eventos_btn_sobe_desce;

    public AndarUsuario(GameObject andar, int numero_andar, List<Transform> ambiente_andar) : base(andar, numero_andar, ambiente_andar)
    {
        this.Manipulador_eventos_btn_sobe_desce = new MEBotaoSobeDesce();
        this.usuario = new Usuario(this.getOcupantes);
    }

    public Usuario getUsuario { get => usuario; }
    public MEBotaoSobeDesce Manipulador_eventos_btn_sobe_desce { get => manipulador_eventos_btn_sobe_desce; set => manipulador_eventos_btn_sobe_desce = value; }

    public void usuario_entrar(Elevador elevador)
    {
        this.usuario.getEsta_dentro_do_elevador = true;
        this.usuario.getGameObjectUsuario.SetActive(false);
        elevador.getUsuario.getGameObjectUsuario.SetActive(true);
    }

    public void usuario_sair(Elevador elevador)
    {
        this.usuario.getEsta_dentro_do_elevador = false;
        this.usuario.getGameObjectUsuario.SetActive(true);
        elevador.getUsuario.getGameObjectUsuario.SetActive(false);
    }

}
