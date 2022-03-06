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
@Table(name="T_NECESSIDADE")
public class Necessidade {
    @Id
    @SequenceGenerator(name="sq_necessidade", sequenceName="SQ_T_NECESSIDADE", allocationSize=1)
    @GeneratedValue(strategy=GenerationType.SEQUENCE, generator="sq_necessidade")
    @Column(name="id_necessidade", length=60)
    private int id = 0;

    @Column(name="tp_necessidade", length=60, nullable=false)
    private String tipo = "";

    @OneToMany(mappedBy="necessidade")
    private Collection<Evento> eventos;
}
