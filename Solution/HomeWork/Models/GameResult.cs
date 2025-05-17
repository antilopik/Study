namespace HomeWork.Models
{
    public sealed class GameResult
    {
        public string Player { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool IsGameLost { get; set; }

        public static GameResult Parse(string line)
        {
            var result = new GameResult();
            var data = line.Split(',');
            result.Player = data[0];
            result.Date = DateTime.Parse(data[1]);
            result.IsGameLost = bool.Parse(data[2]);
            return result;
        }

        public override string ToString() 
        {
            return Player + "," + Date + "," + IsGameLost;
        }
    }
}
