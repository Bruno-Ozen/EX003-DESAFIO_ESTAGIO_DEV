using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventoPainelElevador
{

    private Usuario usuario_que_disparou;
    private Morador morador_que_disparou;
    private AndarUsuario andarUsuario;
    private AndarMorador andarMorador;
    private List<int> andares_desejados;
    private Boolean evento_concluido;
    private Boolean foi_um_morador;
    private int ponteiro_de_qual_esta_sendo_atendido;

    public EventoPainelElevador(Usuario usuario_disparou, Morador morador_disparou, AndarUsuario andar_usuario, AndarMorador andar_morador, List<int> andares_desejados)
    {
        this.getPonteiro_de_qual_esta_sendo_atendido = 0;
        this.usuario_que_disparou = usuario_disparou;
        this.morador_que_disparou = morador_disparou;
        this.getAndarUsuario = andar_usuario;
        this.getAndarMorador = andar_morador;
        this.getAndares_desejados = andares_desejados;
        this.getEvento_concluido = false;

        if (this.usuario_que_disparou != null && this.morador_que_disparou == null)
        {
            getFoi_um_morador = false;
        }
        else if (this.usuario_que_disparou == null && this.morador_que_disparou != null)
        {
            getFoi_um_morador = true;
        }
    }

    public int getNumero_do_andar_desejado_atual()
    {
        return this.andares_desejados[this.getPonteiro_de_qual_esta_sendo_atendido];
    }

    public void atenderProximo_andar()
    {
        if (getPonteiro_de_qual_esta_sendo_atendido < (andares_desejados.Count - 1)) {
            getPonteiro_de_qual_esta_sendo_atendido++;
        }
        else
        {
            getEvento_concluido = true;
        }
    }

    public bool getFoi_um_morador { get => foi_um_morador; set => foi_um_morador = value; }
    public bool getEvento_concluido { get => evento_concluido; set => evento_concluido = value; }
    public List<int> getAndares_desejados { get => andares_desejados; set => andares_desejados = value; }
    public AndarUsuario getAndarUsuario { get => andarUsuario; set => andarUsuario = value; }
    public AndarMorador getAndarMorador { get => andarMorador; set => andarMorador = value; }
    public int getPonteiro_de_qual_esta_sendo_atendido { get => ponteiro_de_qual_esta_sendo_atendido; set => ponteiro_de_qual_esta_sendo_atendido = value; }
}
