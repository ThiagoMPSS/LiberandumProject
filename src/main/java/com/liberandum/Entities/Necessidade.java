package com.liberandum.Entities;

import java.util.Collection;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

@Entity
@Table(name="T_NECESSIDADE")
public class Necessidade extends EntityDefault {
    @Id
    @SequenceGenerator(name="sq_necessidade", sequenceName="SQ_T_NECESSIDADE", allocationSize=1)
    @GeneratedValue(strategy=GenerationType.SEQUENCE, generator="sq_necessidade")
    @Column(name="id_necessidade", length=60)
    private int id = 0;

    @Column(name="tp_necessidade", length=60, nullable=false)
    private String tipo = "";

    @OneToMany(mappedBy="necessidade", cascade=CascadeType.PERSIST)
    private Collection<Evento> eventos;

    public Necessidade() {}

    public Necessidade(String tipo) {
        this.tipo = tipo;
    }

    public Necessidade(String tipo, Collection<Evento> eventos) {
        this(tipo);
        this.eventos = eventos;
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

    public Collection<Evento> getEventos() {
        return eventos;
    }

    public void setEventos(Collection<Evento> eventos) {
        this.eventos = eventos;
    }

}
