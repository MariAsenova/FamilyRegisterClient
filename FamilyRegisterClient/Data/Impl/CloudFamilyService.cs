using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Familyregister.Data.Impl
{
    public class CloudFamilyService : IFamilyService
    {
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:5002/families");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            string result = await response.Content.ReadAsStringAsync();
            IList<Family> families = JsonSerializer.Deserialize<IList<Family>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return families;
        }

        public async Task UpdateAsync(Adult adult)
        {
            HttpClient client = new HttpClient();

            string adultAsJson = JsonSerializer.Serialize(adult);

            HttpContent contentAdult = new StringContent(
                adultAsJson,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PatchAsync("https://localhost:5002/families", contentAdult);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                GetFamiliesAsync();
            }
            else
            {
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task UpdateAsync(Adult adult, Family family)
        {
            HttpClient client = new HttpClient();

            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(
                adultAsJson,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PatchAsync(
                $@"https://localhost:5002/families?StreetName={family.StreetName}&HouseNumber={family.HouseNumber}",
                content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                Console.WriteLine($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task<Adult> GetAdultAsync(int id)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($@"https://localhost:5002/families/{id}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                throw new Exception($@"Error: {response.StatusCode}, {response.StatusCode}");
            }

            string result = await response.Content.ReadAsStringAsync();
            Adult adult = JsonSerializer.Deserialize<Adult>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return adult;
        }

        public async Task RemoveAdultAsync(int id)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.DeleteAsync($@"https://localhost:5002/families/{id}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task AddAdultAsync(Adult adult, Family family)
        {
            HttpClient client = new HttpClient();
            string adultAsJson = JsonSerializer.Serialize(adult);

            HttpContent content = new StringContent(
                adultAsJson,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response =
                await client.PostAsync(
                    $@"https://localhost:5002/families?StreetName={family.StreetName}&HouseNumber={family.HouseNumber}",
                    content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                Console.WriteLine($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
    }
}