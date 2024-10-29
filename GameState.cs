namespace tetrisgame;

public class GameState
{
    private Block currentBlock;

    public Block CurrentBlock
    {
        get => currentBlock;
        private set
        {
            currentBlock = value;
            currentBlock.Reset();
        }
    }

    public GameGrid GameGridInstance { get; }
    public BlockQueue BlockQueueInstance { get; }
    public bool GameOver { get; private set; }

    public GameState ()
    {
        GameGridInstance = new GameGrid(22, 10);
        BlockQueueInstance = new BlockQueue();
        CurrentBlock = BlockQueueInstance.GetAndUpdate();
    }

    private bool BlockFits()
    {
        foreach (Position p in CurrentBlock.TilePositions())
        {
            if (!GameGridInstance.EmptyCellCheck(p.Row, p.Column))
            {
                return false;
            }
        }

        return true;
    }

    public void RotateBlockCW()
    {
        CurrentBlock.RotateCW();

        if(!BlockFits())
        {
            CurrentBlock.RotateCCW();
        }
    }

    public void RotateBlockCCW()
    {
        CurrentBlock.RotateCCW();

        if(!BlockFits())
        {
            CurrentBlock.RotateCW();
        }
    }

    public void MoveBlockLeft()
    {
        CurrentBlock.Move(0, -1);

        if (!BlockFits())
        {
            CurrentBlock.Move(0, 1);
        }
    }

    public void MoveBlockRight()
    {
        CurrentBlock.Move(0, 1);

        if (!BlockFits())
        {
            CurrentBlock.Move(0, -1);
        }
    }

    private bool IsGameOver()
    {
        return GameGridInstance;
    }
}