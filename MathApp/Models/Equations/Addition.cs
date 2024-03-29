﻿namespace MathApp.Models.Equations;

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

    public Addition(int dif, Func<double,int> difFunc)
    {
        Random rnd = new Random();

        Summand1 = (int)rnd.Next(1 + dif, difFunc(dif));
        Summand1 = (int)rnd.Next(1 + dif, difFunc(dif));
    }
}

