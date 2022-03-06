package com.liberandum;

import java.sql.SQLException;

import javax.persistence.Persistence;

public class Application {

    public static void main(String[] args) throws SQLException {
        startDatabase();
    }

    private static void startDatabase() throws SQLException {
        Persistence.createEntityManagerFactory("liberandum-orm").createEntityManager();
    }
}
