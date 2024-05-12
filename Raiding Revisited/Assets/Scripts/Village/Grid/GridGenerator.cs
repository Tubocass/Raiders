namespace RaidingParty
{
    public class GameGrid
    {
        int width;
        int height;
        LandData[,] grid;
        public LandData[,] Grid {  get { return grid; } }

        public GameGrid(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void GenerateGrid()
        {
            grid = new LandData[width, height];
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    grid[w, h] = new LandData(LandType.Grass);
                }
            }
        }

    }
}
