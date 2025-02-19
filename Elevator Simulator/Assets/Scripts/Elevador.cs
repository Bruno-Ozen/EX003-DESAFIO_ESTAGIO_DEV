using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Elevador
{

    private GameObject elevador;

    private Usuario usuario;
    private Morador[] moradores;
    private int tempo_espera;
    private int andar_atual;
    private MEPainelElevador manipulador_eventos_elevador;
    private List<EventoBotaoSobeDesce> filaEventosSobeOuDesce;

    public int getAndar_atual { get => andar_atual; set => andar_atual = value; }
    public MEPainelElevador getManipulador_eventos_elevador { get => manipulador_eventos_elevador; set => manipulador_eventos_elevador = value; }
    public List<EventoBotaoSobeDesce> getFilaSobeOuDesce { get => filaEventosSobeOuDesce; set => filaEventosSobeOuDesce = value; }
    public Usuario getUsuario { get => usuario; set => usuario = value; }
    public Morador[] getMoradores { get => moradores; set => moradores = value; }

    public Elevador(GameObject elevador_obj, List<Transform> filhosElevador, int tempo_espera)
    {
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

    }

}