using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Api.Options
{
    public class TesteApiOptions
    {
        public const string Key = "TesteApi";
        public string URL { get; set; }
        public string Autorization { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }
    }
}
