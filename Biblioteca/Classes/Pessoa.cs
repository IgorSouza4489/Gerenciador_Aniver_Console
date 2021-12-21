using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Classes
{

    public class Pessoa 
    {        
        private string nome;
        private string sobrenome;
        private DateTime nascimento;
        public string Nome { get { return nome; } set { nome = value; } }
        public string Sobrenome { get { return sobrenome; } set { sobrenome = value; } }        
        [DataType(DataType.Date)]
        public DateTime Nascimento { get { return nascimento; } set { nascimento = value; } }
        public double tempo()
        {
            DateTime today = DateTime.Today;
            DateTime next = new DateTime(today.Year, Nascimento.Month, Nascimento.Day);
            if (next < today)
                next = next.AddYears(1);
            int numDays = (next - today).Days;
            return numDays;
        }

    }
}
