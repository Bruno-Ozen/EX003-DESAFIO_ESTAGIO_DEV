using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public Predio(GameObject predio_obj, List<Transform> filhosPredio, Elevador elevador, int qtd_max_moradores)
    {
        // Montando cada andar
        this.predio = predio_obj;
        AndarUsuario andar_usuario_inst = new AndarUsuario(filhosPredio[0].gameObject, 1, pega_filhos_diretos(filhosPredio[0]));
        AndarMorador[] andares_moradores = new AndarMorador[filhosPredio.Count - 1];

        for (int i = 1; i < filhosPredio.Count; i++)
        {
            andares_moradores[i - 1] = new AndarMorador(filhosPredio[i].gameObject, i + 1, pega_filhos_diretos(filhosPredio[i]));
        }

        this.andar_usuario = andar_usuario_inst;
        this.Andares_de_moradores = andares_moradores;
        this.Elevador = elevador;
        this.getQtd_max_moradores = qtd_max_moradores;
        this.getQtd_andares = this.Andares_de_moradores.Length + 1;
    }

    public int getQtd_andares { get => qtd_andares; set => qtd_andares = value; }
    public GameObject getPredioObj { get => predio; set => predio = value; }
    public Elevador Elevador { get => elevador; set => elevador = value; }
    public int getQtd_max_moradores { get => qtd_max_moradores; set => qtd_max_moradores = value; }
    public AndarUsuario getAndar_usuario { get => andar_usuario; set => andar_usuario = value; }
    public AndarMorador[] Andares_de_moradores { get => andares_de_moradores; set => andares_de_moradores = value; }
    public Usuario Usuario { get => usuario; set => usuario = value; }

    public List<Transform> pega_filhos_diretos(Transform transform)
    {
        List<Transform> filhos_transform = new List<Transform>();
        foreach (Transform filho in transform)
        {
            filhos_transform.Add(filho);
        }

        return filhos_transform;

    }

}
