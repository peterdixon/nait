using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace MouseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            CDrawer gdi = new CDrawer();    // the drawer window
            Point pt;                       // where the mouse was clicked
            bool exit = false;              // detects when to exit program

            gdi.ContinuousUpdate = false;

            // draw a rectangular button for exit
            gdi.AddRectangle(700, 550, 50, 25, Color.Black, 2, Color.Green);
            gdi.AddText("Exit", 16, 700, 550, 50, 25, Color.Green);

            // continue drawing until user clicks the exit button
            while (!exit)
            {
                // check for a mouse click
                if(gdi.GetLastMouseLeftClick(out pt))
                {
                    // check for mouse click in exit button
                    if(pt.X > 700 && pt.X < 750 && pt.Y > 550 && pt.Y < 575)
                    {
                        // cause the animation loop to exit
                        exit = true;
                    }
                    // mouse click not in the exit button, draw a circ le
                    else
                    {
                        gdi.AddCenteredEllipse(pt.X, pt.Y, 20, 20, RandColor.GetColor());
                    }
                }
                // give up the CPU to allow windows to update
                System.Threading.Thread.Sleep(10);

                // draw all objects in the backbuffer
                gdi.Render();
            }
        }
    }
}
