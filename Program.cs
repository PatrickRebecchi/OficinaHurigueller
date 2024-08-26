using System;
using OficinaHurigueller.Data;
using OficinaHurigueller.Models;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Sistema de Gerenciamento de Clientes - Oficina Hurigueller Artesanal");
            Console.WriteLine("1 - Adicionar Cliente");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("3 - Atualizar Cliente");
            Console.WriteLine("4 - Excluir Cliente");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarCliente();
                    break;
                case "2":
                    ListarClientes();
                    break;
                case "3":
                    AtualizarCliente();
                    break;
                case "4":
                    ExcluirCliente();
                    break;
                case "5":
                    Console.WriteLine("Saindo do sistema...");
                    return;
                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AdicionarCliente()
    {
        using (var db = new OficinaContext())
        {
            Console.Clear();
            Console.WriteLine("Adicionar Novo Cliente");

            Console.Write("Nome: ");
            var nome = Console.ReadLine();

            Console.Write("Placa: ");
            var placa = Console.ReadLine();

            Console.Write("Modelo do Carro: ");
            var modeloCarro = Console.ReadLine();

            Console.Write("Telefone: ");
            var telefone = Console.ReadLine();

            var cliente = new Cliente { Nome = nome, Placa = placa, ModeloCarro = modeloCarro, Telefone = telefone };
            db.Clientes.Add(cliente);
            db.SaveChanges();

            Console.WriteLine("Cliente adicionado com sucesso! Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }

    static void ListarClientes()
    {
        using (var db = new OficinaContext())
        {
            Console.Clear();
            Console.WriteLine("Lista de Clientes");

            foreach (var cliente in db.Clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Placa: {cliente.Placa}, Modelo: {cliente.ModeloCarro}, Telefone: {cliente.Telefone}");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }

    static void AtualizarCliente()
    {
        using (var db = new OficinaContext())
        {
            Console.Clear();
            Console.WriteLine("Atualizar Cliente");

            Console.Write("Digite o ID do cliente que deseja atualizar: ");
            var id = int.Parse(Console.ReadLine());

            var cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado! Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            Console.Write("Novo Nome (deixe em branco para manter o atual): ");
            var nome = Console.ReadLine();
            if (!string.IsNullOrEmpty(nome))
            {
                cliente.Nome = nome;
            }

            Console.Write("Nova Placa (deixe em branco para manter a atual): ");
            var placa = Console.ReadLine();
            if (!string.IsNullOrEmpty(placa))
            {
                cliente.Placa = placa;
            }

            Console.Write("Novo Modelo do Carro (deixe em branco para manter o atual): ");
            var modeloCarro = Console.ReadLine();
            if (!string.IsNullOrEmpty(modeloCarro))
            {
                cliente.ModeloCarro = modeloCarro;
            }

            Console.Write("Novo Telefone (deixe em branco para manter o atual): ");
            var telefone = Console.ReadLine();
            if (!string.IsNullOrEmpty(telefone))
            {
                cliente.Telefone = telefone;
            }

            db.SaveChanges();

            Console.WriteLine("Cliente atualizado com sucesso! Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }

    static void ExcluirCliente()
    {
        using (var db = new OficinaContext())
        {
            Console.Clear();
            Console.WriteLine("Excluir Cliente");

            Console.Write("Digite o ID do cliente que deseja excluir: ");
            var id = int.Parse(Console.ReadLine());

            var cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado! Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            Console.WriteLine("Cliente excluído com sucesso! Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
