using CimeqApi.Models;

namespace CimeqApi.Services
{
    public class ClientService
    {

        private static List<Client> clients = new List<Client>()
        {
            new Client()
            {
                Id = 1,
                Username = "Peter",
                LastName = "Godin",
                Email = "peter@gmail.com",
                Adress = "123 saint laurent strt",
                Password = "123456"
            },
            new Client()
            {
                Id = 2,
                Username = "Atoine",
                LastName = "Vicent",
                Email = "antoine@gmail.com",
                Adress = "456 saint joliette strt",
                Password = "654321"
            },
            // Adicionando dados para teste de login
            new Client()
            {
                Id = 3,
                Username = "Willian",
                LastName = "Godin",
                Email = "will@test.com",
                Adress = "123 saint laurent strt",
                Password = "123456"
            }
        };

        public static Client SignIn(string email, string password)
        {
            return clients.FirstOrDefault(c => c.Email == email && c.Password == password);
        }

        public static List<Client> All()
        {
            return clients.ToList(); // Retorna uma cópia da lista para evitar modificações inadvertidas
        }
        // Método para obter um cliente pelo ID
        public static Client GetById(int id)
        {
            return clients.FirstOrDefault(c => c.Id == id);
        }

        // Método para adicionar um novo cliente
        public static Client Add(Client client)
        {
            if (client != null)
            {
                client.Id = clients.Count + 1;
                clients.Add(client);
            }
            return client;
        }

        // Método para atualizar os dados de um cliente
        public static Client Update(int id, Client updatedClient)
        {
            var existingClient = clients.FirstOrDefault(c => c.Id == id);
            if (existingClient != null)
            {
                existingClient.Username = updatedClient.Username;
                existingClient.LastName = updatedClient.LastName;
                existingClient.Email = updatedClient.Email;
                existingClient.Adress = updatedClient.Adress;
                existingClient.Password = updatedClient.Password;
                return existingClient;
            }
            return null;

        }

        // Método para excluir um cliente pelo ID
        public static bool Delete(int id)
        {
            var clientToRemove = clients.FirstOrDefault(c => c.Id == id);
            if (clientToRemove != null)
            {
               clients.Remove(clientToRemove);
                return true;
            }
            return false;
        }

    }
}