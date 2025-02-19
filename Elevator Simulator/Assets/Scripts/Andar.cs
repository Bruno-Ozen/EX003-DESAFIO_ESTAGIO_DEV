using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar
{
    private GameObject andar;
    private int numero_andar;
    private GameObject porta;
    private Boolean porta_esta_aberta;
    private GameObject animacao_troca_personagens;
    private Transform ocupantes;

    public Andar(GameObject andar, int numero_andar, List<Transform> filhosAndar)
    {
        this.getGameobjectAndar = andar;
        this.Porta = filhosAndar[0].gameObject;
        this.animacao_troca_personagens = filhosAndar[1].gameObject;
        this.animacao_troca_personagens.SetActive(false);
        this.getOcupantes = filhosAndar[2];
        fechaPorta();
    }

    public GameObject Porta { get => porta; set => porta = value; }
    public bool Porta_esta_aberta { get => porta_esta_aberta; set => porta_esta_aberta = value; }
    public GameObject getGameobjectAndar { get => andar; set => andar = value; }
    public int getNumero_andar { get => numero_andar; set => numero_andar = value; }
    public Transform getOcupantes { get => ocupantes; set => ocupantes = value; }

    public void abrePorta()
    {
        Porta.SetActive(false);
        this.Porta_esta_aberta = true;
    }

    public void fechaPorta()
    {
        Porta.SetActive(true);
        this.Porta_esta_aberta = false;
    }

}
