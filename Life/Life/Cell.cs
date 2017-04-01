using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace Life
{    
    class Cell
    {
        public Point Position { get; private set; }
        public Rectangle Bounds { get; private set; }

        public bool IsAlive { get; set; }

        public Cell(Point position)
        {
            Position = position;
            Bounds = new Rectangle(Position.X * LifeMainWindow.CellSize, Position.Y * LifeMainWindow.CellSize, LifeMainWindow.CellSize, LifeMainWindow.CellSize);
            IsAlive = false;
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
                spriteBatch.Draw(LifeMainWindow.Pixel, Bounds, Color.Black);
        }
    }
}
