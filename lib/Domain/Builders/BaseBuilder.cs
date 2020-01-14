
namespace Gotenberg.Sharp.API.Client.Domain.Builders
{
    public abstract class BaseBuilder<TRequest> where TRequest: class
    {
        protected TRequest Request { get; set; }
    }
    
}