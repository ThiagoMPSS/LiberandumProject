package com.liberandum.Tests;

import java.sql.SQLException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import com.liberandum.Configs.DbConn;
import com.liberandum.Entities.Categoria;
import com.liberandum.Entities.Evento;
import com.liberandum.Entities.GeoCoord;
import com.liberandum.Entities.Necessidade;
import com.liberandum.Entities.Perfil;
import com.liberandum.Entities.Usuario;
import com.liberandum.Entities.Enums.SexoEnum;

public class InsertTest {

    static DbConn db;

    public static void main(String[] args) throws SQLException {
        startDatabase();

        Usuario user = new Usuario("teste@teste.com", "naoseiasenha", Calendar.getInstance(), SexoEnum.M, "15981257863");
        
        Perfil perfil = new Perfil("Thiago", new Categoria("teste1"), user);
        Perfil perfil2 = new Perfil("Teste", new Categoria("teste2"), user);
        user.addPerfil(perfil);
        user.addPerfil(perfil2);
        
        user.add();

        Calendar cal = Calendar.getInstance();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy MM dd");
        try {
            cal.setTime(sdf.parse("2022 02 02"));
        } catch (ParseException e) {
            e.printStackTrace();
        }
        Evento evento = new Evento("Resgate", cal, new GeoCoord(-23.556593173791384, -46.68648584437965), perfil, new Necessidade("testeNecessidade"));
        evento.add();

        DbConn.getInstance().close();
    }

    private static void startDatabase() throws SQLException {
        db = DbConn.getInstance();
    }
}
