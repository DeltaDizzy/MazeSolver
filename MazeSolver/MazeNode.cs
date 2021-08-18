using System;
using System.Numerics;

namespace MazeSolver
{
    public partial class MazeNode
    {
        public MazeNode(Vector2 position, int id)
        {
            Position = position;
            ID = id;
        }
        public int ID { get; set; }
        public Vector2 Position { get; set; }
        public MazeNode Parent { get; set; } // Tile we visited before this
    }
}
