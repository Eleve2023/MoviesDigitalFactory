﻿using System.Text.Json.Serialization;

namespace Shared
{
        public class TvShowNetwork
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("logo_path")]
            public string? LogoPath { get; set; }

            [JsonPropertyName("origin_country")]
            public string? OriginCountry { get; set; }
        }
}
