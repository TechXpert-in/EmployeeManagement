using System.Text.Json;
using BaseLibrary.Entities;
using Newtonsoft.Json;
namespace ClientLibrary.Services.Contracts
{
    class CustomerService
    {
        public List<Customer> LoadAndFilterCustomers(string filePath, decimal minimumPurchase, DateTime startDate)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    return new List<Customer>();
                }

                string jsonData = File.ReadAllText(filePath);

                List<Customer>? customers = JsonConvert.DeserializeObject<List<Customer>>(jsonData);

                if (customers == null || customers.Count == 0)
                {
                    Console.WriteLine("No customer data found.");
                    return new List<Customer>();
                }

                // Filter and sort customers
                var filteredCustomers = customers
                    .Where(c => c.PurchaseAmount >= minimumPurchase && c.LastPurchaseDate >= startDate)
                    .OrderByDescending(c => c.PurchaseAmount)
                    .ToList();

                return filteredCustomers;
            }
            catch (Newtonsoft.Json.JsonException jsonEx)
            {
                Console.WriteLine("Error parsing JSON: " + jsonEx.Message);
                return new List<Customer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
                return new List<Customer>();
            }
        }
    }
}
