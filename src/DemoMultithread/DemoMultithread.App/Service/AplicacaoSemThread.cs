using DemoMultithread.App.Entity;
using System.Collections.Generic;
using System.Diagnostics;

namespace DemoMultithread.App.Service
{
    public static class AplicacaoSemThread
    {
        public static string Run(List<Cliente> listaClientes)
        {
            ServiceSimulator service = new ServiceSimulator();

            var relogio = new Stopwatch();
            relogio.Start();

            foreach (var item in listaClientes)
                item.Valido = service.ValidarCPF(item.CPF);

            relogio.Stop();

            return $"Sem thread. A aplicação levou {relogio.ElapsedMilliseconds / 1000} segundos para terminar.";
        }
    }
}
