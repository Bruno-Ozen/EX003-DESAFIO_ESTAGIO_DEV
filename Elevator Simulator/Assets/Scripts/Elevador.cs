using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    private EventoBotaoSobeDesce ultimo_evento_SobeDesce_desenfileirado;
    private EventoPainelElevador ultimo_evento_PainelElevador_desenfileirado;

    private Animator animador_elevador;

    public int getAndar_atual { get => andar_atual; set => andar_atual = value; }
    public MEPainelElevador getManipulador_eventos_elevador { get => manipulador_eventos_elevador; set => manipulador_eventos_elevador = value; }
    public FilaSobeOuDesce getFilaSobeOuDesce { get => getFilaEventosSobeOuDesce; set => getFilaEventosSobeOuDesce = value; }
    public Usuario getUsuario { get => usuario; set => usuario = value; }
    public Morador[] getMoradores { get => moradores; set => moradores = value; }
    public FilaSobeOuDesce getFilaEventosSobeOuDesce { get => filaEventosSobeOuDesce; set => filaEventosSobeOuDesce = value; }
    public bool getAtivo { get => ativo; set => ativo = value; }
    public FilaPainelElevador getFilaPainelElevador { get => filaPainelElevador; set => filaPainelElevador = value; }
    public int getTempo_espera { get => tempo_espera; set => tempo_espera = value; }
    public EventoBotaoSobeDesce getUltimo_evento_SobeDesce_desenfileirado { get => ultimo_evento_SobeDesce_desenfileirado; set => ultimo_evento_SobeDesce_desenfileirado = value; }
    public EventoPainelElevador getUltimo_evento_PainelElevador_desenfileirado { get => ultimo_evento_PainelElevador_desenfileirado; set => ultimo_evento_PainelElevador_desenfileirado = value; }
    public Animator getAnimador_elevador { get => animador_elevador; set => animador_elevador = value; }
    public GameObject getGameobjectElevador { get => elevador; set => elevador = value; }
    public Vector3[] getPosicoes_andares { get => posicoes_andares; set => posicoes_andares = value; }

    private Vector3[] posicoes_andares;

    public Elevador(GameObject elevador_obj, List<Transform> filhosElevador, int tempo_espera)
    {
        this.getPosicoes_andares = new Vector3[4];
        this.getPosicoes_andares[0] = new Vector3(4.0197f, -7.1652f, 0f);
        this.getPosicoes_andares[1] = new Vector3(4.0197f, -1.95f, 0f);
        this.getPosicoes_andares[2] = new Vector3(4.0197f, 3.1f, 0f);
        this.getPosicoes_andares[3] = new Vector3(4.0197f, -7.1652f, 0f);

        this.getFilaPainelElevador = new FilaPainelElevador();
        this.getAnimador_elevador = elevador_obj.GetComponent<Animator>();
        this.animador_elevador.SetBool("parar", true);
        this.animador_elevador.SetBool("andar_1", false);
        this.animador_elevador.SetBool("andar_2", false);
        this.animador_elevador.SetBool("andar_3", false);
        this.animador_elevador.SetBool("andar_4", false);

        this.getAtivo = false;
        this.getFilaEventosSobeOuDesce = new FilaSobeOuDesce();
        this.getGameobjectElevador = elevador_obj;
        this.getUsuario = new Usuario(filhosElevador[0].GetComponent<Transform>());
        this.getMoradores = new Morador[4];

        for(int i = 1; i < filhosElevador.Count; i++)
        {
            this.getMoradores[i - 1] = new Morador(filhosElevador[i]);
        }

        this.getTempo_espera = tempo_espera;
        this.getAndar_atual = 1;
        this.getUsuario.getGameObjectUsuario.SetActive(false);
        foreach(Morador m in this.getMoradores)
        {
            m.getGameObjectMorador.SetActive(false);
        }
        this.manipulador_eventos_elevador = new MEPainelElevador();
    }

    public GameObject getElevador()
    {
        return getGameobjectElevador;
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