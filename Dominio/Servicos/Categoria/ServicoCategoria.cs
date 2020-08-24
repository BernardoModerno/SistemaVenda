using Dominio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Servicos
{
    public class ServicoCategoria : IServicoCategoria
    {
        public void Cadastrar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria CarregarRegistro(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> Listagem()
        {
            List<Categoria> lista = new List<Categoria>();
            Categoria item = new Categoria()
            {
                Codigo = 1,
                Descricao = "Teste"
            };
            lista.Add(item);

            return lista;
        }
    }
}
