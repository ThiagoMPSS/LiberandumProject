package com.liberandum.Tests;

import java.sql.SQLSyntaxErrorException;

import com.liberandum.Configs.DbConn;
import com.liberandum.Entities.Usuario;

public class DeleteTest {
    
    static DbConn db;

    public static void main(String[] args) throws SQLSyntaxErrorException {
        startDatabase();

        Usuario u = (Usuario) Usuario.find(Usuario.class, 1);
        if (u.delete())
            System.out.println("Registro(s) removidos!");
        else
            System.err.println("Ocorreu um erro ao remover o(s) registro(s)");


        DbConn.getInstance().close();
    }

    private static void startDatabase() throws SQLSyntaxErrorException {
        db = DbConn.getInstance();
    }

}
