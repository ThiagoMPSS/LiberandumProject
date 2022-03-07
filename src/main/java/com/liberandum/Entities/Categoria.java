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
@Table(name="T_CATEGORIA")
public class Categoria extends EntityDefault {
    @Id
    @SequenceGenerator(name="sq_categoria", sequenceName="SQ_T_CATEGORIA", allocationSize=1)
    @GeneratedValue(strategy=GenerationType.SEQUENCE, generator="sq_categoria")
    @Column(name="id_categoria", length=60)
    private int id = 0;

    @Column(name="nm_categoria")
    private String nome = "";

    @OneToMany(mappedBy="categoria", cascade=CascadeType.PERSIST)
    private Collection<Perfil> perfis;

    public Categoria() {}

    public Categoria(String nome) {
        this.nome = nome;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    @Override
    public String toString() {
        return "Categoria [id=" + id + ", nome=" + nome + ", perfisLength=" + perfis.size() + "]";
    }

}
