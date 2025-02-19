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

    Predio predio;

    void Awake()
    {
        // Montando o prédio
        // 1: Elevador
        Elevador elevador = new Elevador(
                elevador_obj.GetComponentsInChildren<Transform>(),
                5
            );

        // 2: Prédio
        predio = new Predio(predio_obj.GetComponentsInChildren<Transform>(),
                elevador,
                8
            );
        
    }

    public void usuarioSubir()
    {
        AndarUsuario andarUsuario = predio.Andar_usuario;
        Usuario usuario = predio.Andar_usuario.UsuarioGet;

        usuario.pedir_para_subir(andarUsuario);
    }
    
}