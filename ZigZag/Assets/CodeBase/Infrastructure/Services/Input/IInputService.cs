using CodeBase.DI;

namespace CodeBase.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        bool GetInputDown();
    }
}