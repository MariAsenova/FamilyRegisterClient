using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Familyregister.Data.Impl
{
    public class UserService : IUserService
    {
        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            User user = await GetUserPasswordAsync(userName);
            if (user.Password.Equals(password))
            {
                Console.WriteLine("User password matches");
                return user;
            }
            // TODO check for incorrect password
            return user;
        }

        private async Task<User> GetUserPasswordAsync(string userName)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://localhost:5002/user?userName={userName}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                //Console.WriteLine($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            string result = await response.Content.ReadAsStringAsync();
            User userReturned = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return userReturned;
        }
    }
}