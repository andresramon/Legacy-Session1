namespace TennisKata;

  public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;
        
        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
           
            if (WinPlayer(p1point, p2point))
            {
                return "Win for player1";
            }
            if (WinPlayer(p2point, p1point))
            {
                return "Win for player2";
            }
            if (AdvantagePlayer(p1point, p2point))
            {
                return "Advantage player1";
            }

            if (AdvantagePlayer(p2point, p1point))
            {
                return "Advantage player2";
            }
            if (EqualsScore(p1point, p2point))
            {
                if (p1point < 3)
                {
                    return String.Concat(TranslateScore(p1point), "-All") ;    
                }

                if (p1point > 2)
                {
                    return "Deuce";
                }
                
            }
           
            p1res = TranslateScore(p1point);
            p2res = TranslateScore(p2point);
            return String.Concat(p1res, "-", p2res);
            
        }

        private bool EqualsScore(int point1, int point2)
        {
            return point1 == point2;
        }
        private bool AdvantagePlayer(int point1, int point2)
        {
            return point1 > point2 && point2 >= 3;
        }

        private bool WinPlayer(int point1, int point2)
        {
            return point1 >= 4 && point2 >= 0 && (point1 - point2) >= 2;
        }

        private string TranslateScore(int point)
        {
            IDictionary<int, string> dictScores = new Dictionary<int, string>() { {0, "Love"}, {1, "Fifteen"}, {2, "Thirty"}, {3, "Forty"} };
            return dictScores[point];
        }
        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }