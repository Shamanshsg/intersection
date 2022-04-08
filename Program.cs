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
        System.Console.WriteLine("Два отрезка - 1");
        System.Console.WriteLine("Прямая и окружность - 2");
        int e = Convert.ToInt32(Console.ReadLine());
        switch (e)
        {
            case 1:
                System.Console.WriteLine("1 прямая - 1");
                System.Console.WriteLine("2 прямая - 2");
                double t = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Точка a (x,y)");
                point a = new point(Convert.ToDouble(Console.ReadLine()),Convert.ToDouble(Console.ReadLine()));
                System.Console.WriteLine("Точка b (x,y)");
                point b = new point(Convert.ToDouble(Console.ReadLine()),Convert.ToDouble(Console.ReadLine()));
                System.Console.WriteLine("Точка c (x,y)");
                point c = new point(Convert.ToDouble(Console.ReadLine()),Convert.ToDouble(Console.ReadLine()));
                System.Console.WriteLine("Точка d (x,y)");
                point d = new point(Convert.ToDouble(Console.ReadLine()),Convert.ToDouble(Console.ReadLine()));
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
            break;

            case 2:
                System.Console.WriteLine("Введите A, B, C");
                line l = new line(Convert.ToDouble(Console.ReadLine()),Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
                System.Console.WriteLine("Введите радиус и x и y");
                circle cc1 = new circle(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
                double C =l.C + ((cc1.x*l.A) + (cc1.y)*l.B);
                interc(l.A, l.B, C, cc1.r, cc1);
            break;
        }
        
        
    }

    static double area (point a, point b,point c)
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

    static bool between (double a, double b, double c)
    {
        return Min(a,b) <= c + eps && c <= Max(a,b) + eps; 
    }

    static bool inter1 (double a , double b, double c, double d)
    {
        if(a > b){Swap(ref a,ref b);}
        if(c > d){Swap(ref c,ref d);}
        return Max(a,c) <= Min(b,d);
    }

    static double det (double a, double b, double c, double d)
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
    static double area2 (point a, point b,point c)
    {
        return (b.x - a.x) * (c.y - a.y) - (b.y - a.y)*(c.x - a.x);
    }
    static double area1 (point a, point b,point c)
    {
        return Abs(area2(a, b, c) / 2);
    } 
    static bool interl(point a, point b,point c, point d)
    {
        double A1 = a.y-b.y,  B1 = b.x-a.x,  C1 = -A1*a.x - B1*a.y;
        double A2 = c.y-d.y,  B2 = d.x-c.x,  C2 = -A2*c.x - B2*c.y;
        double zn = det (A1, B1, A2, B2);
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
            k = (c.y - d.y)/(c.x - d.x);
            B = c.y - k*c.x;
            if((a.y >= k*a.x + B || b.y >=k*b.x + B) && (a.y <= k*a.x + B || b.y <= k*b.x + B ))
            {
                return true;
            }
            else{return false;}
        }
        else
        {
            return false;
        }
    }


    static void interc(double A, double B, double C, double r, circle cc1)
    {
        double x0 = -A*C/(A*A+B*B),  y0 = -B*C/(A*A+B*B);
        if (C*C > r*r*(A*A+B*B) + eps)
        {
            System.Console.WriteLine("Пересечения нет");
        }
        else if (Abs(C*C - r*r*(A*A+B*B)) < eps)
        {
            System.Console.WriteLine("Пересечение в 1 точке");
            System.Console.WriteLine($"({x0 + cc1.x}, {y0 + cc1.y})");
        }
        else
        {
            double d = r*r - C*C/(A*A+B*B);
            double mult = Sqrt(d / (A*A+B*B));
            double ax,ay,bx,by;
            ax = x0 + B * mult;
            bx = x0 - B * mult;
            ay = y0 - B * mult;
            by = y0 + B * mult;
            System.Console.WriteLine("персечение в 2-х точках");
            System.Console.WriteLine($"({ax + cc1.x}, {ay + cc1.y}) .... ({bx + cc1.x}, {by + cc1.y})");
        }
    }
}




public class point
{
    public double x;
    public double y;
    public point(double x1, double y1)
    {
        x = x1;
        y = y1;
    }
}

public class circle
{
    public double x;
    public double y;
    public double r;

    public circle(double r1, double x1, double y1)
    {
        x = x1;
        y = y1;
        r = Sqrt(r1);
    }
}

public class line
{
    public double A;
    public double B;
    public double C;

    public line (double A1, double B1, double C1)
    {
        A = A1;
        B = B1;
        C = C1;
    }
}