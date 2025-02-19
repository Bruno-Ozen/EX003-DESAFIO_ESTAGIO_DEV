using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usuario
{

    private GameObject usuario { get; set; }

    private List<int> andares_desejados {  get; set; }

    // Se essa variável for true, então ele está dentro. Senão, o Usuário está fora, no 1o andar
    private Boolean esta_dentro_do_elevador;
    private Boolean subir;

    public Usuario(Transform usuario)
    {
        this.andares_desejados = new List<int>();
        this.usuario = usuario.gameObject.GetComponent<GameObject>();
        this.esta_dentro_do_elevador = false;
    }

    public void escolher_andar(int numero_andar)
    {
        if (esta_dentro_do_elevador)
        {
            this.andares_desejados.Add(numero_andar);
        }
    }

    public void enviarEventoAoPainelElevador()
    {
        EventoPainelElevador eventoPainelElevador = new EventoPainelElevador(this, null, this.andares_desejados);

    }

    public void pedir_para_subir(AndarUsuario andar)
    {
        this.subir = true;
        enviarEventoAoBotaoSobeDesce(andar);
    }

    public void enviarEventoAoBotaoSobeDesce(AndarUsuario andar)
    {
        EventoBotaoSobeDesce eventoBotaoSobeDesce = new EventoBotaoSobeDesce(this, null, subir);
        andar.dispararEventoSobeDesce(eventoBotaoSobeDesce);
    }

}
