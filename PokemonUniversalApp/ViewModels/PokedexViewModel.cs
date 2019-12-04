using GalaSoft.MvvmLight;
using PokemonUniversalApp.DAL;
using PokemonUniversalApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonUniversalApp.ViewModels
{
    public class PokedexViewModel : ViewModelBase
    {
        public PokedexViewModel()
        {
            LoadPokemons();
        }
        public async void LoadPokemons()
        {
            Pokemons = new ObservableCollection<Pokemon>(await PokeAPI.LoadPokemonsAsync());
        }
        private ObservableCollection<Pokemon> pokemons;

        public ObservableCollection<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { 
                pokemons = value;
                RaisePropertyChanged("Pokemons");
            }
        }

        private Pokemon selectedPokemon
            ;

        public Pokemon SelectedPokemon
        {
            get { return selectedPokemon; }
            set {
                Set<Pokemon>(() => this.selectedPokemon, ref selectedPokemon, value);
            }
        }

        private Pokemon loadedPokemon;

        public Pokemon LoadedPokemon
        {
            get { return loadedPokemon; }
            set {
                Set<Pokemon>(() => this.loadedPokemon, ref loadedPokemon, value);
            }
        }




    }
}
