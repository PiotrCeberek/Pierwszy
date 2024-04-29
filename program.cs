using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Punkt p1 = new Punkt(0, 0), p2 = new Punkt(1, 1);
        Linia l1 = new Linia(p1, p2), l2 = new Linia(p1, p2);
        l1.przesun(5, 5);
        Console.WriteLine(l1);
        Console.WriteLine(l2);
        Console.WriteLine('\n');

        Punkt p3 = new Punkt(5, 5);
        Punkt p4 = new Punkt(6, 6);
        Console.WriteLine(p1.ToString());
        Console.WriteLine(l1.ToString());
        Trojkat t1 = new Trojkat(p1, p2, p3);
        Console.WriteLine(t1);
        Czworokat c1 = new Czworokat(p1, p2, p3, p4);
        Console.WriteLine(c1);
        Obraz o = new Obraz();
        o.dodajTrojkat(t1);
        o.dodajCzworokat(c1);
        Console.WriteLine(o.ToString());
        o.przesun(10, 10);

    }
}
class Punkt
{
    private int x;
    private int y;

    public Punkt()
    {
        this.x = 0;
        this.y = 0;
    }
    public Punkt(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public Punkt(Punkt p)
    {
        this.x = p.x;
        this.y = p.y;
    }
    public void przesun(int x, int y)
    {
        this.x += x;
        this.y += y;
    }
    public override string ToString()
    {
        string tekst = "Punkt(" + this.x + "," + this.y + ")";
        return tekst;
    }
}
class Linia
{
    private Punkt p1, p2;

    public Linia(Punkt p1, Punkt p2)
    {
        this.p1 = new Punkt(p1);
        this.p2 = new Punkt(p2);
    }
    public Linia(Linia l)
    {
        this.p1 = l.p1;
        this.p2 = l.p2;
    }
    public void przesun(int x, int y)
    {
        p1.przesun(x, y);
        p2.przesun(x, y);
    }
    public override string ToString()
    {
        string tekst = "Linia(" + p1.ToString() + ", " + p2.ToString()+")";
        return tekst;
    }
}

class Trojkat
{
    private Linia l1, l2, l3;

    public Trojkat(Punkt p1, Punkt p2, Punkt p3)
    {
        this.l1 = new Linia(p1, p2);
        this.l2 = new Linia(p2, p3);
        this.l3 = new Linia(p3, p1);
    }
    public Trojkat(Trojkat t)
    {
        this.l1 = t.l1;
        this.l2 = t.l2;
        this.l3 = t.l3;
    }
    public void przesun(int x, int y)
    {
        l1.przesun(x,y);
        l2.przesun(x,y);
        l3.przesun(x,y);
    }
    public override string ToString()
    {
        string tekst = "Trojkat(" + l1.ToString() + "; " + l2.ToString() + "; " + l3.ToString() + ")";
        return tekst;
    }

}
class Czworokat
{
    private Linia l1, l2, l3, l4;

    public Czworokat(Punkt p1, Punkt p2, Punkt p3, Punkt p4)
    {
        this.l1 = new Linia(p1, p2);
        this.l2 = new Linia(p2, p3);
        this.l3 = new Linia(p3, p4);
        this.l4 = new Linia(p4, p1);
    }
    public Czworokat(Czworokat c)
    {
        this.l1 = c.l1;
        this.l2 = c.l2;
        this.l3 = c.l3;
        this.l4 = c.l4;
    }
    public void przesun(int x, int y)
    {
        l1.przesun(x, y);
        l2.przesun(x, y);
        l3.przesun(x, y);
        l4.przesun(x, y);
    }
    public override string ToString()
    {
        string tekst = "Czworokat(" + l1.ToString() + "; " + l2.ToString() + "; " + l3.ToString() + "; " + l4.ToString() + ")";
        return tekst;
    }
}
class Obraz
{
    private List<Trojkat> trojkaty = new List<Trojkat>();
    private List<Czworokat> czworokaty = new List<Czworokat>();

    public void dodajTrojkat(Trojkat t)
    {
        trojkaty.Add(t);
    }

    public void dodajCzworokat(Czworokat c)
    {
        czworokaty.Add(c);
    }

    public void przesun(int x, int y)
    {
        for (int i = 0; i < trojkaty.Count; i++)
        {
            trojkaty[i].przesun(x, y);
        }
        for (int i = 0; i < czworokaty.Count; i++)
        {
            czworokaty[i].przesun(x, y);
        }
    }
    //123
    public override string ToString()
    {
        StringBuilder nazwa = new StringBuilder();
        for (int i = 0; i < trojkaty.Count; i++)
        {
            string tekst = "Trojkat nr " + (i + 1) + ": " + trojkaty[i].ToString() + "\n";
            nazwa.Append(tekst);
        }
        for (int i = 0; i < czworokaty.Count; i++)
        {
            string tekst = "Czworokat nr " + (i + 1) + ": " + czworokaty[i].ToString() + "\n";
            nazwa.Append(tekst);
        }
        return nazwa.ToString();
    }


}
//Miłego Dnia
