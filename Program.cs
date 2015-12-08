using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using TETCSharpClient;
using TETCSharpClient.Data;
//using System.all*;

namespace Clicker
{
    public static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        public static void Main()
        {
                    
                Parallel.Invoke(() =>
                                    {
                                        GazePoint point = new GazePoint();
                                        GazeData gazeData = new GazeData();
                                        point.OnGazeUpdate(gazeData);
                                       
                                    },
                                () =>
                                {
                                       trackingclass.track();
                                }
                                 );



        }

           
    }

 
}

