using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador
{

    private GameObject elevador;

    private Boolean ativo;
    private Usuario usuario;
    private Morador[] moradores;
    private int tempo_espera;
    private int andar_atual;
    private MEPainelElevador manipulador_eventos_elevador;
    private FilaSobeOuDesce filaEventosSobeOuDesce;
    private FilaPainelElevador filaPainelElevador;

    public int getAndar_atual { get => andar_atual; set => andar_atual = value; }
    public MEPainelElevador getManipulador_eventos_elevador { get => manipulador_eventos_elevador; set => manipulador_eventos_elevador = value; }
    public FilaSobeOuDesce getFilaSobeOuDesce { get => getFilaEventosSobeOuDesce; set => getFilaEventosSobeOuDesce = value; }
    public Usuario getUsuario { get => usuario; set => usuario = value; }
    public Morador[] getMoradores { get => moradores; set => moradores = value; }
    public FilaSobeOuDesce getFilaEventosSobeOuDesce { get => filaEventosSobeOuDesce; set => filaEventosSobeOuDesce = value; }
    public bool getAtivo { get => ativo; set => ativo = value; }
    public FilaPainelElevador getFilaPainelElevador { get => filaPainelElevador; set => filaPainelElevador = value; }

    public void opera_elevador(AudioSource som_elevador)
    {
        if (ativo)
        {
            if (!getFilaEventosSobeOuDesce.esta_vazia())
            {
                EventoBotaoSobeDesce eventoSobeDesce = getFilaEventosSobeOuDesce.desenfileira();
                if (eventoSobeDesce.getFoi_um_morador)
                {
                    if (getAndar_atual == eventoSobeDesce.getAndarMorador.getNumero_andar)
                    {
                        eventoSobeDesce.getAndarMorador.abrePorta();
                        //eventoSobeDesce.getAndarMorador.getfiladesenfileira();
                    }
                }
                else
                {
                    if (getAndar_atual == eventoSobeDesce.getAndarUsuario.getNumero_andar)
                    {
                        som_elevador.Play();
                        eventoSobeDesce.getAndarUsuario.abrePorta();
                        eventoSobeDesce.getAndarUsuario.usuario_entrar(this);
                    }
                }

            }
        }

    }

    public Elevador(GameObject elevador_obj, List<Transform> filhosElevador, int tempo_espera)
    {
        this.getAtivo = false;
        this.getFilaEventosSobeOuDesce = new FilaSobeOuDesce();
        this.elevador = elevador_obj;
        this.getUsuario = new Usuario(filhosElevador[0].GetComponent<Transform>());
        this.getMoradores = new Morador[4];

        for(int i = 1; i < filhosElevador.Count; i++)
        {
            this.getMoradores[i - 1] = new Morador(filhosElevador[i]);
        }

        this.tempo_espera = tempo_espera;
        this.getAndar_atual = 1;
        this.getUsuario.getGameObjectUsuario.SetActive(false);
        foreach(Morador m in this.getMoradores)
        {
            m.getGameObjectMorador.SetActive(false);
        }

    }

    public GameObject getElevador()
    {
        return elevador;
    }

    public void enfileiraEventoSobeOuDesce(EventoBotaoSobeDesce evento_sobe_ou_desce)
    {
        this.getFilaEventosSobeOuDesce.enfileira(evento_sobe_ou_desce);
    }

    public void enfileiraEventoPainelElevador(EventoPainelElevador evento_painel_elevador)
    {
        this.getFilaPainelElevador.enfileira(evento_painel_elevador);
    }

    public void ativar_elevador()
    {
        this.ativo = true;
    }

}