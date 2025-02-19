using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GerenciadorPredio : MonoBehaviour
{
    // COMPONENTES DA UNITY
    [SerializeField] private GameObject elevador_obj;
    [SerializeField] private GameObject predio_obj;
    private Boolean usuario_dentro_elevador;
    private Elevador elevador;
    private Predio predio;
    public Boolean jogo_comecou;

    public Elevador GetElevador { get => elevador; set => elevador = value; }
    public Predio GetPredio { get => predio; set => predio = value; }

    void Awake()
    {
        // Montando o prédio
        // 1: Elevador

        GetElevador = new Elevador(
                elevador_obj,
                pega_filhos_diretos(elevador_obj.transform),
                5
            );

        // 2: Prédio
        GetPredio = new Predio(
                predio_obj,
                pega_filhos_diretos(predio_obj.transform),
                elevador,
                8
            );
        usuario_dentro_elevador = GetPredio.getAndar_usuario.getUsuario.getEsta_dentro_do_elevador;
    }

    private void Update()
    {
        GetElevador.opera_elevador();
    }

    public void usuarioSubir()
    {

        if (!jogo_comecou)
        {
            Debug.Log("caiu aqui sim");
            jogo_comecou = true;
            GetElevador.ativar_elevador();
        }

        AndarUsuario andarUsuario = GetPredio.getAndar_usuario;
        Elevador elevador = GetElevador;
        Usuario usuario = andarUsuario.getUsuario;

        usuario.pedir_para_subir(andarUsuario, elevador);
    }

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