using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Teste.Api.Enumerator.v1;

namespace Teste.Api.Models.v1.Request
{
    public class ClienteModels
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Id { get; set; }
        [JsonProperty("Nome", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Nome { get; set; }
        [JsonProperty("Sobrenome", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Sobrenome { get; set; }
        //Deve validar o cpf, deve ter mascara
        [JsonProperty("CPF", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string CPF { get; set; }
        [JsonProperty("DataNasc", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public DateTime? DataNasc { get; set; }
        [DefaultValue(0)]
        [JsonProperty("Idade", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Idade
        {
            get
            {
                return calcIdade(DataNasc.GetValueOrDefault(DateTime.Now));
            }
        }
        [JsonProperty("Profissao", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public EnumProfissao Profissao { get; set; }
        public int calcIdade(DateTime dataNasc)
        {
            DateTime bday = new DateTime(dataNasc.Year, dataNasc.Month, dataNasc.Day);
            DateTime now = DateTime.Today;
            int age = now.Year - bday.Year;
            return bday > now.AddYears(-age) ? age-- : age;
        }
    }
}
