using DemoMultithread.App.Service;
using System;
using System.Threading.Tasks;

namespace DemoMultithread.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaClientes = ClienteService.RetornarListaDeClientes();

            //Aplicação sem utilizar threads
            var programaSemThread = AplicacaoSemThread.Run(listaClientes);
            Console.WriteLine(programaSemThread);
            Console.ReadKey();

            //Aplicação utilizando threads
            var programaComThread = AplicacaoComThread.Run(listaClientes);
            Console.WriteLine(programaComThread);
            Console.ReadKey();
        }
    }
}
