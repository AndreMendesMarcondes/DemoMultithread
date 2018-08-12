using DemoMultithread.App.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMultithread.App.Service
{
    public static class AplicacaoComThread
    {
        private static List<Cliente> ListaCliente { get; set; }

        public static string Run(List<Cliente> listaClientes)
        {
            ServiceSimulator service = new ServiceSimulator();

            var relogio = new Stopwatch();
            relogio.Start();

            ListaCliente = listaClientes;
            var listaTask = new List<Task>();
            var listaDeListaDeClientes = new List<List<Cliente>>();
            var totalClientes = ListaCliente.Count();

            var numeroTasks = VerificarNumeroTasks(totalClientes);

            Task.Run(async () =>
            {
                for (int i = 0; i < numeroTasks; i++)
                    listaDeListaDeClientes.Add(RetornarListaClienteFragmentada(totalClientes, numeroTasks, i));

                foreach (var item in listaDeListaDeClientes)
                    listaTask.Add(Task.Factory.StartNew(() => ValidarCPF(item, service)));

                await Task.WhenAll(listaTask.ToArray());

            }).Wait();

            relogio.Stop();

            return $"Com Thread. A aplicação levou {relogio.ElapsedMilliseconds / 1000} segundos para terminar.";
        }

        //Quebramos a minha lista de Clientes completa em fragmentos para poder chamar o servico
        private static List<Cliente> RetornarListaClienteFragmentada(int totalLinhas, int numeroTasks, int divisor)
        {
            double fragmentadorListCliente = 1.00 / numeroTasks;

            if (divisor < numeroTasks)
            {
                var listaBulkFramentada = ListaCliente.Take((int)Math.Round(totalLinhas * fragmentadorListCliente)).ToList();
                ListaCliente.RemoveRange(0, (int)Math.Round(totalLinhas * fragmentadorListCliente));
                return listaBulkFramentada;
            }
            else
                return ListaCliente;
        }

        //Pra cada 10 clientes criaremos uma task
        private static int VerificarNumeroTasks(int tamanhoMailing)
        {
            if (tamanhoMailing <= 5)
                return 1;
            else
                return tamanhoMailing % 5 == 0 ? Convert.ToInt32(tamanhoMailing / 5) : Convert.ToInt32(tamanhoMailing / 5) + 1;
        }

        //Aqui chamaremos o serviço
        private static void ValidarCPF(List<Cliente> listaClientes, ServiceSimulator service)
        {
            foreach (var item in listaClientes)
                item.Valido = service.ValidarCPF(item.CPF);
        }
    }
}
