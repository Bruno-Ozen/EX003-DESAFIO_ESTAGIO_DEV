using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Button btn_SubirUsuario;
    private List<Button> botoes_painel_elevador;
    public Elevador GetElevador { get => elevador; set => elevador = value; }
    public Predio GetPredio { get => predio; set => predio = value; }
    public Button getBtn_SubirUsuario { get => btn_SubirUsuario; set => btn_SubirUsuario = value; }
    public List<Button> getBotoes_painel_elevador { get => botoes_painel_elevador; set => botoes_painel_elevador = value; }

    void Awake()
    {
        List<Transform> filhos_btn_subir = pega_filhos_diretos(botao_subir_usuario.transform);
        getBtn_SubirUsuario = filhos_btn_subir[0].GetComponent<Button>();

        getBotoes_painel_elevador = new List<Button>();
        List<Transform> filhos_painel_elevador = pega_filhos_diretos(painel_elevador.transform);
        for (int i = 0; i < filhos_painel_elevador.Count; i++)
        {
            getBotoes_painel_elevador.Add(filhos_painel_elevador[i].GetComponent<Button>());
        }
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

        if (GetElevador.getAtivo)
        {
           // StartCoroutine(passo_1());

        }

    }

    // MÉTODOS DE CADA PASSO DO ELEVADOR ---------------------------------------------------------------------------

    public IEnumerator passo_1()
    {
        // PASSO 1: ABRE O ELEVADOR PARA O USUÁRIO. AQUI, O ELEVADOR ESTÁ NO 1o ANDAR
        if (!GetElevador.getFilaEventosSobeOuDesce.esta_vazia())
        {
            GetElevador.getUltimo_evento_SobeDesce_desenfileirado = GetElevador.getFilaEventosSobeOuDesce.desenfileira();
            if (GetElevador.getAndar_atual == GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.getNumero_andar)
            {
                som_elevador_chegou.Play();
                yield return new WaitForSeconds(1);
                GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.abrePorta();
                yield return new WaitForSeconds(1);
                GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.usuario_entrar(this.GetElevador);
                yield return StartCoroutine(passo_2());
                StopCoroutine(passo_1());
            }

        }
    }

    public IEnumerator passo_2()
    {
        // PASSO 2: FECHA A PORTA DEPOIS DE 5 SEGUNDOS. SE O USUÁRIO NÃO ESCOLHER UM ANDAR PARA IR, ELE SAI DO ELEVADOR
        yield return new WaitForSeconds(GetElevador.getTempo_espera);
        Boolean conseguiu_enviar = GetPredio.getAndar_usuario.getUsuario.enviarEventoAoPainelElevador(GetPredio.getAndar_usuario, GetElevador);
        if (!conseguiu_enviar)
        {
            yield return new WaitForSeconds(1);
            GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.abrePorta();
            yield return new WaitForSeconds(1);
            GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.usuario_sair(this.GetElevador);
            getBtn_SubirUsuario.interactable = true;
            foreach (Button b in getBotoes_painel_elevador)
            {
                b.interactable = true;
            }
            GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.fechaPorta();
        }
        else
        {
            GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.fechaPorta();
            GetElevador.getUltimo_evento_PainelElevador_desenfileirado = GetElevador.getFilaPainelElevador.desenfileira();
            StartCoroutine(passo_3());
            StopCoroutine(passo_2());
        }


    }

    public IEnumerator passo_3()
    {
        // PASSO 3: O ELEVADOR ATENDE AOS ANDARES QUE O USUÁRIO PEDIU PARA IR. ENQUANTO TODOS NÃO FOREM ATENDIDOS, NÃO SAI DESSE MÉTODO

        int numero_do_andar_desejado_atual = GetElevador.getUltimo_evento_PainelElevador_desenfileirado.getNumero_do_andar_desejado_atual();
        String nome_andar = "andar_" + numero_do_andar_desejado_atual.ToString();
        Animator animador_elevador = GetElevador.getAnimador_elevador;

        // VAI PARA O ANDAR N
        animador_elevador.SetBool(nome_andar, true);
        animador_elevador.SetBool("parar", false);
        yield return new WaitForSeconds(1);

        // PARA NO ANDAR N
        animador_elevador.SetBool(nome_andar, false);
        GetElevador.getAndar_atual = numero_do_andar_desejado_atual;
        yield return new WaitForSeconds(1);

        // ABRE A PORTA DO ANDAR N
        GetPredio.getAndares_de_moradores[numero_do_andar_desejado_atual - 2].abrePorta();
        yield return new WaitForSeconds(GetElevador.getTempo_espera);

        // FECHA A PORTA DO ANDAR N
        GetPredio.getAndares_de_moradores[numero_do_andar_desejado_atual - 2].fechaPorta();
        GetElevador.getUltimo_evento_PainelElevador_desenfileirado.atenderProximo_andar();
        yield return new WaitForSeconds(1);

        if (!GetElevador.getUltimo_evento_PainelElevador_desenfileirado.getEvento_concluido)
        {
            StartCoroutine(passo_3());
        }
        else
        {
            StartCoroutine(passo_4());
            StopCoroutine(passo_3());
        }

    }


    public IEnumerator passo_4()
    {
        // PASSO 4: DEPOIS DE IR A TODOS OS ANDARES PEDIDOS PELO USUÁRIO, ELE VOLTA AO 1o ANDAR.

        // VOLTANDO AO 1o ANDAR
        Animator animador_elevador = GetElevador.getAnimador_elevador;
        animador_elevador.SetBool("andar_1", true);
        animador_elevador.SetBool("parar", false);
        yield return new WaitForSeconds(1);
        animador_elevador.SetBool("andar_1", false);
        animador_elevador.SetBool("parar", true);

        // O USUÁRIO ABRE A PORTA, E SAI
        GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.abrePorta();
        yield return new WaitForSeconds(1);
        GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.usuario_sair(this.GetElevador);
        getBtn_SubirUsuario.interactable = true;
        foreach (Button b in getBotoes_painel_elevador)
        {
            b.interactable = true;
        }
        GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.fechaPorta();
        StopCoroutine(passo_4());
        
    }

    /*
    public IEnumerator passo_5)
    {

    }
    */
    //------------------------------------------------------------------------------------------------

    // AÇÕES DO USUÁRIO -> MÉTODOS ATIVADOS POR BOTÕES
    public void usuarioSubir()
    {
        this.getBtn_SubirUsuario.interactable = false;

        if (!jogo_comecou)
        {
            jogo_comecou = true;
            GetElevador.ativar_elevador();
        }

        AndarUsuario andarUsuario = GetPredio.getAndar_usuario;
        Elevador elevador = GetElevador;
        Usuario usuario = andarUsuario.getUsuario;

        usuario.pedir_para_subir(andarUsuario, elevador);
        StartCoroutine(passo_1());
    }

    public void usuarioIrParaO1oAndar()
    {
        getBotoes_painel_elevador[0].interactable = false;
        GetPredio.getAndar_usuario.getUsuario.escolher_andar(1);
    }

    public void usuarioIrParaO2oAndar()
    {
        getBotoes_painel_elevador[1].interactable = false;
        GetPredio.getAndar_usuario.getUsuario.escolher_andar(2);
    }

    public void usuarioIrParaO3oAndar()
    {
        getBotoes_painel_elevador[2].interactable = false;
        GetPredio.getAndar_usuario.getUsuario.escolher_andar(3);
    }

    public void usuarioIrParaO4oAndar()
    {
        getBotoes_painel_elevador[3].interactable = false;
        GetPredio.getAndar_usuario.getUsuario.escolher_andar(4);
    }

    // ------------------------------------------------------------------------
    // MÉTODOS AUXILIARES PARA A CONSTRUÇÃO DA CENA

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