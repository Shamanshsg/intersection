using System;
using static System.Math;

namespace intersection;

class intersection
{
    static double x;
    static double y;
    const double eps = 0.0000000000001;
    static void Main()
    {
        System.Console.WriteLine("1 прямая - 1");
        System.Console.WriteLine("2 прямая - 2");
        int t = Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("Точка a (x,y)");
        point a = new point(Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()));
        System.Console.WriteLine("Точка b (x,y)");
        point b = new point(Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()));
        System.Console.WriteLine("Точка c (x,y)");
        point c = new point(Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()));
        System.Console.WriteLine("Точка d (x,y)");
        point d = new point(Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()));
        
        switch(t)
        {
            case 1:
            if(interl1(a,b,c,d))
            {
                System.Console.WriteLine("Они пересекаются");
            }
            else
            {
                System.Console.WriteLine("Они не пересекаются");
            }

            break;

            case 2:  
                if (interl(a,b,c,d) )
                {
                    System.Console.WriteLine("Они пересекаются");
                    System.Console.WriteLine($"x = {x}   y = {y}");
                }
                else
                {
                    System.Console.WriteLine("Они не пересекаются");
                }
            break;
        }
    }

    static int area (point a, point b,point c)
    {
        return (b.x - a.x) * (c.y - a.y) - (b.y - a.y)*(c.x - a.x);
    }

    static bool intert (point a, point b,point c, point d)
    {
        return  inter1(a.x, b.x, c.x, d.x) &&
        inter1(a.y, b.y, c.y, d.y) &&
        area(a,b,c)*area(a,b,d) <= 0 &&
        area(c,d,a)*area(c,d,b) <= 0 ;
    }

    static bool between (int a, int b, double c)
    {
        return Min(a,b) <= c + eps && c <= Max(a,b) + eps; 
    }

    static bool inter1 (int a , int b, int c, int d)
    {
        if(a > b){Swap(ref a,ref b);}
        if(c > d){Swap(ref c,ref d);}
        return Max(a,c) <= Min(b,d);
    }

    static int det (int a, int b, int c, int d)
    {
        return a*d - b*c;
    }

    static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
//1 внизу    2 вверху
    static int area2 (point a, point b,point c)
    {
        return (b.x - a.x) * (c.y - a.y) - (b.y - a.y)*(c.x - a.x);
    }
    static int area1 (point a, point b,point c)
    {
        return Abs(area2(a, b, c) / 2);
    } 
    static bool interl(point a, point b,point c, point d)
    {
        int A1 = a.y-b.y,  B1 = b.x-a.x,  C1 = -A1*a.x - B1*a.y;
        int A2 = c.y-d.y,  B2 = d.x-c.x,  C2 = -A2*c.x - B2*c.y;
        int zn = det (A1, B1, A2, B2);
        if (zn != 0) {
		x = - det (C1, B1, C2, B2) * 1.0 / zn;
		y = - det (A1, C1, A2, C2) * 1.0 / zn;
        System.Console.WriteLine(1);
		return between (a.x, b.x, x) && between (a.y, b.y, y)
			&& between (c.x, d.x, x) && between (c.y, d.y, y);
	}
	else
		return det (A1, C1, A2, C2) == 0 && det (B1, C1, B2, C2) == 0
			&& inter1 (a.x, b.x, c.x, d.x)
			&& inter1 (a.y, b.y, c.y, d.y);
    }
// C выше чем D
// A выше чем B
    static bool interl1(point a, point b,point c, point d)
    {
        double k = (a.y - b.y)/(a.x - b.x);
        double B = a.y - k*a.x;
        if((c.y >= k*c.x + B || d.y >=k*d.x + B) && (c.y <= k*c.x + B || d.y <= k*d.x + B ))
        {
            double lab = Sqrt(Pow(a.x - b.x, 2) + Pow(a.y - b.y, 2)); 
            double lcd = Sqrt(Pow(c.x - d.x, 2) + Pow(c.y - d.y, 2));
            if(lab <= lcd)
            {
                point ctop = new point(b.x, a.y);
                double Stop = area1(a,b,ctop);
                point cbot = new point(b.y, a.x);
                double Sbot = area1(a,b,cbot);
                double Sup = area1(a,c,ctop) + area1(b,c,ctop) + area1(a,b,c);
                double Sd = area1(a,d,cbot) + area1(b,d,cbot) + area1(a,b,d);
                if((Stop == Sup && Sbot != Sd) || (Stop != Sup && Sbot == Sd) || (Stop != Sup && Sbot != Sd))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                point ctop = new point(d.x, c.y);
                double Stop = area1(c,d,ctop);
                point cbot = new point(d.y, c.x);
                double Sbot = area1(c,d,cbot);
                double Sup = area1(c,a,ctop) + area1(d,a,ctop) + area1(c,d,a);
                double Sd = area1(c,d,cbot) + area1(d,b,cbot) + area1(c,d,b);
                if((Stop == Sup && Sbot != Sd) || (Stop != Sup && Sbot == Sd) || (Stop != Sup && Sbot != Sd))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }

}




public class point
{
    public int x;
    public int y;
    public point(int x1, int y1)
    {
        x = x1;
        y = y1;
    }
}