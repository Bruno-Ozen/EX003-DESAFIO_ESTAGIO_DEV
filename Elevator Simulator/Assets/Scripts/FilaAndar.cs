using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaAndar
{
    private Morador[] fila;

    public FilaAndar(int numero_andar, Transform[] fila_moradores) { 
        this.fila = new Morador[fila_moradores.Length];
        for (int i = 0; i < fila_moradores.Length; i++)
        {
            fila[i] = new Morador(fila_moradores[i].GetComponent<Transform>());
        }

    }

}
