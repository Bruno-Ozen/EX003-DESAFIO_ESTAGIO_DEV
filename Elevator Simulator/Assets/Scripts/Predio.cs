using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Predio
{

    private GameObject predio;
    private Elevador elevador;
    private int qtd_max_moradores;
    private int qtd_andares;
    private AndarUsuario andar_usuario;
    private AndarMorador[] andares_de_moradores;
    private Usuario usuario;

    public Predio(Transform[] andares, Elevador elevador, int qtd_max_moradores)
    {
        GameObject[] filhosPredio = new GameObject[andares.Length - 1];
        for (int i = 1; i < andares.Length; i++)
        {
            filhosPredio[i - 1] = andares[i].gameObject;
        }

        // Montando cada andar
        AndarUsuario andar_usuario_inst = new AndarUsuario(1, filhosPredio[0].GetComponentsInChildren<Transform>());
        AndarMorador[] andares_moradores_inst = new AndarMorador[filhosPredio.Length - 1];
        for(int i = 1; i < filhosPredio.Length; i++){
            andares_moradores_inst[i] = new AndarMorador(i + 1, filhosPredio[i].GetComponentsInChildren<Transform>());
        }

        this.Andares_de_moradores = andares_moradores_inst;
        this.Elevador = elevador;
        this.Predio = andares[0].gameObject;
        this.Qtd_max_moradores = qtd_max_moradores;
        this.Qtd_andares = this.Andares_de_moradores.Length + 1;
    }

    public int Qtd_andares { get => Qtd_andares1; set => Qtd_andares1 = value; }
    public GameObject PredioGet { get => predio; set => predio = value; }
    public Elevador Elevador { get => elevador; set => elevador = value; }
    public int Qtd_max_moradores { get => qtd_max_moradores; set => qtd_max_moradores = value; }
    public int Qtd_andares1 { get => qtd_andares; set => qtd_andares = value; }
    public AndarUsuario Andar_usuario { get => andar_usuario; set => andar_usuario = value; }
    public AndarMorador[] Andares_de_moradores { get => andares_de_moradores; set => andares_de_moradores = value; }
    public Usuario Usuario { get => usuario; set => usuario = value; }
}
