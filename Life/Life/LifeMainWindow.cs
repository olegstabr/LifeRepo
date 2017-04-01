using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Life
{
    public partial class LifeMainWindow : Microsoft.Xna.Framework.Game
    {
        public static Vector2 ScreenSize;

        public const int CellSize = 10; // Cell pixel width/height
        public const int CellsX = 100;
        public const int CellsY = 50;

        public static Texture2D Pixel;

        private GraphicsDeviceManager graphics;

        public LifeMainWindow()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            ScreenSize = new Vector2(CellsX, CellsY) * CellSize;

            graphics.PreferredBackBufferWidth = (int)ScreenSize.X;
            graphics.PreferredBackBufferHeight = (int)ScreenSize.Y;


            InitializeComponent();
        }
    }
}
