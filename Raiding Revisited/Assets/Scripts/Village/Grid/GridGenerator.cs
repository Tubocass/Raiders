namespace RaidingParty
{
    public class GridGenerator
    {
        public int width;
        public int length;
        CellData[,] grid;
        public CellData[,] Grid {  get { return grid; } }

        public GridGenerator(int width, int length)
        {
            this.width = width;
            this.length = length;
        }

        public void GenerateGrid()
        {
            grid = new CellData[width, length];
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {
                    grid[w, l] = new CellData(CellData.LandType.Grass);
                }
            }
        }
    }
}
