using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle15
{
    public partial class PuzzleArea : Form
    {
        public PuzzleArea()
        {
            InitializeComponent();
            InitializePuzzleArea();
            InitializeBlocks();

        }

        private void InitializePuzzleArea()
        {
            this.BackColor = Color.CornflowerBlue;
            this.Text = "Puzzle15";
            this.ClientSize = new Size(500, 500);
        }

        private void InitializeBlocks()
        {
            int blockCount = 1;
            PuzzleBlock block;
            for(int row = 1; row < 5; row++)
            {

                for (int col = 1; col < 5; col++)
                {
                    block = new PuzzleBlock()
                    {
                        Top = row * 84,
                        Left = col * 84,
                        Text = blockCount.ToString(),
                        Name = "block" + blockCount.ToString()
                };

                  //block.Click += new EventHandler(Block_Click);
                    block.Click += Block_Click;

                    if(blockCount == 16)
                    {
                        block.Name = "EmptyBlock";
                        block.FlatStyle = FlatStyle.Flat;
                        block.Text = string.Empty;
                        block.BackColor = Color.DimGray;
                        block.FlatAppearance.BorderSize = 0;
                    }

                    blockCount++;
                    this.Controls.Add(block);
                }
            }
        }

        private void Block_Click(object sender, EventArgs e)
        {
            Button block = (Button)sender;
            if (IsAdjacent(block))
            {
                SwapBlocks(block);
            }
               
           // MessageBox.Show(block.Name);

        }

        private void SwapBlocks(Button block)
        {
            Button emptyBlock = (Button)this.Controls["EmptyBlock"];
            Point oldLocation = block.Location;
            block.Location = emptyBlock.Location;
            emptyBlock.Location = oldLocation;
        }

        private bool IsAdjacent(Button block)
        {
            double a;
            double b;
            double c;
            Button emptyblock = (Button)this.Controls["EmptyBlock"];

            a = Math.Abs(emptyblock.Top - block.Top);
            b = Math.Abs(emptyblock.Left - block.Left);
            c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            
            if(c < 85)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
