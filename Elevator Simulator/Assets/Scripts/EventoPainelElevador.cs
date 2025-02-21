using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventoPainelElevador
{

    private Usuario usuario_que_disparou;
    private Morador morador_que_disparou;
    private List<int> andares_desejados;
    private Boolean evento_concluido;
    private Boolean foi_um_morador;

    public EventoPainelElevador(Usuario usuario_disparou, Morador morador_disparou, List<int> andares_desejados)
    {
        this.usuario_que_disparou = usuario_disparou;
        this.morador_que_disparou = morador_disparou;
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

    public bool getFoi_um_morador { get => foi_um_morador; set => foi_um_morador = value; }
    public bool getEvento_concluido { get => evento_concluido; set => evento_concluido = value; }
    public List<int> getAndares_desejados { get => andares_desejados; set => andares_desejados = value; }
}
