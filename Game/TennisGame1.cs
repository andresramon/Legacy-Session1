namespace TennisKata;

public class TennisGame1 : ITennisGame
{

    enum GamePoints
    {
        Zero = 0,
        Fifteen = 1,
        Thirty = 2,
        Forty = 3,
        Advantage = 4,
    }
    
        private GamePoints m_score1 = GamePoints.Zero;
        private GamePoints m_score2 = GamePoints.Zero;
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
        private string _player2 = "player2";

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1)
                m_score1 += 1;
            else if (playerName == _player2)
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            GamePoints tempScore = GamePoints.Zero;
            if (m_score1 == m_score2)
            {
                switch (m_score1)
                {
                    case GamePoints.Zero:
                        score = _loveAll;
                        break;
                    case GamePoints.Fifteen:
                        score = _fifteenAll;
                        break;
                    case GamePoints.Thirty:
                        score = _thirtyAll;
                        break;
                    default:
                        score = _deuce;
                        break;

                }
            }
            else if (m_score1 >= GamePoints.Advantage || m_score2 >= GamePoints.Advantage)
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
                        case GamePoints.Zero:
                            score += _score;
                            break;
                        case GamePoints.Fifteen:
                            score += _fifteen;
                            break;
                        case GamePoints.Thirty:
                            score += _thirty;
                            break;
                        case GamePoints.Forty:
                            score += _forty;
                            break;
                    }
                }
            }
            return score;
        }
}