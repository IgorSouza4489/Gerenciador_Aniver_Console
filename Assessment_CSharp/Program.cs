using System;
using Biblioteca.Classes;
using System.IO;
using System.Threading;

namespace Assessment_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Rep obj = new Rep();
            Pessoa obj1 = new Pessoa();
            Console.Beep();
            Console.WriteLine("Aniversários hoje:");
            obj.aniversarioshoje();

            while (true)
            {
                Console.Beep();
                Console.Clear();
                Console.WriteLine("Escolha uma opção:\n1 - Adicionar pessoas\n2 - Pesquisar pessoas\n3 - Deletar pessoas\n4 - Editar pessoas");
                Console.Write("\r\nSelecione uma opção: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Adicionar pessoas \n");
                        obj.inserir();
                        break;

                    case "2":
                        Console.WriteLine("Pesquisar pessoas \n");                      
                        obj.buscar();
                        break;

                    case "3":
                        Console.WriteLine("Deletar pessoas \n");
                        obj.deletar();
                        break;

                    case "4":
                        Console.WriteLine("Editar pessoas \n");
                        obj.editar();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
