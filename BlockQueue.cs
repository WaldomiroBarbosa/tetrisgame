using System;

namespace tetrisgame;

public class BlockQueue
{
    private readonly Block[] blocks = new Block[]
    {
        new IBlock(),
        new JBlock(),
        new LBlock(),
        new OBlock()
    }

    private readonly Random rndm = new Random();

    public Block NextBlock { get; private set; }

    public BlockQueue()
    {
        NextBlock = RandomBlock();
    }

    private Block RandomBlock()
    {
        return blocks[rndm.Next(blocks.Length)];
    }

    public Block GetAndUpdate()
    {
        Block block = NextBlock;

        do
        {
            NextBlock = RandomBlock();
        } while (block.ID == NextBlock.ID);

        return block;
    }
}