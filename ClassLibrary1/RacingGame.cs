using System;

namespace RacingGameLib
{
    public class RacingGame
    {
        public int Score { get; private set; }
        public int Speed { get; private set; }
        public bool IsGameOver { get; private set; }

        private Random rand = new Random();

        public RacingGame()
        {
            Reset();
        }

        public void Reset()
        {
            Score = 0;
            Speed = 0;
            IsGameOver = false;
        }

        public void Accelerate()
        {
            if (IsGameOver) return;
            Speed += 2;
            if (Speed > 200) Speed = 200;
            Score += 5;
            CheckCrash();
        }

        public void Brake()
        {
            if (IsGameOver) return;
            Speed -= 5;
            if (Speed < 0) Speed = 0;
        }

        public void MoveLeft()
        {
            if (IsGameOver) return;
            Score += 1;
            CheckCrash();
        }

        public void MoveRight()
        {
            if (IsGameOver) return;
            Score += 1;
            CheckCrash();
        }

        private void CheckCrash()
        {
            // 10% nguy cơ va chạm mỗi lần hành động
            if (rand.Next(0, 100) < 10)
            {
                IsGameOver = true;
            }
        }

        public string GetStatus()
        {
            if (IsGameOver)
                return "GAME OVER! Điểm: " + Score;
            else
                return "Tốc độ: " + Speed + " km/h | Điểm: " + Score;
        }
    }
}
