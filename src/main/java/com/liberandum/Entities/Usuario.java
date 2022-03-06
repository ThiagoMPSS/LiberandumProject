package com.liberandum.Entities;

import java.util.Calendar;
import java.util.Collection;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import com.liberandum.Entities.Enums.SexoEnum;


@Entity
@Table(name="T_USUARIO")
public class Usuario {

    @Id
    @SequenceGenerator(name="sq_usuario", sequenceName="SQ_T_USUARIO", allocationSize=1)
    @GeneratedValue(strategy=GenerationType.SEQUENCE, generator="sq_usuario")
    @Column(name="id_user")
    private int id = 0;

    @Column(name="email_user", length=60, nullable=false)
    private String email = "";

    @Column(name="senha_user", nullable=false)
    private String senha = "";

    @Column(name="dtnasc_user", nullable=false)
    @Temporal(TemporalType.DATE)
    private Calendar dt_nasc = null;

    @Column(name="sexo_user", nullable=false)
    @Enumerated(EnumType.STRING)
    private SexoEnum sexo = null;

    @Column(name="nrcontato_user", length=20, nullable=false)
    private int nr_contato = 0;

    @OneToMany(mappedBy="usuario")
    private Collection<Perfil> usuarios = null;

    public Usuario() {}

    public Usuario(int id, String email, String senha, Calendar dt_nasc,
                    SexoEnum sexo, int nr_contato) {
        this.id = id;
        this.email = email;
        this.senha = senha;
        this.dt_nasc = dt_nasc;
        this.sexo = sexo;
        this.nr_contato = nr_contato;
    }

    public Usuario(int id, String email, String senha, Calendar dt_nasc,
                    SexoEnum sexo, int nr_contato, Collection<Perfil> usuarios) {
        this(id, email, senha, dt_nasc, sexo, nr_contato);
        this.usuarios = usuarios;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

    public Calendar getDt_nasc() {
        return dt_nasc;
    }

    public void setDt_nasc(Calendar dt_nasc) {
        this.dt_nasc = dt_nasc;
    }

    public SexoEnum getSexo() {
        return sexo;
    }

    public void setSexo(SexoEnum sexo) {
        this.sexo = sexo;
    }

    public int getNr_contato() {
        return nr_contato;
    }

    public void setNr_contato(int nr_contato) {
        this.nr_contato = nr_contato;
    }

    public Collection<Perfil> getUsuarios() {
        return usuarios;
    }

}
