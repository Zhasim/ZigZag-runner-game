using CodeBase.Entity.Diamonds;

namespace CodeBase.Infrastructure.Services.Pool.Pools
{
    public interface IDiamondsPool
    {
        Diamond RentDiamond();
        void ReturnDiamond(Diamond diamond);
        void Init();
    }
}