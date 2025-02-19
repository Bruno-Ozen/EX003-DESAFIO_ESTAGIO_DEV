using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndarMorador : Andar
{
    private FilaAndar fila;
    private MEBotaoSobeDesce manipulador_eventos_btn_sobe_desce;

    public AndarMorador(GameObject andar, int numero_andar, List<Transform> ambiente_andar) : base(andar, numero_andar, ambiente_andar)
    {
        this.manipulador_eventos_btn_sobe_desce = new MEBotaoSobeDesce();
        fila = new FilaAndar(numero_andar, pega_filhos_diretos(this.getOcupantes));
    }

    public MEBotaoSobeDesce Manipulador_eventos_btn_sobe_desce { get => manipulador_eventos_btn_sobe_desce; set => manipulador_eventos_btn_sobe_desce = value; }

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
