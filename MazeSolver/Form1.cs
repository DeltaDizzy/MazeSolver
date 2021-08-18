using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeSolver
{
    public partial class Form1 : Form
    {
        List<MazeNode> nodeMap = new List<MazeNode>();
        PictureBox[] nodeMarkers = new PictureBox[40];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nodeMarkers = this.Controls.OfType<PictureBox>().OrderBy(x => x.Name).ToArray();
            foreach (var item in nodeMarkers)
            {
                nodeMap.Add(new MazeNode(new Vector2(item.Location.X, item.Location.Y), nodeMarkers.ToList().IndexOf(item)+1));
                
            }

            SetParents();
        }

        public void SetParents()
        {
            nodeMap[0].Parent = null; // pb1

            nodeMap[1].Parent = nodeMap[0]; 
            nodeMap[2].Parent = nodeMap[1]; 
            nodeMap[3].Parent = nodeMap[2]; 
            nodeMap[4].Parent = nodeMap[3]; 

            nodeMap[5].Parent = nodeMap[1]; 
            nodeMap[6].Parent = nodeMap[5]; 
            nodeMap[7].Parent = nodeMap[6];

            nodeMap[9].Parent = nodeMap[7];
            nodeMap[10].Parent = nodeMap[9];
            nodeMap[11].Parent = nodeMap[10];

            nodeMap[8].Parent = nodeMap[7];
            nodeMap[13].Parent = nodeMap[8];
            nodeMap[16].Parent = nodeMap[13];

            //nodeMap[]
            // 17 14 15 18 
        }

        public double GetDistance(Vector2 current, Vector2 goal)
        {
            return Math.Abs(current.X - goal.X) + Math.Abs(current.Y - goal.Y); 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void mazetimer_Tick(object sender, EventArgs e)
        {
            label1.Text = $"{Cursor.Position.X}, {Cursor.Position.Y}";
        }
    }
}
