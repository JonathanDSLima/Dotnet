using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade1
{
    internal class Paciente
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }

        public List<string> Procedimentos { get; private set; }

        public  Paciente(string nome, string cpf, List<string> procedimentos)
        {
            Nome = nome;
            CPF = cpf;
            Procedimentos = procedimentos;  
        }

    }
}
