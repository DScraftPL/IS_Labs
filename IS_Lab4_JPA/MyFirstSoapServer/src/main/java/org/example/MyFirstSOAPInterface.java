package org.example;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;
import java.util.List;

//Service Endpoint Interface
@WebService // oznaczenie klasy jako SEO (Service Endpoint Interface)
@SOAPBinding(style = Style.RPC)
public interface MyFirstSOAPInterface {
    @WebMethod
    String getHelloWorldAsString(String name);

    @WebMethod
    long getDaysBetweenDates(String date1, String date2);

    @WebMethod
    Produkt getProductById(int id);

    @WebMethod
    MyFirstWS.ProductList getProdukty();
}