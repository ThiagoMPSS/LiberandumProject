package com.liberandum.Entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

@Entity
@Table(name="T_PERFIL")
public class Perfil {
    @Id
    @SequenceGenerator(name="sq_perfil", sequenceName="SQ_T_PERFIL", allocationSize=1)
    @GeneratedValue(strategy=GenerationType.SEQUENCE, generator="sq_perfil")
    @Column(name="id_perfil", length=60, nullable=false)
    private int id = 0;

    @Column(name="nm_perfil", length=60, nullable=false)
    private String nome = "";

    @JoinColumn(name="T_USUARIO_id_user")
    @ManyToOne
    private Usuario usuario = null;

    @JoinColumn(name="T_CATEGORIA_id_categoria")
    @ManyToOne
    private Categoria categoria;

    public Perfil() {}

    public Perfil(int id, String nome, Categoria categoria) {
        this.id = id;
        this.nome = nome;
        this.categoria = categoria;
    }

    public Perfil(int id, String nome, Categoria categoria, Usuario usuario) {
        this(id, nome, categoria);
        this.usuario = usuario;
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

    public Usuario getUsuario() {
        return usuario;
    }

    public void setUsuario(Usuario usuario) {
        this.usuario = usuario;
    }

}
