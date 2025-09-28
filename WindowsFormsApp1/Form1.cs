using System;
using System.Drawing;
using System.Windows.Forms;
using RacingGameLib;

namespace RacingGameWinForm
{
    public class Form1 : Form
    {
        private RacingGame game;
        private Label lblStatus;
        private Button btnAccelerate, btnBrake, btnLeft, btnRight, btnReset;

        public Form1()
        {
            // Khởi tạo game
            game = new RacingGame();

            // Cấu hình Form
            this.Text = "Game Đua Xe (WinForms)";
            this.Size = new Size(420, 260);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label trạng thái
            lblStatus = new Label();
            lblStatus.Location = new Point(20, 20);
            lblStatus.Size = new Size(360, 30);
            lblStatus.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.Controls.Add(lblStatus);

            // Nút Tăng tốc
            btnAccelerate = new Button();
            btnAccelerate.Text = "Tăng tốc (W)";
            btnAccelerate.Location = new Point(20, 70);
            btnAccelerate.Size = new Size(100, 40);
            btnAccelerate.Click += (s, e) => { game.Accelerate(); UpdateStatus(); };
            this.Controls.Add(btnAccelerate);

            // Nút Phanh
            btnBrake = new Button();
            btnBrake.Text = "Phanh (S)";
            btnBrake.Location = new Point(140, 70);
            btnBrake.Size = new Size(100, 40);
            btnBrake.Click += (s, e) => { game.Brake(); UpdateStatus(); };
            this.Controls.Add(btnBrake);

            // Nút Trái
            btnLeft = new Button();
            btnLeft.Text = "Trái (A)";
            btnLeft.Location = new Point(20, 130);
            btnLeft.Size = new Size(100, 40);
            btnLeft.Click += (s, e) => { game.MoveLeft(); UpdateStatus(); };
            this.Controls.Add(btnLeft);

            // Nút Phải
            btnRight = new Button();
            btnRight.Text = "Phải (D)";
            btnRight.Location = new Point(140, 130);
            btnRight.Size = new Size(100, 40);
            btnRight.Click += (s, e) => { game.MoveRight(); UpdateStatus(); };
            this.Controls.Add(btnRight);

            // Nút Chơi lại
            btnReset = new Button();
            btnReset.Text = "Chơi lại";
            btnReset.Location = new Point(260, 70);
            btnReset.Size = new Size(100, 100);
            btnReset.Click += (s, e) => { game.Reset(); UpdateStatus(); };
            this.Controls.Add(btnReset);

            // Bắt phím
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            // Trạng thái ban đầu
            UpdateStatus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (game.IsGameOver) return;

            if (e.KeyCode == Keys.W) game.Accelerate();
            else if (e.KeyCode == Keys.S) game.Brake();
            else if (e.KeyCode == Keys.A) game.MoveLeft();
            else if (e.KeyCode == Keys.D) game.MoveRight();

            UpdateStatus();
        }

        private void UpdateStatus()
        {
            lblStatus.Text = game.GetStatus();
            if (game.IsGameOver)
            {
                MessageBox.Show("Bạn đã thua! Điểm: " + game.Score, "Game Over");
            }
        }
    }
}
