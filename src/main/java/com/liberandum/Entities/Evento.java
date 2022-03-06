package com.liberandum.Entities;

import java.util.Calendar;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

@Entity
@Table(name="T_EVENTO")
public class Evento {
    @Id
    @SequenceGenerator(name="sq_evento", sequenceName="SQ_T_EVENTO")
    @GeneratedValue(strategy=GenerationType.SEQUENCE, generator="sq_evento")
    @Column(name="id_evento", length=60, nullable=false)
    private int id = 0;

    @Column(name="tp_evento", length=60, nullable=false)
    private String tipo = "";
    
    @Column(name="dt_evento", length=60, nullable=false)
    @Temporal(TemporalType.DATE)
    private Calendar data = null;

    @Column(name="latitude_evento", nullable=false)
    private float latitude = 0;

    @Column(name="longitude_evento", nullable=false)
    private float longitude = 0;

    @ManyToOne
    @JoinColumn(name="T_PERFIL_id_perfil", nullable=false)
    private Perfil perfil = null;

    @ManyToOne
    @JoinColumn(name="T_NESCESSIDADE_id_nescessidade", nullable=false)
    private Nescessidade nescessidade = null;

}
