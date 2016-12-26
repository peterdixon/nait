/*
 * Use loops to create a PONG game.
 * We will start with practice mode
 * a loop must be used to animate the ball and move the paddle
 * the ball will have an (x,y) location and a xVel and yVel velocity
 * those velocity variables will change he ball position for each execution of the animation loop.
 * when the ball his the wall or the paddle, it will bounce and proceed in the opposite direction by 90 degrees.
 * each time the ball bounces off the paddle, score += 1
 * animation loop needs a delay of 20 ms to reduce the speed of the ball.
 * if you want, you can reduce the time delay each time the paddle hits the ball.
 * y position of the mouse will determine the position of the paddle
 * your code must prevent the paddle from moving into the walls or out of the  window
 * use the vertical mouse position (read once every animation loop) to position the paddle
 * 
 * The game starts when the user clicks the left mouse button within the game board.
 * the ball will startt from a random position on the left side of the board and move towards the right.
 * you ma want to apply some randomness to yVel when the game starts.
 * the game ends when the ball exits from the left side of the game board
 * the program will display the final score then pause for a short period
 * then it will show to buttons: play again and quit
 * if the user clicks play again, another round starts.
 * if they press quit the program ends. 
 *
 * Clicking elsewhere will be ignored
 * 
 * you may add a pong sound when it bounces. its on the course website named pong.wav
 * 

*/

//Current Issues

//Need to update ball and paddle positions at runtime

//We need to change the upperleft attribute of the wall and ball instances of mypaddle and myball during runtime
//We also need to be able to change XVel and Yvel.

/* Google says
 * PropertyInfo propertyInfo = objName.GetType().GetProperty(propertyName);
propertyInfo.SetValue(propertyInfo, value, null);
 */



 //Known bugs

 //I have noticed that the paddle coordinate checker didnt verify the right cases. I need to determine what the actual bounds on the screen are. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using Lab3ClassLibrary;

namespace Lab3_Peter_Dixon
{
    class Program
    {
        static void Main(string[] args)
        {

            //GDI drawer variables.
            int windowWidth = 800;
            int windowHeight = 600;


            
            //Game Variables
            bool lostGame = false;
            int delay = 20; //delay in milliseconds.

            CDrawer gdi = new CDrawer(windowWidth, windowHeight);
            gdi.Scale = 5;
            //gdi.Scale = 5;
            //I don't like the Scale function because it doesnt seem to interact with objects well.

            gdi.ContinuousUpdate = false; //In order to draw the objects, a render() command must be issued.

            int wallThickness = 2;
            //Initialize the Walls, Paddle, and Ball Objects.
            //See the Wall, Ball, Ball Behavior, and Paddle Behavior classes for an explanation.
            //Balls and Walls are rectangles
            //Balls have their initial position and velocity set by the Ball Initializer
            //If I want to set this game up with any number of balls, I could make a list of balls and the current setup would make them all different.
            //a Paddle is a Wall with Paddle Behavior.
         
            var topWall = new Wall()
            {
                Width = gdi.ScaledWidth,
                Height = wallThickness,
                UpperLeft = new Point() { X = 0, Y = 0},
                Color = Color.Green
            };
            var bottomWall = new Wall()
            {
                Width = gdi.ScaledWidth,
                Height = wallThickness,
                UpperLeft = new Point() { X = 0, Y = gdi.ScaledHeight-wallThickness },
                Color = Color.Green
            };
            var leftWall = new Wall()
            {
                Width = wallThickness,
                Height = gdi.ScaledHeight,
                UpperLeft = new Point() { X = 0, Y = 0 },
                Color = Color.Blue
            };
            var rightWall = new Wall()
            {
                Width = wallThickness,
                Height = gdi.ScaledHeight,
                UpperLeft = new Point() { X = gdi.ScaledWidth - wallThickness, Y = 0 },
                Color = Color.Green
            };
          
            //Create the Paddle by instantiating the Wall Class and the MovePaddle Class.
            var myPaddle = new Wall()
            {
                Width = gdi.ScaledWidth / 30,
                Height = gdi.ScaledHeight/ 5,
                UpperLeft = new Point() { X = 60, Y = 50 },
                Color = Color.Blue
            };

           


            #region Initialize Balls 
            var myBallIntializer = new BallInitializer();
            var BallList = new List<Ball>();
            /*
            var myBall = new Ball();
            {
                Width = 4,                                     //Width of ball
                Height = 4,                                    //Height of ball
                UpperLeft = new Point() { X = myBallIntializer.InitializeXStart(gdi), Y = myBallIntializer.InitializeYStart(gdi) },  //Initial X and Y Coordinates of Ball.                                     
                XVel = myBallIntializer.InitializeXVelocity(),                   //Initial X velocity of ball
                YVel = myBallIntializer.InitializeYVelocity(),                    //Initial Y velocity of ball.
                Color = Color.Yellow
            };
            */
            /*
            //Test Ball: Moves up and down 
            var myBall = new Ball()
            {
                Width = 4,                                     //Width of ball
                Height = 4,                                    //Height of ball
                UpperLeft = new Point() { X = myBallIntializer.InitializeXStart(gdi), Y = myBallIntializer.InitializeYStart(gdi) },  //Initial X and Y Coordinates of Ball.                                     
                XVel = 0,                   //Initial X velocity of ball
                YVel = 5,                    //Initial Y velocity of ball.
                Color = Color.Yellow
            };
            */
            //Test Ball: moves diagonally
            var myBall = new Ball()
            {
                Width = 4,                                     //Width of ball
                Height = 4,                                    //Height of ball
                UpperLeft = new Point() { X = myBallIntializer.InitializeXStart(gdi), Y = myBallIntializer.InitializeYStart(gdi) },  //Initial X and Y Coordinates of Ball.                                     
                XVel = 2,                   //Initial X velocity of ball
                YVel = 2,                  //Initial Y velocity of ball.
                Color = Color.Yellow
            };

            //
            var myBallMover = new BallMover();
            #endregion

            //Render all Walls
            Renderer gameUpdater = new Renderer(gdi);

            Console.WriteLine(myBall.UpperLeft);
            while (lostGame == false)
            {
                gdi.Clear();
                
                
                gameUpdater.DrawRectangle(topWall);
                gameUpdater.DrawRectangle(bottomWall);
                gameUpdater.DrawRectangle(rightWall);
                gameUpdater.DrawRectangle(leftWall);

                myPaddle.UpperLeft = myPaddle.GetNewPaddleCoordinates(gdi);
                

                //PaddleMover.UpdatePaddleCoordinates(gdi);
                
                gameUpdater.DrawRectangle(myPaddle);
                myBall.VerticalRebound(myPaddle, gdi);

                myBall.HorizontalRebound(topWall, gdi);
                myBall.HorizontalRebound(bottomWall, gdi);
                myBall.VerticalRebound(leftWall,gdi);
                myBall.VerticalRebound(rightWall,gdi);
                myBall.UpperLeft =  myBallMover.MoveBall(myBall, gdi);
                
                
                gameUpdater.DrawRectangle(myBall);
                gameUpdater.Render();
                System.Threading.Thread.Sleep(delay);
               
            }
            

            #region Sample Rebound testing code

            /* .
            //Console.WriteLine("xVel {0} yVel {1} rVel {2} dTheta {3} theta {4}", xVel, yVel, rVel, dTheta, theta);
            Console.WriteLine("{0}, {1}", velocity[0], velocity[1]);
            velocity = GetReboundSpeed(velocity, dTheta);
            Console.WriteLine("{0}, {1}", velocity[0], velocity[1]);
            */

            //These functions center the paddle at the mouse click Y coordinate.
            #endregion

            Console.ReadKey();
            }
        }
    #region obsolete color function
    /*
    //Generate a random Color
    public Color RandomColor()
    {
        Color randomColor = Color.Aqua;
        Random generator = new Random();
        int integer = generator.Next(0, 10);

        switch (integer)
        {
            case 0: randomColor = Color.Black; break;
            case 1: randomColor = Color.Brown; break;
            case 2: randomColor = Color.Red; break;
            case 3: randomColor = Color.Orange; break;
            case 4: randomColor = Color.Yellow; break;
            case 5: randomColor = Color.Green; break;
            case 6: randomColor = Color.Blue; break;
            case 7: randomColor = Color.Violet; break;
            case 8: randomColor = Color.Gray; break;
            case 9: randomColor = Color.White; break;
        }

        return randomColor;
    }
    */
    #endregion
    #region OldMovePaddle
    /* This function gets the last place the mouse was clicked.
     * 
     */
    /* This was removed and put in the class library.
    static Point MovePaddle(CDrawer gdi, int paddleHeight, Point pt)
   {
       int paddleY = (gdi.ScaledHeight- paddleHeight) / 2;

       gdi.GetLastMouseLeftClick(out pt);

       if (pt.Y < paddleHeight / 2)
       {
           paddleY = 0;
       }
       else if (pt.Y > gdi.ScaledHeight - paddleHeight / 2)
       {
           paddleY = gdi.ScaledHeight - paddleHeight;
       }
       else
       {
           paddleY = pt.Y - paddleHeight / 2;
       }
      // pt = ( pt.X, paddleY);

       return pt;
   }
   */
    #endregion

}


