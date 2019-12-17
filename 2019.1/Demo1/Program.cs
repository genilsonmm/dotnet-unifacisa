using System;
using System.Collections.Generic;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaração de variáveis
            string message = "Hello World!";
            int year = 2019;
            decimal value = 30.4M;
            float pressure = 48.98F;
            DateTime today = DateTime.Now;

            //Imprimir
            Console.WriteLine($"{message} {year} {value} {pressure} {today}");

            //Criando objeto
            Customer customer1 = new Customer("Genilson", 1);
            
            //Imprimindo dados do objeto
            Console.WriteLine($"{customer1.GetName()} {customer1.GetCode()}");

            //Coleção de clientes
            List<Customer> customers = new List<Customer>();
            Customer customer2 = new Customer("Danielle", 2);
            Customer customer3 = new Customer("Hamurabi", 3);
            Customer customer4 = new Customer("Adriano", 4);

            //Adicionando os clientes na coleção de clientes
            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);
            customers.Add(customer4);

            //Imprime todos os clientes da lista
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.GetName()} {customer.GetCode()}");
            }

            //Pesquisa e imprime um cliente
            Customer myCustomer = customers.Find(c => c.GetCode() == 1);
            Console.WriteLine($"Meu cliente: {myCustomer.GetName()} {myCustomer.GetCode()}");
        }
    }
}
