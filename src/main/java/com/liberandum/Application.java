package com.liberandum;

import java.sql.SQLException;

import com.liberandum.Configs.DbConn;
import com.liberandum.Entities.EntityDefault;
import com.liberandum.Entities.Necessidade;

public class Application {

    static DbConn db;

    public static void main(String[] args) throws SQLException {
        startDatabase();

        Necessidade n = new Necessidade("Teste");
        n.add();
        System.out.println(((Necessidade) EntityDefault.find(Necessidade.class, 1)).getTipo());
        n.setTipo("Testando");
        n.update();
        System.out.println(((Necessidade) EntityDefault.find(Necessidade.class, 1)).getTipo());
        EntityDefault.find(Necessidade.class, 1).remove();

        DbConn.getInstance().close();
    }

    private static void startDatabase() throws SQLException {
        db = DbConn.getInstance();
    }
}
