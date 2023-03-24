using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoLinqAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CÓDIGO (OBTENÇÃO DE TODA A INFORMAÇÃO PRESENTE NUMA 
            Exemplo1();

            //CÓDIGO(OBTENÇÃO DA ORDENAÇÃO DA LISTAGEM)
            Exemplo2();

            //CÓDIGO (OBTENÇÃO DA CONTAGEM DE REGISTOS)
            Exemplo3();

            //CÓDIGO (OBTENÇÃO DA LISTAGEM COM APLICAÇÃO DE CRITÉRIOS)
            Exemplo4();

            //CÓDIGO (OBTENÇÃO DA LISTAGEM COM PESQUISA DE INFORMAÇÃO NO INÍCIO DA CADEIA)
            Exemplo5();

            //CÓDIGO (OBTENÇÃO DA LISTAGEM COM PESQUISA DE INFORMAÇÃO EM QUALQUER PARTE DA CADEIA)
            Exemplo6();

            //CÓDIGO (OBTENÇÃO DA LISTAGEM COM AGRUPAMENTO DA INFORMAÇÃO)
            Exemplo7();

            //CÓDIGO (OBTENÇÃO DA LISTAGEM COM APLICAÇÃO DE CRITÉRIOS EM DADOS AGRUPADOS)
            Exemplo8();

            //CÓDIGO (OBTENÇÃO DA LISTAGEM COM JUNÇÃO ENTRE TABELAS)
            Exemplo9();

            //CÓDIGO (INSERÇÃO DE REGISTOS)
            Exemplo10();

            //CÓDIGO (ALTERAÇÃO DE REGISTOS)
            Exemplo11();

            //CÓDIGO (ELIMINAÇÃO DE REGISTOS)
            Exemplo12();

        }

        private static void Exemplo12()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            Funcionario func = new Funcionario();
            var pesquisa = from Funcionarios in dc.Funcionarios
                           where Funcionarios.ID == 4
                           select Funcionarios;
            func = pesquisa.Single();
            dc.Funcionarios.DeleteOnSubmit(func);
            dc.SubmitChanges();
            //Obtenção da listagem
            var lista = from Funcionarios in dc.Funcionarios select Funcionarios;
            foreach (Funcionario funcLista in lista)
            {
                Console.WriteLine("ID: " + funcLista.ID);
                Console.WriteLine("Nome: " + funcLista.Nome);
                Console.WriteLine("Departamento: " + funcLista.Departamento);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private static void Exemplo11()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            Funcionario func = new Funcionario();
            var pesquisa = from Funcionarios in dc.Funcionarios
                           where Funcionarios.ID == 4
                           select Funcionarios;
            func = pesquisa.Single();
            func.Departamento = "RH";
            dc.SubmitChanges();
            //Obtentenção da listagem
            var lista = from Funcionarios in dc.Funcionarios
                        select Funcionarios;
            foreach (Funcionario funcLista in lista)
            {
                Console.WriteLine("ID: " + funcLista.ID);
                Console.WriteLine("Nome: " + funcLista.Nome);
                Console.WriteLine("Departamento: " + funcLista.Departamento);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private static void Exemplo10()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(); Funcionario func = new Funcionario();
            func.Nome = "Carlos Pereira";
            func.Departamento = "DF";
            dc.Funcionarios.InsertOnSubmit(func);
            dc.SubmitChanges();
            //Obtenção da listagem 
            var lista = from Funcionarios in dc.Funcionarios select Funcionarios; foreach (Funcionario funcLista in lista)
            {
                Console.WriteLine("ID: " + funcLista.ID);
                Console.WriteLine("Nome: " + funcLista.Nome);
                Console.WriteLine("Departamento: " + funcLista.Departamento); Console.WriteLine();
            }
            Console.ReadLine();
        }

        private static void Exemplo9()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Funcionarios in dc.Funcionarios
                        join Departamentos in dc.Departamentos
                        on Funcionarios.Departamento equals Departamentos.Sigla
                        select new
                        {
                            Funcionarios.ID,
                            Funcionarios.Nome,
                            Departamentos.Departamento1
                        };
            foreach (var c in lista)
            {
                Console.WriteLine("ID: " + c.ID);
                Console.WriteLine("Nome: " + c.Nome);
                Console.WriteLine("Departamento: " + c.Departamento1);
            }
            Console.ReadLine();
        }

        private static void Exemplo8()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Funcionarios in dc.Funcionarios
                        group Funcionarios by Funcionarios.Departamento into c
                        where c.Count() > 3
                        select new
                        {
                            Departamento = c.Key,
                            Contagem = c.Count()
                        };
            foreach (var c in lista)
            {
                Console.WriteLine(c.Departamento + " (" + c.Contagem + ") ");
            }
            Console.ReadLine();
        }

        private static void Exemplo7()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Funcionarios in dc.Funcionarios
                        group Funcionarios by Funcionarios.Departamento into c
                        select new
                        {
                            Departamento = c.Key,
                            Contagem = c.Count()
                        };
            foreach (var c in lista)
            {
                Console.WriteLine(c.Departamento + " (" + c.Contagem + ") ");
            }
            Console.ReadLine();
        }

        private static void Exemplo6()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Funcionarios in dc.Funcionarios
                        where Funcionarios.Nome.Contains("ana")
                        select Funcionarios;
            foreach (Funcionario func in lista)
            {
                Console.WriteLine("ID: " + func.ID);
                Console.WriteLine("Nome: " + func.Nome);
                Console.WriteLine("Departamento: " + func.Departamento);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private static void Exemplo5()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Funcionarios in dc.Funcionarios where Funcionarios.Nome.StartsWith("Jo") select Funcionarios;
            foreach (Funcionario func in lista)
            {
                Console.WriteLine("ID: " + func.ID);
                Console.WriteLine("Nome: " + func.Nome);
                Console.WriteLine("Departamento: " + func.Departamento);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private static void Exemplo4()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Funcionarios in dc.Funcionarios where Funcionarios.Departamento == "DF" select Funcionarios;
            foreach (Funcionario func in lista)
            {
                Console.WriteLine("ID: " + func.ID);
                Console.WriteLine("Nome: " + func.Nome);
                Console.WriteLine("Departamento: " + func.Departamento);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private static void Exemplo3()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Funcionarios in dc.Funcionarios select Funcionarios;
            Console.WriteLine("Total de registos: " + lista.Count());
            Console.ReadLine();
        }

        private static void Exemplo2()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Funcionarios in dc.Funcionarios orderby Funcionarios.Nome select Funcionarios;
            foreach (Funcionario func in lista)
            {
                Console.WriteLine("ID: " + func.ID);
                Console.WriteLine("Nome: " + func.Nome);
                Console.WriteLine("Departamento: " + func.Departamento);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private static void Exemplo1()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Funcionarios in dc.Funcionarios select Funcionarios;
            foreach (Funcionario func in lista)
            {
                Console.WriteLine("ID: " + func.ID);
                Console.WriteLine("Nome: " + func.Nome);
                Console.WriteLine("Departamento: " + func.Departamento);
                Console.WriteLine();

            }
            Console.ReadLine();
        }
    }
}
