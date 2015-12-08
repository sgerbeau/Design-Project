using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using TETCSharpClient;
using TETCSharpClient.Data;

namespace Clicker
{
    class trackingclass
    {
        public static void track()
        {
            bool stay_in_loop = true;
            bool restart = true;
            double tol_pos_x = 100;
            double tol_pos_y = 300;
            int X_1 = -1;
            int X_2 = -1;
            int X_3 = -1;
            int X_4 = -1;
            int X_5 = -1;
            int X_6 = -1;
            int Y_1 = -1;
            int Y_2 = -1;
            int Y_3 = -1;
            int Y_4 = -1;
            int Y_5 = -1;
            int Y_6 = -1;
            
            while (stay_in_loop)
            {
                X_1 = X_2;
                Y_1 = Y_2;
                X_2 = X_3;
                Y_2 = Y_3;
		        X_3 = X_4;
                Y_3 = Y_4;
	        	X_4 = X_5;
                Y_4 = Y_5;
		        X_5 = X_6;
                Y_5 = Y_6;

                X_6 = Cursor.Position.X;
                Y_6 = Cursor.Position.Y;

                if(X_1==-1 || X_2==-1 || X_3==-1 || X_4==-1 || X_5==-1 || X_6==-1 || Y_1==-1 || Y_2==-2 || Y_3==-1 || Y_4==-1 || Y_5==-1 || Y_6==-1)
                {
                    restart = true;                               
                }
                else
                {
                    restart = false;
                }
                
//FIXATION PATTERN

                if (!restart &&
                    (((Math.Abs(X_2 - X_1) < tol_pos_x) && (Math.Abs(X_3 - X_1) < tol_pos_x) && (Math.Abs(X_4 - X_1) < tol_pos_x) && (Math.Abs(X_5 - X_1) < tol_pos_x) && (Math.Abs(X_6 - X_1) < tol_pos_x)
                    && (Math.Abs(X_3 - X_2) < tol_pos_x) && (Math.Abs(X_4 - X_2) < tol_pos_x) && (Math.Abs(X_5 - X_2) < tol_pos_x) && (Math.Abs(X_6 - X_2) < tol_pos_x)
                    && (Math.Abs(X_4 - X_3) < tol_pos_x) && (Math.Abs(X_5 - X_3) < tol_pos_x) && (Math.Abs(X_6 - X_3) < tol_pos_x)
                    && (Math.Abs(X_5 - X_4) < tol_pos_x) && (Math.Abs(X_6 - X_4) < tol_pos_x)
                    && (Math.Abs(X_6 - X_5) < tol_pos_x)
                    // EN Y
                    && (Math.Abs(Y_2 - Y_1) < tol_pos_y) && (Math.Abs(Y_3 - Y_1) < tol_pos_y) && (Math.Abs(Y_4 - Y_1) < tol_pos_y) && (Math.Abs(Y_5 - Y_1) < tol_pos_y) && (Math.Abs(Y_6 - Y_1) < tol_pos_y)
                    && (Math.Abs(Y_3 - Y_2) < tol_pos_y) && (Math.Abs(Y_4 - Y_2) < tol_pos_y) && (Math.Abs(Y_5 - Y_2) < tol_pos_y) && (Math.Abs(Y_6 - Y_2) < tol_pos_y)
                    && (Math.Abs(Y_4 - Y_3) < tol_pos_y) && (Math.Abs(Y_5 - Y_3) < tol_pos_y) && (Math.Abs(Y_6 - Y_3) < tol_pos_y)
                    && (Math.Abs(Y_5 - Y_4) < tol_pos_y) && (Math.Abs(Y_6 - Y_4) < tol_pos_y)
                    && (Math.Abs(Y_6 - Y_5) < tol_pos_y))

                    ||

                    ((Math.Abs(X_2 - X_1) < tol_pos_x) && (Math.Abs(X_3 - X_1) < tol_pos_x) && (Math.Abs(X_4 - X_1) < tol_pos_x) && (Math.Abs(X_5 - X_1) < tol_pos_x) && (Math.Abs(X_6 - X_1) < tol_pos_x)
                    && (Math.Abs(X_3 - X_2) < tol_pos_x) && (Math.Abs(X_4 - X_2) < tol_pos_x) && (Math.Abs(X_5 - X_2) < tol_pos_x) && (Math.Abs(X_6 - X_2) < tol_pos_x)
                    && (Math.Abs(X_4 - X_3) < tol_pos_x) && (Math.Abs(X_5 - X_3) < tol_pos_x) && (Math.Abs(X_6 - X_3) < tol_pos_x)
                    && (Math.Abs(X_5 - X_4) < tol_pos_x) && (Math.Abs(X_6 - X_4) < tol_pos_x)
                    && (Math.Abs(X_6 - X_5) < tol_pos_x)
                    && (Math.Abs(Y_2 - Y_1) < tol_pos_y) && (Math.Abs(Y_3 - Y_2) < tol_pos_y) && (Math.Abs(Y_4 - Y_3) < tol_pos_y) && (Math.Abs(Y_5 - Y_4) < tol_pos_y) && (Math.Abs(Y_6 - Y_5) < tol_pos_y)))
                    )
                {
                    MouseActions.DoMouseClick((X_1 + X_2 + X_3 + X_4 + X_5 + X_6) / 6, (Y_1 + Y_2 + Y_3 + Y_4 + Y_5 + Y_6) / 6);
                    System.Threading.Thread.Sleep(1000);

                    X_1 = -1;
                    Y_1 = -1;
                    X_2 = -1;
                    Y_2 = -1;
                    X_3 = -1;
                    Y_3 = -1;
                    X_4 = -1;
                    Y_4 = -1;
                    X_5 = -1;
                    Y_5 = -1;
                    X_6 = -1;
                    Y_6 = -1;
                }
                
                    System.Threading.Thread.Sleep(200);

            }

        }

    }
}
