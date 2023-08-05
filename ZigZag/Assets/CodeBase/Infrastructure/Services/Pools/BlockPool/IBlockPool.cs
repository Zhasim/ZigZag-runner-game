using CodeBase.Entity;

namespace CodeBase.Infrastructure.Services.Pools.BlockPool
{
    public interface IBlockPool
    {
        Block AddBlock();
        void RemoveBlock(Block block);
    }
}