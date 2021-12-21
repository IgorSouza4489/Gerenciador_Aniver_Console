using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca.Classes
{
    public class Rep : Pessoa, IPadrao
    
    {
        private List<Pessoa> myList = new List<Pessoa>();
        public void inserir()
        {
            while (true)
            {               
                Console.WriteLine("Informe o seu nome:");
                Nome = Console.ReadLine();

                Console.WriteLine("\nInforme o seu sobrenome:");
                Sobrenome = Console.ReadLine();

                Console.WriteLine("\nInforme a sua data de nascimento:");
                Nascimento = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine($"Os dados abaixo estão corretos?\nNome: {Nome}\nSobrenome: {Sobrenome}\nData de nascimento: {Nascimento}\nDias restantes para o próximo aniversário: {tempo()}");
                Console.WriteLine("1 - Sim\n2 - Não");
                int caso = Convert.ToInt32(Console.ReadLine());

                Pessoa pessoa = new Pessoa()
                {
                    Nome = Nome,
                    Sobrenome = Sobrenome,
                    Nascimento = Nascimento
                };
                if (caso == 1)
                {
                    Console.WriteLine("Caso 1 escolhido");
                    myList.Add(pessoa);
                    TextWriter tw = new StreamWriter("MeuArquivo.txt", true);
                    foreach (Pessoa s in myList)
                    {
                        tw.WriteLine(s.Nome +" "+ s.Sobrenome +" "+ s.Nascimento);
                    }
                    tw.Close();
                    myList.Clear();
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Caso 2 escolhido");
                    //faça de novo
                }
            }
        }
        public void buscar()
        {

            int counter = 0;
            string line;
            Console.WriteLine("Digite o nome de um amigo: ");
            var text = Console.ReadLine();

            System.IO.StreamReader file =
                new System.IO.StreamReader("MeuArquivo.txt");

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(text))
                {
                    Console.WriteLine(counter + " - " + line); 
                }
                counter++;
            }
            Console.ReadLine();
            file.Close();


            /* Console.WriteLine("Digite o nome da pessoa: ");
             string pesquisar = Console.ReadLine();
             foreach (Pessoa item in myList)
             {
                 if (item.Nome.Contains(pesquisar))
                 {
                     Console.WriteLine(string.Format("0 - Esses são os dados encontrados: ({0}).", string.Join(", ", item.Nome, item.Sobrenome, item.Nascimento, tempo() + " dias restantes")));
                 }
                 else
                 {
                     Console.WriteLine("0 - ");
                 }
             }
             Console.ReadLine();*/
        }
        public void deletar()
        {
            Console.WriteLine("Digite o nome de uma pessoa para excluir: ");
            var text = Console.ReadLine();
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader("MeuArquivo.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains(text))
                        sw.WriteLine(line);
                }
            }
            Console.WriteLine("\nA pessoa foi excluída!");
            Console.ReadLine();
            File.Delete("MeuArquivo.txt");
            File.Move(tempFile, "MeuArquivo.txt");
        }
        public void editar()
        {
            Console.WriteLine("Digite o nome de uma pessoa: ");
            string A = Console.ReadLine();

            Console.WriteLine("Digite o novo nome: ");
            string A1 = Console.ReadLine();          

            string text = File.ReadAllText("MeuArquivo.txt");
            text = text.Replace(A, A1);
            
            File.WriteAllText("MeuArquivo.txt", text);
        }
        public void aniversarioshoje()
        {
            int counter = 0;
            string line;
            var text = DateTime.Now.ToString("dd/MM");
            System.IO.StreamReader file =
                new System.IO.StreamReader("MeuArquivo.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(text))
                {
                    Console.WriteLine("* - " + counter + " - " + line);
                }

                else
                {
                    Console.WriteLine("* - ");
                }
                counter++;
            }
            Console.ReadLine();
            file.Close();


        }
    }
}
