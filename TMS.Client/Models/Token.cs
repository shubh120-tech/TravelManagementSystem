﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Client.Models
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType{ get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        [JsonProperty("refress_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("error")]
        public string Errror { get; set; }

        [JsonProperty("userName")]
        public string userName { get; set; }


    }
}