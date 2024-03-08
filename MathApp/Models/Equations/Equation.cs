namespace MathApp.Models.Equations;

public abstract class Equation
{
    public virtual string Text { get; }
    public virtual int Answer { get; }
}
