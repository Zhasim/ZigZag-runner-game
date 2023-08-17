using CodeBase.Entity.Blocks;

namespace CodeBase.Infrastructure.Services.Pool.Pools
{
    public interface IBlocksPool
    { 
        Block RentBlock();
        void ReturnBlock(Block block);
        void Init();
    }
}