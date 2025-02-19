using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morador
{
    private GameObject morador;
    private int andar_atual;
    private int andar_desejado;
    private Boolean subir;

    // Se essa variável for true, então ele está dentro. Senão, o Usuário está fora, no 1o andar
    private Boolean esta_dentro_do_elevador;

    public int Andar_atual { get => andar_atual; set => andar_atual = value; }
    public int Andar_desejado { get => andar_desejado; set => andar_desejado = value; }
    public bool Esta_dentro_do_elevador { get => esta_dentro_do_elevador; set => esta_dentro_do_elevador = value; }

    public Morador(Transform morador)
    {
        this.morador = morador.gameObject.GetComponent<GameObject>();
        this.Esta_dentro_do_elevador = false;
    }

    public void escolher_andar(int numero_andar)
    {
        this.Andar_desejado = numero_andar;
    }

    public void enviarEventoAoPainelElevador()
    {
        List<int> andares_desejados = new List<int>();
        andares_desejados.Add(this.Andar_desejado);
        EventoPainelElevador eventoPainelElevador = new EventoPainelElevador(null, this, andares_desejados);
    }

    public void pedir_para_subir()
    {
        this.subir = true;
    }

    public void pedir_para_descer()
    {
        this.subir = false;
    }

    public void enviarEventoAoBotaoSobeDesce()
    {
        EventoBotaoSobeDesce eventoBotaoSobeDesce = new EventoBotaoSobeDesce();
    }

}
