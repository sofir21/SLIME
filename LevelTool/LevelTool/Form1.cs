using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LevelTool
{

    public partial class Form1 : Form
    {
        int height;
        int width;
        public List<PictureBox> list = new List<PictureBox>();
        Color color;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            height = 20;
            width = 24;

            for (int x = 0; x < (height * width); x++)
            {
                list.Add(new PictureBox());
            }

            int count = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    list[count].Size = new System.Drawing.Size(15, 15);
                    list[count].Location = new System.Drawing.Point((300 + 15 * j), (50 + 15 * i));

                    //Differenciating between load files with edited picture boxes and new files with default picture boxes
                    if (list[count].BackColor == DefaultBackColor)
                    {
                        list[count].BackColor = EraseButton.BackColor;
                    }

                    list[count].Visible = true;
                    this.Controls.Add(this.list[count]);
                    list[count].Click += new EventHandler(PictureBox_Click);

                    count++;
                }
            }
        }

        private void GroundButton_Click(object sender, EventArgs e)
        {
            color = GroundButton.BackColor;
            DisplayButton.BackColor = GroundButton.BackColor;
            DisplayTileNameTextBox.Text = "Ground";
        }

        private void WallButton_Click(object sender, EventArgs e)
        {
            color = WallButton.BackColor;
            DisplayButton.BackColor = WallButton.BackColor;
            DisplayTileNameTextBox.Text = "Wall";
        }

        private void WaterButton_Click(object sender, EventArgs e)
        {
            color = WaterButton.BackColor;
            DisplayButton.BackColor = WaterButton.BackColor;
            DisplayTileNameTextBox.Text = "Water";
        }

        private void SpikeButton_Click(object sender, EventArgs e)
        {
            color = SpikeButton.BackColor;
            DisplayButton.BackColor = SpikeButton.BackColor;
            DisplayTileNameTextBox.Text = "Spike";
        }

        private void EraseButton_Click(object sender, EventArgs e)
        {
            color = EraseButton.BackColor;
            DisplayButton.BackColor = EraseButton.BackColor;
            DisplayTileNameTextBox.Text = "Erase";
        }
        private void RatButton_Click(object sender, EventArgs e)
        {
            color = RatButton.BackColor;
            DisplayButton.BackColor = RatButton.BackColor;
            DisplayTileNameTextBox.Text = "Rat";
        }
        private void BatButton_Click(object sender, EventArgs e)
        {
            color = BatButton.BackColor;
            DisplayButton.BackColor = BatButton.BackColor;
            DisplayTileNameTextBox.Text = "Bat";
        }

        private void ReverseSpikeButton_Click(object sender, EventArgs e)
        {
            color = ReverseSpikeButton.BackColor;
            DisplayButton.BackColor = ReverseSpikeButton.BackColor;
            DisplayTileNameTextBox.Text = "Reverse Spike";
        }

        private void RespawnButton_Click(object sender, EventArgs e)
        {
            color = RespawnButton.BackColor;
            DisplayButton.BackColor = RespawnButton.BackColor;
            DisplayTileNameTextBox.Text = "Respawn Point";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "Level Files| *.txt";
            sfd.Title = "Save a level file";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream outStream = File.OpenWrite(sfd.FileName);
                StreamWriter output = new StreamWriter(outStream);

                for (int i = 0;  i < list.Count; i++)
                {
                    if (list[i].BackColor == GroundButton.BackColor)
                    {
                        output.WriteLine("ground");
                    }
                    else if (list[i].BackColor == WallButton.BackColor)
                    {
                        output.WriteLine("wall");
                    }
                    else if (list[i].BackColor == WaterButton.BackColor)
                    {
                        output.WriteLine("water");

                    }
                    else if (list[i].BackColor == SpikeButton.BackColor)
                    {
                        output.WriteLine("spike");
                    }
                    else if (list[i].BackColor == EraseButton.BackColor)
                    {
                        output.WriteLine("background");
                    }
                    else if (list[i].BackColor == RatButton.BackColor)
                    {
                        output.WriteLine("rat");
                    }
                    else if (list[i].BackColor == BatButton.BackColor)
                    {
                        output.WriteLine("bat");
                    }
                    else if (list[i].BackColor == ReverseSpikeButton.BackColor)
                    {
                        output.WriteLine("reverseSpike");
                    }
                    else if (list[i].BackColor == RespawnButton.BackColor)
                    {
                        output.WriteLine("respawn");
                    }
                }

                output.Close();

                System.Windows.Forms.MessageBox.Show("File has been succesfully saved", "Save",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("idk man");
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            //Loading an already existing file
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            dialog.RestoreDirectory = true;
            dialog.Title = "Open a Level File";
            dialog.DefaultExt = "Level Files| *.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream inStream = null;
                StreamReader input = null;
                String currentInput;

                inStream = File.OpenRead(dialog.FileName);
                input = new StreamReader(inStream);

                for (int i = 0; i < list.Count; i++)
                {
                    currentInput = input.ReadLine();
                    if (currentInput == "ground")
                    {
                        list[i].BackColor = GroundButton.BackColor;
                    }
                    else if (currentInput == "wall")
                    {
                        list[i].BackColor = WallButton.BackColor;
                    }
                    else if (currentInput == "water")
                    {
                        list[i].BackColor = WaterButton.BackColor;
                    }
                    else if (currentInput == "spike")
                    {
                        list[i].BackColor = SpikeButton.BackColor;
                    }
                    else if (currentInput == "background")
                    {
                        list[i].BackColor = EraseButton.BackColor;
                    }
                    else if (currentInput == "rat")
                    {
                        list[i].BackColor = RatButton.BackColor;
                    }
                    else if (currentInput == "bat")
                    {
                        list[i].BackColor = BatButton.BackColor;
                    }
                    else if (currentInput == "reverseSpike")
                    {
                        list[i].BackColor = ReverseSpikeButton.BackColor;
                    }
                    else if (currentInput == "respawn")
                    {
                        list[i].BackColor = RespawnButton.BackColor;
                    }
                }
                
                inStream.Close();

                System.Windows.Forms.MessageBox.Show("File has been succesfully Loaded", "Load",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void PictureBox_Click(Object sender, System.EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.BackColor = color;
        }
    }
}
