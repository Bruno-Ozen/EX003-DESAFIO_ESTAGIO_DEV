using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador
{

    private GameObject elevador;

    private Usuario usuario;
    private Morador[] moradores;
    private int tempo_espera;
    public int andar_atual;
    public MEPainelElevador manipulador_eventos_elevador;

    public Elevador(Transform[] ocupantes, int tempo_espera)
    {
        GameObject[] filhosElevador = new GameObject[ocupantes.Length - 1];
        for (int i = 1; i < ocupantes.Length; i++)
        {
            filhosElevador[i - 1] = ocupantes[i].gameObject;
        }

        this.elevador = ocupantes[0].gameObject;
        this.usuario = new Usuario(ocupantes[1].GetComponent<Transform>());
        this.moradores = new Morador[4];

        for(int i = 2; i < ocupantes.Length; i++)
        {
            this.moradores[i - 2] = new Morador(ocupantes[i].GetComponent<Transform>());
        }

        this.tempo_espera = tempo_espera;
        this.andar_atual = 1;
    }

    public GameObject getElevador()
    {
        return elevador;
    }

}