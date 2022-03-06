package com.liberandum.Entities;

import java.util.Collection;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

@Entity
@Table(name="T_NESCESSIDADE")
public class Nescessidade {
    @Id
    @SequenceGenerator(name="sq_nescessidade", sequenceName="SQ_T_NESCESSIDADE", allocationSize=1)
    @GeneratedValue(strategy=GenerationType.SEQUENCE, generator="sq_nescessidade")
    @Column(name="id_nescessidade", length=60)
    private int id = 0;

    @Column(name="tp_nescessidade", length=60, nullable=false)
    private String tipo = "";

    @OneToMany(mappedBy="nescessidade")
    private Collection<Evento> eventos;
}
