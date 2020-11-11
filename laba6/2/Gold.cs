using System;
using System.Collections.Generic;
using System.Text;

public class Gold : Book
{
    public Gold(string author, string title, decimal price)
    : base(author, title, price)
    {
    }

    public override decimal Price
    {
        get
        {
            return base.Price * 1.3m;
        }
    }
}