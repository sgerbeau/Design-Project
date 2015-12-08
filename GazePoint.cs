using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using TETCSharpClient;
using TETCSharpClient.Data;

public class GazePoint : IGazeListener
{

    #region Get/Set
     public bool Enabled { get; set; }
    public bool Smooth { get; set; }
    public Screen ActiveScreen { get; set; }

    #endregion

    #region Constructor

    public GazePoint()    
        :this(Screen.PrimaryScreen, false, false)        
    {}
    public GazePoint(Screen screen, bool enabled, bool smooth)
    {
        // Connect client
       GazeManager.Instance.Activate(GazeManager.ApiVersion.VERSION_1_0, GazeManager.ClientMode.Push);

        // Register this class for events
        GazeManager.Instance.AddGazeListener(this);
        ActiveScreen = screen;
        Enabled = enabled;
        Smooth = smooth;

        Thread.Sleep(50000000); // simulate app lifespan (e.g. OnClose/Exit event) //5000

        // Disconnect client
        GazeManager.Instance.Deactivate();
    }

    #endregion
    public void OnGazeUpdate(GazeData gazeData)
    {       
        // start or stop tracking lost animation
        if ((gazeData.State & GazeData.STATE_TRACKING_GAZE) == 0 &&
            (gazeData.State & GazeData.STATE_TRACKING_PRESENCE) == 0)
            return;
        
        // tracking coordinates
        var x = ActiveScreen.Bounds.X;
         var y = ActiveScreen.Bounds.Y;
        var gX = Smooth ? gazeData.SmoothedCoordinates.X : gazeData.RawCoordinates.X;
        var gY = Smooth ? gazeData.SmoothedCoordinates.Y : gazeData.RawCoordinates.Y;
        var screenX = (int)Math.Round(x + gX, 0);
        var screenY = (int)Math.Round(y + gY, 0);

        // return in case of 0,0 
        if (screenX == 0 && screenY == 0) return;
        
        NativeMethods.SetCursorPos(screenX, screenY);
    }

        public class NativeMethods
    {
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]


        public static extern bool SetCursorPos(int x, int y);

    }


}
