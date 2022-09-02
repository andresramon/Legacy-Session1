namespace TennisKata;

public class TennisGame1 : ITennisGame
{

    enum GamePoints
    {
        Love = 0,
        Fifteen = 1,
        Thirty = 2,
        Forty = 3,
        Advantage = 4,
    }

    enum CompareScores
    {
        Even = 0,
        Advantage =1,
        Other = 2
    }

    enum AdvantagePoints
    {
        AdvantagePlayerOne = 1,
        WinPlayerOne =2,
        AdvantagePlayerTwo = -1,
        WinPlayerTwo =-2,
    }
        private GamePoints m_score1 = GamePoints.Love;
        private GamePoints m_score2 = GamePoints.Love;
        private readonly string player1Name;
        private readonly string player2Name;
       
        private readonly string _player1 = "player1";
        private readonly string _loveAll = "Love-All";
        private readonly string _fifteenAll = "Fifteen-All";
        private readonly string _thirtyAll = "Thirty-All";
        private readonly string _deuce = "Deuce";
        private readonly string _advantagePlayer1 = "Advantage player1";
        private readonly string _advantagePlayer2 = "Advantage player2";
        private readonly string _winForPlayer1 = "Win for player1";
        private readonly string _winForPlayer2 = "Win for player2";
        private readonly string _score = "Love";
        private readonly string _fifteen = "Fifteen";
        private readonly string _thirty = "Thirty";
        private readonly string _forty = "Forty";
        private readonly string _player2 = "player2";

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1)
            {
                m_score1 += 1;
            }
            else if (playerName == _player2)
            {
                m_score2 += 1;
            }
        }

        public string GetScore()
        {

            var scoreComparison = GetScoreComparation(m_score1,m_score2);
        
            if (scoreComparison == CompareScores.Even)
            {
                return  GetEvenScore();
            }
            
            if (scoreComparison == CompareScores.Advantage)
            {
                return GetAdvantageScore();
            }
            
            return  GetOtherScore();
        }

        private string GetOtherScore()
        {
            return String.Concat(m_score1, "-",m_score2);
        }

        private string GetAdvantageScore()
        {
            
            AdvantagePoints minusResult =  (AdvantagePoints) (m_score1 - m_score2) ;
          
            if (minusResult == AdvantagePoints.AdvantagePlayerOne)
            {
                return _advantagePlayer1;
            }
            if (minusResult == AdvantagePoints.AdvantagePlayerTwo )
            {
                return _advantagePlayer2;
            }
            if (minusResult >= AdvantagePoints.WinPlayerOne)
            {
                return _winForPlayer1;
            }
            return _winForPlayer2;
            
        }

        private CompareScores GetScoreComparation(GamePoints mScore1, GamePoints mScore2)
        {
            if (m_score1 == m_score2)
            {
                return CompareScores.Even;
            }
            
            if (m_score1 >= GamePoints.Advantage || m_score2 >= GamePoints.Advantage)
            {
                return CompareScores.Advantage;
            }
            return CompareScores.Other;
        }

        private string GetEvenScore()
        {
            string score;
            switch (m_score1)
            {
                case GamePoints.Love:
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

            return score;
        }
}