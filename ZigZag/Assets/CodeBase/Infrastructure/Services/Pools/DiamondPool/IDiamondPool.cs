using CodeBase.Entity.Diamonds;

namespace CodeBase.Infrastructure.Services.Pools.DiamondPool
{
    public interface IDiamondPool
    {
        Diamond AddDiamond();
        void RemoveDiamond(Diamond diamond);
    }
}