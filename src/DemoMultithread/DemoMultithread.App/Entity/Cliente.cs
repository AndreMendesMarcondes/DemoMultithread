using System;

namespace DemoMultithread.App.Entity
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public bool Valido { get; set; }

        public Cliente()
        {
            Id = Guid.NewGuid();
        }
    }
}
