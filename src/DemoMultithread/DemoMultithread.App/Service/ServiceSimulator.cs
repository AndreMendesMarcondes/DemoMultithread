using System.Threading;

namespace DemoMultithread.App.Service
{
    public class ServiceSimulator
    {
        public bool ValidarCPF(string cpf)
        {
            Thread.Sleep(500);
            return true;
        }
    }
}
