namespace MathApp.Models.Equations;

public class Addition : Equation
{
    protected int Summand1;
    protected int Summand2;

    public override string Text => $"{Summand1} + {Summand2}";

    public override int Answer => Summand1 + Summand2;

    public Addition(int summand1, int summand2)
    {
        Summand1 = summand1;
        Summand2 = summand2;
    }
}
