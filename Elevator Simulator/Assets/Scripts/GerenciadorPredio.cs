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
            if (!GetElevador.getFilaEventosSobeOuDesce.esta_vazia())
            {
                StartCoroutine(abre_elevador(som_elevador_chegou, this));
                if (GetPredio.getAndar_usuario.getUsuario.getDisparou_evento_painel_elevador)
                {
                    Debug.Log("AGORA SIIIM");
                    StartCoroutine(atender_evento_painel_elevador());
                }

            }
        }

    }

    // MÉTODOS DE CADA PASSO DO ELEVADOR ---------------------------------------------------------------------------

    public IEnumerator abre_elevador(AudioSource som_elevador, GerenciadorPredio gerenciador)
    {

        if (!GetElevador.getFilaEventosSobeOuDesce.esta_vazia())
        {
            this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado = GetElevador.getFilaEventosSobeOuDesce.desenfileira();
            if (this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getFoi_um_morador)
            {
                if (GetElevador.getAndar_atual == this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarMorador.getNumero_andar)
                {
                    som_elevador.Play();
                    yield return new WaitForSeconds(1);
                    this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarMorador.abrePorta();
                    yield return new WaitForSeconds(1);
                    this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarMorador.morador_entrar(this.GetElevador);
                }
            }
            else
            {
                if (GetElevador.getAndar_atual == this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.getNumero_andar)
                {
                    som_elevador.Play();
                    yield return new WaitForSeconds(1);
                    this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.abrePorta();
                    yield return new WaitForSeconds(1);
                    this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.usuario_entrar(this.GetElevador);
                    yield return StartCoroutine(fecha_elevador(gerenciador));
                }
                else
                {
                    // Se o elevador não estiver no andar do usuário, então seguir o próximo da fila do painel do elevador, e quando a fila
                    // tiver todos os eventos concluídos, ou coincidentemente parar no andar pedido pelo usuario, então ái sim ele abre
                    // então nesse caso, NÃO se desativaria todas as interfaces.
                }
            }

        }

    }

    public IEnumerator fecha_elevador(GerenciadorPredio gerenciador)
    {
        // Espera 5 segundos para fechar
        yield return new WaitForSeconds(this.GetElevador.getTempo_espera);

        if (this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getFoi_um_morador)
        {
            // SE FOI O MORADOR, FAZ ISSO
            this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarMorador.fechaPorta();
            // FAZER TUDO QUE TA ALI EMBAIXO NO ELSE, SÓ QUE PARA O MORADOR
        }
        else
        {
            // SE FOI O USUARIO, FAZ TUDO LOGO ABAIXO
            this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.fechaPorta();
            this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.getUsuario.enviarEventoAoPainelElevador(this.GetElevador);
            yield return new WaitForSeconds(1);

            if (this.GetElevador.getFilaPainelElevador.esta_vazia())
            {
                yield return new WaitForSeconds(1);
                this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.abrePorta();
                yield return new WaitForSeconds(1);
                this.GetElevador.getUltimo_evento_SobeDesce_desenfileirado.getAndarUsuario.usuario_sair(this.GetElevador);
                gerenciador.getBtn_SubirUsuario.interactable = true;
                foreach (Button b in gerenciador.getBotoes_painel_elevador)
                {
                    b.interactable = true;
                }
            }
            else
            {
                StartCoroutine(atender_evento_painel_elevador());
            }

        }

    }

    public IEnumerator atender_evento_painel_elevador()
    {
        yield return new WaitForSeconds(1);
        this.GetElevador.getUltimo_evento_PainelElevador_desenfileirado = this.GetElevador.getFilaPainelElevador.desenfileira();

        if (GetElevador.getUltimo_evento_PainelElevador_desenfileirado.getFoi_um_morador)
        {
            // CASO TENHA SIDO UM MORADOR QUE DISPAROU
        }
        else
        {
            // CASO TENHA SIDO UM USUARIO QUE DISPAROU
            List<int> andares_desejados_ordenados = this.GetElevador.getUltimo_evento_PainelElevador_desenfileirado.getAndares_desejados;

            for (int i = 0; i < andares_desejados_ordenados.Count; i++)
            {
                int andar_desejado_atual = andares_desejados_ordenados[i];
                if (andar_desejado_atual != GetElevador.getAndar_atual)
                {
                    String nome_andar = "andar_" + andar_desejado_atual.ToString();
                    Animator animador_elevador = GetElevador.getAnimador_elevador;
                    animador_elevador.SetBool("parar", false);
                    animador_elevador.SetBool(nome_andar, true);
                    yield return new WaitForSeconds(1);
                    animador_elevador.SetBool(nome_andar, false);

                    switch (andar_desejado_atual)
                    {
                        case 1:
                            GetElevador.getGameobjectElevador.transform.position = GetElevador.getPosicoes_andares[0];
                            break;
                        case 2:
                            GetElevador.getGameobjectElevador.transform.position = GetElevador.getPosicoes_andares[1];
                            break;
                        case 3:
                            GetElevador.getGameobjectElevador.transform.position = GetElevador.getPosicoes_andares[2];
                            break;
                        case 4:
                            GetElevador.getGameobjectElevador.transform.position = GetElevador.getPosicoes_andares[3];
                            break;
                    }

                    yield return new WaitForSeconds(5);

                }

            }

            GetElevador.getAnimador_elevador.SetBool("andar_1", true);

        }
    }

//------------------------------------------------------------------------------------------------

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