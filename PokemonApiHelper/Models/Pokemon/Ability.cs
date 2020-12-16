﻿using System.Text.Json.Serialization;

namespace PokemonApiHelper.Models.Pokemon
{
    public class Ability
    {
        [JsonPropertyName("id")]
        public int Id
        {
            get; set;
        }

        [JsonPropertyName("name")]
        public string Name
        {
            get; set;
        }
    }
}
