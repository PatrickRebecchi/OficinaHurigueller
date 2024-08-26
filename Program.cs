using System;
using OficinaHurigueller.Data;
using OficinaHurigueller.Models;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new OficinaContext())
        {
            // Criar um novo cliente
            Console.WriteLine("Inserindo um novo cliente...");
            db.Clientes.Add(new Cliente { Nome = "João Silva", Placa = "XYZ-1234", ModeloCarro = "Fusca", Telefone = "99999-9999" });
            db.SaveChanges();

            // Listar todos os clientes
            Console.WriteLine("Listando todos os clientes...");
            foreach (var cliente in db.Clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Placa: {cliente.Placa}, Modelo: {cliente.ModeloCarro}, Telefone: {cliente.Telefone}");
            }

            // Atualizar um cliente
            Console.WriteLine("Atualizando o cliente...");
            var clienteToUpdate = db.Clientes.Find(1);
            if (clienteToUpdate != null)
            {
                clienteToUpdate.Telefone = "88888-8888";
                db.SaveChanges();
            }

            // Excluir um cliente
            Console.WriteLine("Excluindo o cliente...");
            var clienteToDelete = db.Clientes.Find(1);
            if (clienteToDelete != null)
            {
                db.Clientes.Remove(clienteToDelete);
                db.SaveChanges();
            }
        }
    }
}
