using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar
{

    public int numero_andar;
    private GameObject porta;
    private GameObject animacao_troca_personagens;

    public Andar(int numero_andar, Transform[] ambiente_andar)
    {
        GameObject[] filhosAndar = new GameObject[ambiente_andar.Length - 1];
        for (int i = 1; i < ambiente_andar.Length; i++)
        {
            filhosAndar[i - 1] = ambiente_andar[i].gameObject;
        }

        this.porta = filhosAndar[0];
        this.animacao_troca_personagens = filhosAndar[1];
        this.numero_andar = numero_andar;
    }

    public void abrePorta()
    {
        porta.SetActive(true);
    }

    public void fechaPorta()
    {
        porta.SetActive(false);
    }

}
