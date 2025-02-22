using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usuario
{
    private GameObject usuario;

    private List<int> andares_desejados;
    public bool getEsta_dentro_do_elevador { get => esta_dentro_do_elevador; set => esta_dentro_do_elevador = value; }
    public List<int> getAndares_desejados { get => andares_desejados; set => andares_desejados = value; }
    public GameObject getGameObjectUsuario { get => usuario; set => usuario = value; }

    // Se essa vari�vel for true, ent�o ele est� dentro. Sen�o, o Usu�rio est� fora, no 1o andar
    private Boolean esta_dentro_do_elevador;
    private Boolean[] subir_ou_descer;
    public Usuario(Transform usuario)
    {
        this.getAndares_desejados = new List<int>();
        this.getGameObjectUsuario = usuario.gameObject;
        this.getEsta_dentro_do_elevador = false;
        this.subir_ou_descer = new Boolean[2];
        this.subir_ou_descer[0] = false;
        this.subir_ou_descer[1] = false;
    }

    public void pedir_para_subir(AndarUsuario andar, Elevador elevador)
    {
        this.subir_ou_descer[0] = true;
        enviarEventoAoBotaoSobeDesce(andar, elevador);
    }

    public void escolher_andar(int numero_andar)
    {
        if (getEsta_dentro_do_elevador)
        {
            if (numero_andar != 1)
            {
                this.getAndares_desejados.Add(numero_andar);
            }
        }
    }

    public Boolean enviarEventoAoPainelElevador(AndarUsuario andar, Elevador elevador)
    {
        Boolean conseguiu = false;
        if (this.andares_desejados.Count > 0)
        {
            EventoPainelElevador eventoPainelElevador = new EventoPainelElevador(this, null, andar, null, this.getAndares_desejados);
            elevador.getManipulador_eventos_elevador.dispararEvento(eventoPainelElevador, elevador);
            conseguiu = true;
        }

        return conseguiu;
    }

    public Boolean enviarEventoAoBotaoSobeDesce(AndarUsuario andar, Elevador elevador)
    {
        Boolean conseguiu = false;
        if (subir_ou_descer[0] ^ subir_ou_descer[1])
        {
            EventoBotaoSobeDesce eventoBotaoSobeDesce = new EventoBotaoSobeDesce(this, null, andar, null, subir_ou_descer);
            andar.Manipulador_eventos_btn_sobe_desce.dispararEvento(eventoBotaoSobeDesce, elevador);
            conseguiu = true;
        }
        subir_ou_descer[0] = false;

        return conseguiu;
    }

    public void limpaAndaresDesejados()
    {
        this.getAndares_desejados.Clear();
    }

}
