using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndarUsuario : Andar
{
    private Usuario usuario;
    private MEBotaoSobeDesce manipulador_eventos_btn_sobe_desce;

    public AndarUsuario(int numero_andar, Transform[] ambiente_andar) : base(numero_andar, ambiente_andar)
    {
        manipulador_eventos_btn_sobe_desce = new MEBotaoSobeDesce();
        this.usuario = new Usuario(ambiente_andar[3].gameObject.GetComponent<Transform>());
    }

    public void dispararEventoSobeDesce(EventoBotaoSobeDesce evento)
    {
        this.manipulador_eventos_btn_sobe_desce.dispararEvento(evento);
    }

    public Usuario UsuarioGet { get => usuario; }

}
