package com.liberandum.Entities;

import javax.persistence.EntityManager;

import com.liberandum.Configs.DbConn;

public abstract class EntityDefault {
    
    // public <T extends EntityDefault> EntityDefault find(Object pk) {    
    //     return DbConn.getInstance().getEntityManager().find(this.getClass(), pk);
    // }

    public static EntityDefault find(Class<? extends EntityDefault> entityClass, Object pk) {
        System.out.println(entityClass);
        EntityDefault ret = DbConn.getInstance().getEntityManager().find(entityClass, pk);
        return ret;
    }

    public void add() {
        EntityManager em = DbConn.getInstance().getEntityManager();
        try {
            em.persist(this);
            em.getTransaction().begin();
            em.getTransaction().commit();
        } catch (Exception ex) {
            if (em.getTransaction().isActive()) {
                em.getTransaction().rollback();
            }
            ex.printStackTrace();
        }
    }

    public void update() {
        EntityManager em = DbConn.getInstance().getEntityManager();
        try {
            em.merge(this);
            em.getTransaction().begin();
            em.getTransaction().commit();
        } catch (Exception ex) {
            if (em.getTransaction().isActive()) {
                em.getTransaction().rollback();
            }
            ex.printStackTrace();
        }
    }

    public void remove() {
        EntityManager em = DbConn.getInstance().getEntityManager();
        try {
            em.remove(this);
            em.getTransaction().begin();
            em.getTransaction().commit();
        } catch (Exception ex) {
            if (em.getTransaction().isActive()) {
                em.getTransaction().rollback();
            }
            ex.printStackTrace();
        }
    }

}
