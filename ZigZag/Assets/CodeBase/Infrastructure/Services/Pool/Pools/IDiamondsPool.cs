using CodeBase.Data.GameLoopData;
using CodeBase.Entity.Diamonds;

namespace CodeBase.Infrastructure.Services.Pool.Pools
{
    public interface IDiamondsPool
    {
        void Init(WorldData worldData);
        Diamond RentDiamond();
        void ReturnDiamond(Diamond diamond);
    }
}