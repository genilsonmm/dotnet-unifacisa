using AppLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLivros.Dados
{
    public class BancoDeDados
    {
        private static List<Livro> livros;

        private static BancoDeDados instance;

        public static BancoDeDados Instance()
        {
            if (instance == null)
            {
                livros = new List<Livro>();
                instance = new BancoDeDados();
            }

            return instance;
        }

        public void Add(Livro livro)
        {
            livros.Add(livro);
        }

        public List<Livro> GetAll()
        {
            return livros;
        }
    }
}
