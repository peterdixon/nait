using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace Lab3ClassLibrary
{
    //This interface is shared between the Ball and Wall
    //This means that we can draw a rectangle without specifying whether it is a ball or wall.
    public interface IRectangle
    {
        int Width {get;set;}
        int Height { get; set; }
        Point UpperLeft { get; set; }
        Color Color { get; set; }

    }

    public class Renderer
    {
        //Properties
        private CDrawer gdi;

        //Get the Drawer
        public Renderer(CDrawer gdi) //Renderer needs to be passed a drawer from Program.cs
        {
            this.gdi = gdi;
        }

        
        //Methods
        public void DrawRectangle(IRectangle rectangle) 
        {       
            gdi.AddRectangle(rectangle.UpperLeft.X, rectangle.UpperLeft.Y, rectangle.Width, rectangle.Height, rectangle.Color); //Draw any Rectangle you want.            
            
        }

        public void Render()
        {
            gdi.Render();
        }
    }

        
    }
    //This is the abstract Wall class, which includes the paddle.
    public class Wall : Lab3ClassLibrary.IRectangle
{     
        //Properties
        public int Width { get; set; }              //Width of Wall
        public int Height { get; set; }             //Height of Wall
        public Point UpperLeft { get; set; }        //Upper left corner of wall.
        public Color Color { get; set; }            //Color of wall

    public Point GetNewPaddleCoordinates(CDrawer gdi)
    {

        //The normal case:
        Point pt;
        gdi.GetLastMousePosition(out pt);

        //The case where the box is too high never happens: since it starts where the mouse is.
        if (pt.Y/gdi.Scale < gdi.ScaledHeight / 10)
            return new Point() { X = gdi.ScaledWidth / 8, Y = 0 };

        else if (pt.Y/gdi.Scale > (gdi.ScaledHeight - Height) )
            return new Point() { X = gdi.ScaledWidth / 8, Y = gdi.ScaledHeight - Height };

            //The normal case.
        return new Point() { X = gdi.ScaledWidth / 8, Y = (pt.Y - gdi.ScaledHeight / 10) / gdi.Scale };
    }
}
 
    //This is the abstract Ball Class
    public class Ball : Lab3ClassLibrary.IRectangle
{
        //Properties
        public int Width { get; set; }  //Width of Ball
        public int Height { get; set; } //Height of Ball
        public Point UpperLeft { get; set; } //Upper Left corner of Ball.   
        public Color Color { get; set; } //Color of Ball

        public double XVel { get; set; }    //X Velocity of Ball
        public double YVel { get; set; }    //Y velocity of Ball.

    //Implements bouncing on Vertical Walls.
    public void VerticalRebound(Wall wall, CDrawer gdi)
    {
      //If the ball is close to the wall, rebounding is possible.
        if (Math.Abs(UpperLeft.X - wall.UpperLeft.X-wall.Width)/gdi.Scale < Math.Abs(XVel)/gdi.Scale)
        {
            //The top end of the paddle or wall.           
            if (Math.Abs(UpperLeft.Y)/gdi.Scale > wall.UpperLeft.Y/gdi.Scale )
            {
                //The bottom end of the paddle or wall.
                if (Math.Abs(UpperLeft.Y)/gdi.Scale < (wall.UpperLeft.Y + wall.Height - Height)/gdi.Scale)
                {
                    //Bounce the Ball
                    XVel = -XVel;
                    YVel = YVel;
                }
            }
        }
    }
    //When a ball hits the upper or lower walls, this function bounces them back into the game field.
    //This function could be refactored to be like the Vertical Rebound to add more players in.
    public void HorizontalRebound(Wall wall, CDrawer gdi)
    {
        if (Math.Abs(UpperLeft.Y - wall.UpperLeft.Y)/gdi.Scale < Math.Abs(YVel)/gdi.Scale)
        {
            
            XVel = XVel;
            YVel = -YVel;
         
        }

    }
}

//Randomizes the location and velocity of each ball.
//I was hoping to implement a list of balls to generate any number of balls in the game without needing to name them
//Each ball would be initialized by this class

    public class BallInitializer
    {
        //Fields

        Random Generator = new Random();
        double TotalSpeed = 10; //This is the total speed of the ball per cycle.

        public double GetAngle()
        {
            return Math.PI / 2 + Math.PI * Generator.NextDouble(); //This angle is guaranteed to be in either quadrants 2 or 3 of the unit circle.
        }
   
        public int InitializeXStart(CDrawer gdi)
        {
        
        return (gdi.ScaledWidth/2 + gdi.ScaledWidth/4); //Randomize the starting X coordinate of the ball, it must start far away from the goal.        
        }

        public int InitializeYStart(CDrawer gdi)
        {            return Generator.Next(gdi.ScaledHeight/4, gdi.ScaledHeight/2+gdi.ScaledHeight/4);  //Randomize the starting Y coordinate of the ball        
        }
        public double InitializeXVelocity()
        { 
        return TotalSpeed*Math.Cos(GetAngle());           //Randomize the x direction velocity, direction is moving towards the goal        
        }

        public double InitializeYVelocity()
        {
        return TotalSpeed * Math.Sin(GetAngle());          //Randomize the y direction velocity, direction is either up or down        
        }
    }
    
//This class moves the ball when MoveBall() is called.
//It's in a class other than Ball because it might be useful
//In implementing moving objects other than balls.
public class BallMover
{
    //Problem: this method can't see what upperleft or xvel is..
    public Point MoveBall(Ball ball, CDrawer gdi)
    {
        //Console.WriteLine(ball.UpperLeft.X);
        //Console.WriteLine(ball.XVel);
        int NextX = (int)((ball.UpperLeft.X + ball.XVel));
        int NextY = (int)((ball.UpperLeft.Y + ball.YVel));

        //Problem: this point always turns out as 0.
        //Console.WriteLine("{0} and {1}", NextX, NextY);

        return new Point() { X = NextX, Y = NextY };
    }
}


//This class wasn't implemented in this build
//It was intended to produce more dynamic ball physics
//Where the ball bounced off at the same angle that it hit the wall with.
public class CollisionDetector 
    {
        //This checks two inputs and sees if they are colliding or not.
        
        //Properties
        Ball MyBall { get; set; }
        Wall MyWall { get; set; }
     
        //Methods    

        //Calculate the center of a rectangle.
        public Point Center(Lab3ClassLibrary.IRectangle rectangle)
            {
            return new Point() { X = rectangle.UpperLeft.X + rectangle.Width/2, Y = rectangle.UpperLeft.Y + rectangle.Height/2 };
            }

        //This function gets the equation of the line made by the ball's velocity vector.
        //and puts it in the form
        //Ax + By = C, where A,B, and C are doubles.

        //To get a line in the form Ax+By+C, we take two points
        //(x1,y1) and (x2,y2)
        //Then A = y2-y1, B = x1-x2, and C = A*x1+B*y1

        //For the ball, the points are the ball's center (x,y) and (x+xvel, y+yvel).
        public List<double> BallEqn()
            {
                List<double> line1 = new List<double>();
        //double A = Center myBall.Y + myBall.YVel - Center myBall.Y;
        //double B = Center myBall.X - Center myBall.X - myball.Xvel
        double A = MyBall.YVel;
        double B = -MyBall.XVel;
        double C = A * Center(MyBall).X + B * Center(MyBall).Y;
        line1.Add(A);
        line1.Add(B);
        line1.Add(C);
        return line1;

            }
    //A = y2-y1, B = x1-x2, and C = A*x1+B*y1

    //for a horizontal wall, the points are (xstart, ystart+height/2) and (xstart+width, ystart+height/2)
    public List<double> HLineEqn()
        {
            List<double> line1 = new List<double>();
        //double A = ystart+height/2 - ystart-height/2 = 0
        //double B = xstart - xstart-width
        double A = 0;
        double B = -MyWall.Width;
            double C = B * (MyWall.UpperLeft.Y+MyWall.Height/2);
            line1.Add(A);
            line1.Add(B);
            line1.Add(C);
            return line1;

        }
    //A = y2-y1, B = x1-x2, and C = A*x1+B*y1
    //for a vertical wall, the points are (xstart+width/2, ystart) and (xstart+width/2, ystart+height)
    public List<double> VLineEqn()
    {
        List<double> line1 = new List<double>();
        //double A = ystart + height - ystart = height
        //double B = 0
        double A = MyWall.Height;
        double B = 0;
        double C = A *( MyWall.UpperLeft.X + MyWall.Width/2);
        line1.Add(A);
        line1.Add(B);
        line1.Add(C);
        return line1;

    }
    //Intersection of two lines is solved by the following:
    //If the lines have form
    //A1x+B1y= C1
    //A2x+B2y=C2
    //Then if det = a1*b2-a2*b1 != 0
    //x = (b2*c1-b1*c2 ) / det
    //y = (a1*c2-a2*c1) / det
    //Index of A is 0, B is 1, C is 2.
    public Point HLineAndBallCollisionCoords()
    {

        double det = BallEqn()[0] * HLineEqn()[1] - HLineEqn()[0] * BallEqn()[1];

        if (det == 0)
        { //Lines are parallel and dont intersect
            return new Point() { X = -1, Y = -1 }; //I think this would create a bug if the code were implemented in some other program.
        }
        else
        {
            double XCoord = (HLineEqn()[1] * BallEqn()[2] - BallEqn()[1] * HLineEqn()[2]) / det;
            double YCoord = (BallEqn()[0] * HLineEqn()[2] - HLineEqn()[0] * BallEqn()[2]) / det;

            return new Point() { X = (int)XCoord, Y = (int)YCoord };
        }
    }
     public Point VLineAndBallCollisionCoords()
    {

        double det = BallEqn()[0] * VLineEqn()[1] - VLineEqn()[0] * BallEqn()[1];

        if (det == 0)
        { //Lines are parallel and dont intersect
            return new Point() { X = 0, Y = 0 }; //I think this would create a bug if the code were implemented in some other program.
        }
        else

        {
            double XCoord = (VLineEqn()[1] * BallEqn()[2] - BallEqn()[1] * VLineEqn()[2]) / det;
            double YCoord = (BallEqn()[0] * VLineEqn()[2] - VLineEqn()[0] * BallEqn()[2]) / det;

            return new Point() { X = (int)XCoord, Y = (int)YCoord };
        }


    }
    
}
