using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorPredio : MonoBehaviour
{
    // COMPONENTES DA UNITY
    [SerializeField] private GameObject elevador_obj;
    [SerializeField] private GameObject predio_obj;
    [SerializeField] private Image botao_subir_usuario;
    [SerializeField] private Image painel_elevador;
    [SerializeField] private AudioSource som_elevador_chegou;
    private Boolean usuario_dentro_elevador;
    private Elevador elevador;
    private Predio predio;
    public Boolean jogo_comecou;

    public Elevador GetElevador { get => elevador; set => elevador = value; }
    public Predio GetPredio { get => predio; set => predio = value; }

    void Awake()
    {
        // Montando o pr�dio
        // 1: Elevador
        botao_subir_usuario.gameObject.SetActive(true);
        painel_elevador.gameObject.SetActive(false);
        GetElevador = new Elevador(
                elevador_obj,
                pega_filhos_diretos(elevador_obj.transform),
                5
            );

        // 2: Pr�dio
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
        if (!GetPredio.getAndar_usuario.getUsuario.getEsta_dentro_do_elevador)
        {
            botao_subir_usuario.gameObject.SetActive(true);
            painel_elevador.gameObject.SetActive(false);
        }
        else
        {
            botao_subir_usuario.gameObject.SetActive(false);
            painel_elevador.gameObject.SetActive(true);
        }
        GetElevador.opera_elevador(som_elevador_chegou);
    }

    public void usuarioSubir()
    {

        if (!jogo_comecou)
        {
            jogo_comecou = true;
            GetElevador.ativar_elevador();
        }

        AndarUsuario andarUsuario = GetPredio.getAndar_usuario;
        Elevador elevador = GetElevador;
        Usuario usuario = andarUsuario.getUsuario;

        usuario.pedir_para_subir(andarUsuario, elevador);
    }

    public void usuarioIrParaO1oAndar()
    {
        GetPredio.getAndar_usuario.getUsuario.escolher_andar(1);
    }

    public void usuarioIrParaO2oAndar()
    {
        GetPredio.getAndar_usuario.getUsuario.escolher_andar(2);
    }

    public void usuarioIrParaO3oAndar()
    {
        GetPredio.getAndar_usuario.getUsuario.escolher_andar(3);
    }

    public void usuarioIrParaO4oAndar()
    {
        GetPredio.getAndar_usuario.getUsuario.escolher_andar(4);
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