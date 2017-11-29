using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LightTest.Kyle;

namespace LightingSystemUI
{
    
    public partial class LightIcon : UserControl
    {
        private Light light;
        public Light thisLight {
            get { return light; }
            set
            {
                light = value;
                light.BrightnessChanged += Light_BrightnessChanged;
            }
        }

        private void Light_BrightnessChanged(byte brightness)
        {
            if(brightness >= 50)
                BackgroundImage = new Bitmap("idea.png");
            else
                BackgroundImage = new Bitmap("ideaoff.png");
        }

        //public static List<LightIcon> icons = new List<LightIcon>();
        Point currentPoint; //used to define mouse location while dragging icons
        FlowLayoutPanel toolbox; //holds all instances of the control
        
        Form1 form; //form that controls will be placed 
        Image myLight = LightingSystemUI.Properties.Resources.on1; //may not use
        Timer myTimer = new Timer(); //timer for drag n drop code
        Panel bitmappanel;
        bool Pressed = false; //to determine whether or not the mouse is clicked on the control
        public LightIcon(FlowLayoutPanel iconToolbox, Form1 parentForm) //constructor takes parameters for prent toolbox and form
        {
            InitializeComponent();
            myTimer.Interval = 10;     
            myTimer.Tick += MyTimer_Tick; //adds tick event for timer
            toolbox = iconToolbox; //assigns panel parameter to class-wide toolbox variable
            form = parentForm; //assigns form parameter to class-wide form variable
            bitmappanel = parentForm.bitmappanel;
            toolbox.Controls.Add(this); //adds the instantiated control to the toolbox(panel)
            this.Cursor = Cursors.Hand; //when mouse hovers over control, change cursor to 'hand'
            
            this.BackgroundImage = new Bitmap("ideaoff.png"); //icon lightbulb image
        }

        private void MyTimer_Tick(object sender, EventArgs e) //called every .01 seconds
        {
         
            if (Pressed == false) //if mouse is not pressed over control
            {
                return;
            }
            else
            {
                //set location of user control(this) to location of mouse cursor
                this.Left = Parent.PointToClient(Cursor.Position).X - currentPoint.X; 
                this.Top = Parent.PointToClient(Cursor.Position).Y - currentPoint.Y;               
            }               

        }
        private void LightIcon_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(myLight, 0, 0, Width, Height); //draws icon with image and desired width and height
        }

        private void LightIcon_Click(object sender, EventArgs e)
        {
            if (light.Brightness > 50)
                thisLight.Brightness = 0;
            else
                thisLight.Brightness = 100;
        }


        private void LightIcon_MouseDown_1(object sender, MouseEventArgs e)
        {
            currentPoint = this.PointToClient(Cursor.Position); //assigns cursor position to variable to be used in timer code
            Pressed = true; //icon is currently being 'drug'
            myTimer.Enabled = true; //enables timer

            //remove icon from toolbox, add to form (change parent to form)
            toolbox.Controls.Remove(this); 
            form.bitmappanel.Controls.Add(this);
            
            //hide toolbox
            toolbox.SendToBack();
            //this.BackgroundImage = new Bitmap("idea.png");

            thisLight.ToggleOnOff();
        }

        private void LightIcon_MouseUp_1(object sender, MouseEventArgs e)
        {

            Pressed = false; //icon is not being 'drug'
            myTimer.Enabled = false; //disable timer, timer code no longer runs
            
            //if mouse 'releases' icon within toolbox, add control to toolbox again 
            if (toolbox.Bounds.Contains(form.PointToClient(Cursor.Position)))
            {
                toolbox.Controls.Add(this);
            }
            //this.BackgroundImage = new Bitmap("ideaoff.png");
        }

        public void CreateIcons(int lightCount, FlowLayoutPanel panel )
        {
            for (int i=0;i<lightCount-1;i++)
            {
              
            }
        }

    }
}
