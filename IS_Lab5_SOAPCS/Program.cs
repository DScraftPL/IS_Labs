// See https://aka.ms/new-console-template for more information
using s1 = ServiceReference1;
using s2 = ServiceReference2;

Console.WriteLine("Hello, World!");

Console.WriteLine("My First SOAP Client!");
s1.MyFirstSOAPInterfaceClient client1 = new s1.MyFirstSOAPInterfaceClient();
    
string text = await client1.getHelloWorldAsStringAsync("Kacper Wiacek");
var text2 = await client1.getDaysBetweenDatesAsync("2025-03-17", "2025-03-18");
Console.WriteLine(text);
Console.WriteLine(text2);

Console.WriteLine("This is updated Client!");
s2.MyFirstSOAPInterfaceClient client2 = new s2.MyFirstSOAPInterfaceClient();

s2.getProduktyResponse response = await client2.getProduktyAsync();

//Console.WriteLine(response);

foreach (var p in response.@return)
{
    Console.WriteLine(p.name);
}

var produkt = await client2.getProductByIdAsync(1);

Console.WriteLine("Nazwa produktu z id 1:", produkt.name);

Console.WriteLine("The end!");