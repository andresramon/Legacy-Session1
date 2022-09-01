namespace TennisKata;

public class TennisGame1 : ITennisGame
{
     private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;
       
        private string _player1 = "player1";
        private string _loveAll = "Love-All";
        private string _fifteenAll = "Fifteen-All";
        private string _thirtyAll = "Thirty-All";
        private string _deuce = "Deuce";
        private string _advantagePlayer1 = "Advantage player1";
        private string _advantagePlayer2 = "Advantage player2";
        private string _winForPlayer1 = "Win for player1";
        private string _winForPlayer2 = "Win for player2";
        private string _score = "Love";
        private string _fifteen = "Fifteen";
        private string _thirty = "Thirty";
        private string _forty = "Forty";

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1)
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (m_score1 == m_score2)
            {
                switch (m_score1)
                {
                    case 0:
                        score = _loveAll;
                        break;
                    case 1:
                        score = _fifteenAll;
                        break;
                    case 2:
                        score = _thirtyAll;
                        break;
                    default:
                        score = _deuce;
                        break;

                }
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = _advantagePlayer1;
                else if (minusResult == -1) score = _advantagePlayer2;
                else if (minusResult >= 2) score = _winForPlayer1;
                else score = _winForPlayer2;
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += _score;
                            break;
                        case 1:
                            score += _fifteen;
                            break;
                        case 2:
                            score += _thirty;
                            break;
                        case 3:
                            score += _forty;
                            break;
                    }
                }
            }
            return score;
        }
}