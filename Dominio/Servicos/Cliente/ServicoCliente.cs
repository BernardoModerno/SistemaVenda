﻿using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemaVenda.Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        IRepositorioCliente RepositorioCliente;
        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            RepositorioCliente = repositorioCliente;
        }
        public void Cadastrar(Cliente cliente)
        {
            RepositorioCliente.Create(cliente);
        }

        public Cliente CarregarRegistro(int id)
        {
            return RepositorioCliente.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioCliente.Delete(id);
        }

        public IEnumerable<Cliente> Listagem()
        {
            return RepositorioCliente.Read();
        }
    }
}
