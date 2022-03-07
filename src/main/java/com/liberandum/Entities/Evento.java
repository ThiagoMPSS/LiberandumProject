package com.liberandum.Entities;

import java.text.SimpleDateFormat;
import java.util.Calendar;

import javax.persistence.CascadeType;
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
public class Evento extends EntityDefault {
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
    private double latitude = 0;

    @Column(name="longitude_evento", nullable=false)
    private double longitude = 0;

    @ManyToOne(cascade=CascadeType.PERSIST)
    @JoinColumn(name="T_PERFIL_id_perfil", nullable=false)
    private Perfil perfil = null;

    @ManyToOne(cascade=CascadeType.PERSIST)
    @JoinColumn(name="T_NECESSIDADE_id_necessidade", nullable=false)
    private Necessidade necessidade = null;

    public Evento() {}

    public Evento(String tipo, Calendar data, GeoCoord coords) {
        this.tipo = tipo;
        this.data = data;
        this.latitude = coords.getLatitude();
        this.longitude = coords.getLongitude();
    }

    public Evento(String tipo, Calendar data, GeoCoord coords, Perfil perfil, Necessidade necessidade) {
        this(tipo, data, coords);
        this.perfil = perfil;
        this.necessidade = necessidade;
    }
    
    public int getId() {
        return id;
    }
    
    public void setId(int id) {
        this.id = id;
    }
    
    public String getTipo() {
        return tipo;
    }
    
    public void setTipo(String tipo) {
        this.tipo = tipo;
    }
    
    public Calendar getData() {
        return data;
    }
    
    public void setData(Calendar data) {
        this.data = data;
    }
    
    public GeoCoord getCoords() {
        return new GeoCoord(latitude, longitude);
    }

    public void setCoords(GeoCoord coords) {
        this.latitude = coords.getLatitude();
        this.longitude = coords.getLongitude();
    }

    public void setCoords(double latitude, double longitude) {
        this.latitude = latitude;
        this.longitude = longitude;
    }
    
    public Perfil getPerfil() {
        return perfil;
    }
    
    public void setPerfil(Perfil perfil) {
        this.perfil = perfil;
    }
    
    public Necessidade getNecessidade() {
        return necessidade;
    }
    
    public void setNecessidade(Necessidade necessidade) {
        this.necessidade = necessidade;
    }

    @Override
    public String toString() {
        return "Evento [data=" + new SimpleDateFormat("dd/MM/yyyy").format(data.getTime()) + ", id=" + id + ", coords=" + getCoords()
                + ", necessidade=" + necessidade.getTipo() + ", perfil=" + perfil.getId() + ", tipo=" + tipo + "]";
    }

}
