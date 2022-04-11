using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Teste.Api.Enumerator.v1;

namespace Teste.Api.Data.Repository.Entity
{
    public class ClientesEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        //Deve validar o cpf, deve ter mascara
        public string CPF { get; set; }
        public DateTime? DataNasc { get; set; }
        [DefaultValue(0)]
        public int Idade
        {
            get
            {
                return calcIdade(DataNasc.GetValueOrDefault(DateTime.Now));
            }
        }
        [JsonProperty("Profissao", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Profissao { get; set; }
        public int calcIdade(DateTime dataNasc)
        {
            DateTime bday = new DateTime(dataNasc.Year, dataNasc.Month, dataNasc.Day);
            DateTime now = DateTime.Today;
            int age = now.Year - bday.Year;
            return bday > now.AddYears(-age) ? age-- : age;
        }
    }
}
