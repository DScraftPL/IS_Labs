package org.example;

import javax.jws.WebService;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import java.time.Duration;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

@WebService(endpointInterface = "org.example.MyFirstSOAPInterface")
public class MyFirstWS implements MyFirstSOAPInterface {

    public String getHelloWorldAsString(String nazwa) {
        String message = "Witaj " + nazwa + "!";
        return message;
    }

    public long getDaysBetweenDates(String date1, String
            date2) {
        long numberOfDays = 0;
        DateTimeFormatter dtf =
                DateTimeFormatter.ofPattern("yyyy-MM-dd");
        try {
            LocalDateTime tempdate1 = LocalDate.parse(date1,
                    dtf).atStartOfDay();
            LocalDateTime tempdate2 = LocalDate.parse(date2,
                    dtf).atStartOfDay();
            numberOfDays = Duration.between(tempdate1,
                    tempdate2).toDays();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return numberOfDays;
    }

    private List<Produkt> produkty = new ArrayList<>();

    MyFirstWS() {
        produkty.add(new Produkt(1, "komputer"));
        produkty.add(new Produkt(2, "myszka"));
        produkty.add(new Produkt(3, "laptop"));
    }

    public ProductList getProdukty() {
        ProductList productList = new ProductList();
        productList.setProducts(produkty);
        return productList;
    }

    public Produkt getProductById(int id){
        for (Produkt p : produkty){
            if(p.getId() == id){
                return p;
            }
        }
        return null;
    }

    @XmlRootElement
    public static class ProductList {
        private List<Produkt> produkty;

        public ProductList() {
            produkty = new ArrayList<>();
        }

        @XmlElement(name = "product")
        public List<Produkt> getProducts() {
            return produkty;
        }

        public void setProducts(List<Produkt> products) {
            this.produkty = products;
        }
    }
}
