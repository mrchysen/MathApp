namespace MathApp.Models;

public class Statistic
{
    public int Count { get; set; } = 0;
    public int RightAnswers { get; set; } = 0;
    public int WrongAnswers { get; set; } = 0;

    public double Percent => (WrongAnswers == 0) ? 0 : (RightAnswers * 1.0d) / WrongAnswers;

    public Statistic() { }

    public Statistic(string filename) 
    {
        if (File.Exists(filename))
        {
            using StreamReader streamReader = new StreamReader(filename);
                var data = streamReader.ReadToEnd().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            
            try
            {
                Count = data[0];
                RightAnswers = data[1];
                WrongAnswers = data[2];
            }
            catch
            {
                // invalid data - delete this file
                File.Delete(filename);
            }
        }
    }

    public void Save(string filename)
    {
        File.WriteAllText(filename, ToString());
    }

    public override string ToString() => string.Join(" ", new List<int>() { Count, RightAnswers, WrongAnswers });
}
