package com.liberandum.Tests;

import java.sql.SQLSyntaxErrorException;

import com.liberandum.Configs.DbConn;
import com.liberandum.Entities.Evento;
import com.liberandum.Entities.Necessidade;
import com.liberandum.Entities.Perfil;
import com.liberandum.Entities.Usuario;

public class UpdateTest {
    static DbConn db;

    public static void main(String[] args) throws SQLSyntaxErrorException {
        startDatabase();

        Usuario u = (Usuario) Usuario.find(Usuario.class, 2);
        u.setEmail("teste2@umtestequalquer.com");
        int pindex = 0;
        for (Perfil p : u.getPerfis()) {
            p.setNome("teste" + pindex);
            pindex++;
        }
        u.update(false);

        Evento e = (Evento) Evento.find(Evento.class, 52);
        e.setNecessidade(new Necessidade("Testando3"));
        e.setTipo("tipoTeste4");
        u.update();

        DbConn.getInstance().close();
    }

    private static void startDatabase() throws SQLSyntaxErrorException {
        db = DbConn.getInstance();
    }

}
