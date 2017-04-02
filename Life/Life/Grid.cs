using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Life
{
    class Grid
    {
        public Point Size { get; private set; }

        private Cell[,] cells;
        private bool[,] nextCellStates;

        public Grid()
        {
            Size = new Point(LifeMainWindow.CellsX, LifeMainWindow.CellsY);
            cells = new Cell[Size.X, Size.Y];

            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    cells[i, j] = new Cell(new Point(i, j));
                }
            }
        }

        public void Update(GameTime gameTime)
        {

            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    bool living = cells[i, j].IsAlive;
                    int count = GetLivingNeighbors(i, j);
                    bool result = false;

                    //Aply the rules and set the mext state
                    if (living && count < 2)
                        result = false;
                    if (living && (count == 2 || count == 3))
                        result = true;
                    if (living && count > 3)
                        result = false;
                    if (!living && count == 3)
                        result = true;

                    nextCellStates[i, j] = result;
                }
            }

            SetNextState();
        }

        public int GetLivingNeighbors(int x, int y)
        {
            int count = 0;

            //Check on the right
            if (x != Size.X -1)
                if (cells[x + 1, y].IsAlive)
                    count++;

            //Check on the bottom right
            if (x != Size.X - 1 && y != Size.Y - 1)
                if (cells[x + 1, y - 1].IsAlive)
                    count++;

            //Check on the bottom
            if (y != Size.Y - 1)
                if (cells[x, y - 1].IsAlive)
                    count++;

            //Check on the bottom left
            if (x != Size.X - 1 && y != Size.Y - 1)
                if (cells[x - 1, y - 1].IsAlive)
                    count++;

            //Check on the left
            if (x != Size.X - 1)
                if (cells[x - 1, y].IsAlive)
                    count++;

            //Check on the top left
            if (x != Size.X - 1 && y != Size.Y - 1)
                if (cells[x - 1, y + 1].IsAlive)
                    count++;

            //Check on the top
            if (y != Size.Y - 1)
                if (cells[x, y + 1].IsAlive)
                    count++;

            //Check on the top right
            if (x != Size.X - 1 && y != Size.Y - 1)
                if (cells[x + 1, y + 1].IsAlive)
                    count++;

            return count;
        }

        public void SetNextState()
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    cells[i, j].IsAlive = nextCellStates[i, j];
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Cell cell in cells)
            {
                cell.Draw(spriteBatch);
            }

            // Draw vertical gridlines
            for (int i = 0; i < Size.X; i++)
            {
                spriteBatch.Draw(LifeMainWindow.Pixel, new Rectangle(i * LifeMainWindow.CellSize - 1, 0, 1, Size.Y * LifeMainWindow.CellSize), Color.DarkGray);
            }

            // Draw horizontal gridlines
            for (int j = 0; j < Size.Y; j++)
                spriteBatch.Draw(LifeMainWindow.Pixel, new Rectangle(0, j * LifeMainWindow.CellSize - 1, Size.X * LifeMainWindow.CellSize, 1), Color.DarkGray);

        }
    }
}
