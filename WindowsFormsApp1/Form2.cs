using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public string PlayerName1, PlayerName2;
        private List<Button> _buttons = new List<Button>();
        private int[] _scores = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        private int _player = 1;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitField();

            label1.Text = PlayerName1;
            label1.Font = new Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold);
            label2.Text = PlayerName2;
            
            this.Width = 167;
            this.Height = 290;
        }

        private void InitField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var button = new Button()
                    {
                        Size = new Size(50, 50),
                        Location = new Point(i * 50, j * 50 + 50),
                        TabStop = false,
                        Font = new Font("Arial", 20),
                        Tag = $"{j} {i}"
                    };
                    _buttons.Add(button);
                    button.Click += CellClicked;
                    Controls.Add(button);
                }
            }
        }

        private void CellClicked(object sender, EventArgs eventArgs)
        {
            var button = sender as Button;
            int row = Convert.ToInt32(button.Tag.ToString()[0].ToString()), col = Convert.ToInt32(button.Tag.ToString()[2].ToString());

            button.Text = _player == 1 ? "X" : "0";
            button.Enabled = false;
            var score = _player == 1 ? -1 : 1;
            
            _scores[row] += score;
            _scores[3 + col] += score;
            if (row == col) _scores[2 * 3] += score;
            if (3 - 1 - col == row) _scores[2 * 3 + 1] += score;

            foreach (var item in _scores)
            {
                if (item == 3 || item == -3)
                {
                    foreach (var btn in _buttons)
                    {
                        btn.Enabled = false;
                    }
                    
                    button1.Enabled = true;
                    var name = _player == 1 ? PlayerName1 : PlayerName2;
                    MessageBox.Show($"Игрок: {name} победил!");
                    return;
                }
            }

            _player = _player == 1 ? 2 : 1;
            if (_player == 1)
            {
                label1.Font = new Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold);
                label2.Font = new Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular);
            }
            else
            {
                label1.Font = new Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular);
                label2.Font = new Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            foreach (var btn in _buttons)
            {
                btn.Enabled = true;
            }
            
            _player = _player == 1 ? 2 : 1;
            if (_player == 1)
            {
                label1.Font = new Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold);
                label2.Font = new Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular);
            }
            else
            {
                label1.Font = new Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular);
                label2.Font = new Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold);
            }

            foreach (var btn in _buttons)
            {
                btn.Enabled = true;
                btn.Text = "";
            }

            for (int i = 0; i < 8; i++)
            {
                _scores[i] = 0;
            }
        }
    }
}