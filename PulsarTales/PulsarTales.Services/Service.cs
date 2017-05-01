using PulsarTales.Data;

namespace PulsarTales.Services
{
    public abstract class Service
    {
        protected Service()
        {

            this.DbContext = new PulsarTalesContext();
        }
        public PulsarTalesContext DbContext { get; }
    }
}
