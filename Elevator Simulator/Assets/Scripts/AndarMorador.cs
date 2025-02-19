using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndarMorador : Andar
{

    private FilaAndar fila;
    private int numero_andar;
    private MEBotaoSobeDesce manipulador_eventos_btn_sobe_desce;

    public AndarMorador(int numero_andar, Transform[] ambiente_andar) : base(numero_andar, ambiente_andar)
    {
        this.numero_andar = numero_andar;
        fila = new FilaAndar(numero_andar, ambiente_andar[3].GetComponentsInChildren<Transform>());
    }

}
