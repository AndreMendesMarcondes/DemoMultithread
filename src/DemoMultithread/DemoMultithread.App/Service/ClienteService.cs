using DemoMultithread.App.Entity;
using System.Collections.Generic;

namespace DemoMultithread.App.Service
{
    public static class ClienteService
    {
        public static List<Cliente> RetornarListaDeClientes()
        {
            var lista = new List<Cliente>();

            for (int i = 0; i < 60; i++)
            {
                lista.Add(new Cliente()
                {
                    CPF = "000.000.000-00",
                    Nome = $"Cliente {i}",
                    Valido = false
                });
            }

            return lista;
        }
    }
}
