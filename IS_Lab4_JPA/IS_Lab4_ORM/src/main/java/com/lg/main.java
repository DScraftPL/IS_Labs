package com.lg;

import javax.persistence.EntityManager;
import javax.persistence.Persistence;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Query;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;

public class main {
    public static void main(String[] args) {
        System.out.println("JPA project");
        EntityManagerFactory factory =
                Persistence.createEntityManagerFactory("Hibernate_JPA");
        EntityManager em = factory.createEntityManager();
        em.getTransaction().begin();

        User u1 = new User(null, "test_1", "test_1", "Andrzej", "Kowalski", Sex.Male);
        User u2 = new User(null, "test_2", "test_2", "Anna", "Nowak", Sex.Female);
        User u3 = new User(null, "test_3", "test_3", "Piotr", "Wiśniewski", Sex.Male);
        User u4 = new User(null, "test_4", "test_4", "Katarzyna", "Kowalski", Sex.Female);
        User u5 = new User(null, "test_5", "test_5", "Michał", "Lewandowski", Sex.Male);

        Role role1 = new Role("ADMIN");
        Role role2 = new Role("USER");
        Role role3 = new Role("MODERATOR");
        Role role4 = new Role("EDITOR");
        Role role5 = new Role("VIEWER");

        em.persist(u1);
        em.persist(u2);
        em.persist(u3);
        em.persist(u4);
        em.persist(u5);
        em.persist(role1);
        em.persist(role2);
        em.persist(role3);
        em.persist(role4);
        em.persist(role5);
        em.getTransaction().commit();
        em.close();

        em = factory.createEntityManager();
        em.getTransaction().begin();
        User user = em.find(User.class, 1L);
        if (user != null) {
            user.setPassword("123");
            em.merge(user);
            em.getTransaction().commit();
        } else {
            em.getTransaction().rollback();
        }
        em.close();

        em = factory.createEntityManager();
        em.getTransaction().begin();
        Role rola = em.find(Role.class, 5L);
        if(rola != null){
            em.remove(rola);
            em.getTransaction().commit();
        } else {
            em.getTransaction().rollback();
        }

        em = factory.createEntityManager();
        em.getTransaction().begin();
        Query query = em.createQuery("SELECT u FROM User u WHERE u.lastName = 'Kowalski'");
        List<User> kowalscy = query.getResultList();
        em.getTransaction().commit();

        System.out.println("Kowalski: ");
        for(User kowalski : kowalscy){
            System.out.println(kowalski.getFirstName() + " " + kowalski.getLastName());
        }

        em = factory.createEntityManager();
        em.getTransaction().begin();
        query = em.createQuery("SELECT u FROM User u WHERE u.sex = 'Female'");
        List<User> kobiety = query.getResultList();
        em.getTransaction().commit();

        System.out.println("Kobiety: ");
        for(User kobieta: kobiety){
            System.out.println(kobieta.getFirstName() + " " + kobieta.getLastName());
        }

        em = factory.createEntityManager();
        em.getTransaction().begin();

        User zrolami = new User(null, "test_10", "test_10", "Bartek", "Kowalski", Sex.Male);

        role1 = em.find(Role.class, role1.getId());
        role3 = em.find(Role.class, role3.getId());

        zrolami.addRole(role1);
        zrolami.addRole(role3);

        em.persist(zrolami);
        em.getTransaction().commit();
        em.close();

        System.out.println("Dodane role!");

        em = factory.createEntityManager();
        em.getTransaction().begin();

        User user1 = new User(null, "john_doe", "password123", "John", "Doe", Sex.Male);
        User user2 = new User(null, "jane_doe", "securePass", "Jane", "Doe", Sex.Female);

        UsersGroup group1 = new UsersGroup("Admin Group");
        UsersGroup group2 = new UsersGroup("User Group");

        user1.joinGroup(group1);
        user1.joinGroup(group2);
        user2.joinGroup(group2);

        em.persist(group1);
        em.persist(group2);
        em.persist(user1);
        em.persist(user2);

        em.getTransaction().commit();
        em.close();

        System.out.println("Dodano uzytkownikow z grupami!");

        em = factory.createEntityManager();
        em.getTransaction().begin();

        User zobrazkiem = new User(null, "hello", "world", "Hello", "World", Sex.Male);
        try {
            byte[] image = Files.readAllBytes(Path.of("src/main/resources/images/logo_politechniki_lubelskiej.jpg"));
            zobrazkiem.setImage(image);
            System.out.println("Dodano obrazek!");
        } catch (IOException e) {
            e.printStackTrace();
        }

        em.persist(zobrazkiem);

        em.getTransaction().commit();
        em.close();

        factory.close();

        System.out.println("koniec!");
    }
}
