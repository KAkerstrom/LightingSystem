using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightingSystemUI
{

    public partial class Room : UserControl
    {
        
        private static bool pressed;
        private static Point currentPoint;
        public static List<Room> rooms = new List<Room>();
        public static bool Pressed { get { return pressed; } }
        public Room(int w, int h)
        {
            InitializeComponent();
            this.Width = w;
            this.Height = h;
            rooms.Add(this);
            
        }
               
        public static Point CurrentPoint { get { return currentPoint; } }

        public void DrawFrame(Graphics gr)
        {
            gr.DrawRectangle(Pens.Black, this.Location.X, this.Location.Y, this.Width, this.Height);            
        }

        private void Room_MouseDown(object sender, MouseEventArgs e)
        {
            pressed = true;
            currentPoint = this.PointToClient(Cursor.Position);
            
        }

        private void Room_MouseUp(object sender, MouseEventArgs e)
        {
            pressed = false;
            
            
        }
    }
}
