package com.liberandum.Tests;

import java.sql.SQLSyntaxErrorException;

import com.liberandum.Configs.DbConn;
import com.liberandum.Entities.Usuario;

public class SelectTest {
    static DbConn db;

    public static void main(String[] args) throws SQLSyntaxErrorException {
        startDatabase();

        Usuario u = (Usuario) Usuario.find(Usuario.class, 1);
        System.out.println();
        System.out.println();
        System.out.println();
        System.out.println(u);


        DbConn.getInstance().close();
    }

    private static void startDatabase() throws SQLSyntaxErrorException {
        db = DbConn.getInstance();
    }
}
