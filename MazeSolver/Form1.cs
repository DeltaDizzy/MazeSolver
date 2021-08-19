using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<PictureBox> nodeMarkers = new List<PictureBox>();
        Stack<MazeNode> path = new Stack<MazeNode>();
        Queue<MazeNode> nextPoint = new Queue<MazeNode>();
        Stopwatch timer = new Stopwatch();
        MazeNode target;
        Vector2 playerpos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nodeMarkers = this.Controls.OfType<PictureBox>().OrderBy(x => x.Name).ToList();
            foreach (var item in nodeMarkers)
            {
                nodeMap.Add(new MazeNode(new Vector2(item.Location.X, item.Location.Y), nodeMarkers.ToList().IndexOf(item)));
            }

            SetParents();
            target = nodeMap[0];
            //MessageBox.Show(nodeMap[6].ID.ToString());
        }

        public void SetParents()
        {
            nodeMap[0].Parent = null; 

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
            nodeMap[12].Parent = nodeMap[8];
            nodeMap[13].Parent = nodeMap[12];
            nodeMap[14].Parent = nodeMap[13];
            nodeMap[15].Parent = nodeMap[14];
            nodeMap[16].Parent = nodeMap[15];
            nodeMap[17].Parent = nodeMap[16];

            nodeMap[18].Parent = nodeMap[15];
            nodeMap[19].Parent = nodeMap[18];
            nodeMap[20].Parent = nodeMap[19];
            nodeMap[21].Parent = nodeMap[20];

            nodeMap[22].Parent = nodeMap[18];
            nodeMap[23].Parent = nodeMap[22];
            nodeMap[24].Parent = nodeMap[23];
            nodeMap[25].Parent = nodeMap[24];
            nodeMap[26].Parent = nodeMap[25];
            nodeMap[27].Parent = nodeMap[26];
            nodeMap[28].Parent = nodeMap[27];
            nodeMap[29].Parent = nodeMap[28];
            nodeMap[30].Parent = nodeMap[29];

            nodeMap[31].Parent = nodeMap[27];
            nodeMap[32].Parent = nodeMap[31];
            nodeMap[33].Parent = nodeMap[32];
            nodeMap[34].Parent = nodeMap[33];
            nodeMap[35].Parent = nodeMap[34];
            nodeMap[36].Parent = nodeMap[35];
            nodeMap[37].Parent = nodeMap[36];

            nodeMap[38].Parent = nodeMap[35];
            nodeMap[39].Parent = nodeMap[38];
            nodeMap[40].Parent = nodeMap[39];

            nodeMap[41].Parent = nodeMap[39];
            //nodeMap[42].Parent = nodeMap[41];
        }

        public void TracePath(List<MazeNode> graph)
        {
            MazeNode current = graph.Find(n => n.ID == 41);
            while (current.ID != 0)
            {
                path.Push(current);
                current = current.Parent;
            }
            if (current.ID == 0)
            {
                //MessageBox.Show("PATH TRACED");
            }
            
            while(path.Count > 0)
            {
                nextPoint.Enqueue(path.Pop());
            }
            
            //foreach (MazeNode item in path)
            //{
            //    nextPoint.Enqueue(item);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TracePath(nodeMap);
            mazetimer.Enabled = true;
            
        }
        bool closeENough = false;
        private void SelectWayPoint()
        {
            playerpos = new Vector2(pnlPlayer.Location.X, pnlPlayer.Location.Y);
            float nextPointDistance = Vector2.Distance(playerpos, target.Position);
            // find closest picturebox
            // are we intersecting it?
            //if so dequeue
            //PictureBox pointbox = nodeMarkers.Find(p => p.)
            if (nextPointDistance < 10f)
            {
                /*try
                {
                    if (nextPoint.Count != 0)
                    {
                        nextPoint.Dequeue();
                        target = nextPoint.Peek();
                    }
                    else
                    {
                        target = nodeMap[41];
                    }
                }
                catch (Exception e)
                {

                    
                }*/
            }
            label1.Text = $"Target is {target.ID}, Playerpos is ({playerpos.X}, {playerpos.Y})";
        }
        private void mazetimer_Tick(object sender, EventArgs e)
        {
            SelectWayPoint();
            // what direction is it
            /*if (target.Position.X < playerpos.X)
            {
                pnlPlayer.Left -= 1;
            }
            if (target.Position.X > playerpos.X)
            {
                pnlPlayer.Left += 1;
            }
            if (target.Position.Y < playerpos.Y)
            {
                pnlPlayer.Top -= 1;

            }
            if (target.Position.Y > playerpos.Y)
            {
                pnlPlayer.Top += 1;
            }*/
            pnlPlayer.Location = new Point((int)target.Position.X, (int)target.Position.Y);

            //jump = Vector2.Multiply(0.5f, jump);
            //if (jump.Length() < 0.1f)
            //{
            //    nextPoint.Dequeue();
            //    return;
            //}
            //MOVE BY THE SLOPE
            //playerpos += jump;
        }
    }
}
