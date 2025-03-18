package com.lg;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * Klasa encji reprezentująca rolę w systemie.
 */
@Entity
@Table(name = "roles")
public class Role {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false, unique = true)
    private String name;

    /**
     * Domyślny konstruktor.
     */
    public Role() {
    }

    /**
     * Konstruktor z parametrami.
     *
     * @param name nazwa roli
     */
    public Role(String name) {
        this.name = name;
    }

    /**
     * Pobiera identyfikator roli.
     *
     * @return identyfikator roli
     */
    public Long getId() {
        return id;
    }

    /**
     * Ustawia identyfikator roli.
     *
     * @param id identyfikator roli
     */
    public void setId(Long id) {
        this.id = id;
    }

    /**
     * Pobiera nazwę roli.
     *
     * @return nazwa roli
     */
    public String getName() {
        return name;
    }

    /**
     * Ustawia nazwę roli.
     *
     * @param name nazwa roli
     */
    public void setName(String name) {
        this.name = name;
    }

    @Override
    public String toString() {
        return "Role [id=" + id + ", name=" + name + "]";
    }
}
