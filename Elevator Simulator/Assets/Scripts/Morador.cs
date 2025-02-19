using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morador
{
    private GameObject morador;
    private int andar_atual;
    private int andar_desejado;
    private Boolean[] subir_ou_descer;
    private Boolean e_oProximo;

    // Se essa vari�vel for true, ent�o ele est� dentro. Sen�o, o Usu�rio est� fora, no 1o andar
    private Boolean esta_dentro_do_elevador;

    public int getAndar_atual { get => andar_atual; set => andar_atual = value; }
    public int getAndar_desejado { get => andar_desejado; set => andar_desejado = value; }
    public bool getEsta_dentro_do_elevador { get => esta_dentro_do_elevador; set => esta_dentro_do_elevador = value; }
    public GameObject getGameObjectMorador { get => morador; set => morador = value; }
    public bool getE_oProximo { get => e_oProximo; set => e_oProximo = value; }

    public Morador(Transform morador)
    {
        this.getE_oProximo = false;
        this.getGameObjectMorador = morador.gameObject;
        this.getGameObjectMorador.SetActive(false);
        this.getEsta_dentro_do_elevador = false;
        this.subir_ou_descer = new Boolean[2];
        this.subir_ou_descer[0] = false;
        this.subir_ou_descer[1] = false;
    }

    public void escolher_andar(int numero_andar)
    {
        this.getAndar_desejado = numero_andar;
    }

    public void enviarEventoAoPainelElevador()
    {
        List<int> andares_desejados = new List<int>();
        andares_desejados.Add(this.getAndar_desejado);
        EventoPainelElevador eventoPainelElevador = new EventoPainelElevador(null, this, andares_desejados);
    }

    public void pedir_para_subir()
    {
        this.subir_ou_descer[0] = true;
    }

    public void pedir_para_descer()
    {
        this.subir_ou_descer[1] = true;
    }

    public void enviarEventoAoBotaoSobeDesce(AndarMorador andar, Elevador elevador)
    {
        EventoBotaoSobeDesce eventoBotaoSobeDesce = new EventoBotaoSobeDesce(null, this, null, andar, subir_ou_descer);
        andar.Manipulador_eventos_btn_sobe_desce.dispararEvento(eventoBotaoSobeDesce, elevador);
        this.subir_ou_descer[0] = false;
        this.subir_ou_descer[1] = false;
    }

    public void sortearSubirOuDescer(AndarMorador andar, Elevador elevador)
    {
        int sorteio = UnityEngine.Random.Range(0, 1);

        switch (sorteio)
        {
            case 0:
                pedir_para_descer();
                break;
            case 1:
                pedir_para_subir();
                break;
        }
    }

    public String sobe_desce_ou_ambos()
    {
        String resposta = "";

        if (subir_ou_descer[0] == true && subir_ou_descer[1] == false)
        {
            resposta = "sobe";
        }
        else if (subir_ou_descer[0] == false && subir_ou_descer[1] == true)
        {
            resposta = "desce";
        }
        else if (subir_ou_descer[0] == true && subir_ou_descer[1] == true)
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
