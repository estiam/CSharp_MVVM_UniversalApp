using Newtonsoft.Json;
using PokemonUniversalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace PokemonUniversalApp.DAL
{
    public static class PokeAPI
    {
        const string POKEMON_API_URL = "https://pokeapi.co/api/v2/pokemon/?limit=151";
        public static async Task<List<Pokemon>> LoadPokemonsAsync()
        {

            HttpClient hc = new HttpClient();
            HttpResponseMessage httpResponse = await hc.GetAsync(new Uri(POKEMON_API_URL));
            httpResponse.EnsureSuccessStatusCode();
            string json = await httpResponse.Content.ReadAsStringAsync();
            PokemonData result = JsonConvert.DeserializeObject<PokemonData>(json);

            return result.Results;
        }

        public async static Task<Pokemon> LoadPokemonAsync(string pokeUrl)
        {

            HttpClient hc = new HttpClient();
            HttpResponseMessage httpResponse = await hc.GetAsync(new Uri(pokeUrl));
            httpResponse.EnsureSuccessStatusCode();
            string json = await httpResponse.Content.ReadAsStringAsync();
            Pokemon result = JsonConvert.DeserializeObject<Pokemon>(json);

            return result;
        }
    }
}