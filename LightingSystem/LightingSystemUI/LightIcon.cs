using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conduit;

namespace LightingSystemUI
{    
    public partial class LightIcon : UserControl
    {
        #region init
        private Light light;
        public Light thisLight
        {
            get { return light; }
            set
            {
                light = value;
                light.BrightnessChanged += Light_BrightnessChanged;
            }
        }
        //public static List<LightIcon> icons = new List<LightIcon>();
        Point currentPoint; //used to define mouse location while dragging icons
        FlowLayoutPanel toolboxPanel; //holds all instances of the control

        Form1 form; //form that controls will be placed 
        Timer myTimer = new Timer(); //timer for drag n drop code
        Panel bitmappanel;
        bool Pressed = false; //to determine whether or not the mouse is clicked on the control
        #endregion  init 

        #region Constructors
        public LightIcon(FlowLayoutPanel iconToolbox, Form1 parentForm) //constructor takes parameters for prent toolbox and form
        {
            InitializeComponent();
            myTimer.Interval = 10;
            myTimer.Tick += MyTimer_Tick; //adds tick event for timer
            toolboxPanel = iconToolbox; //assigns panel parameter to class-wide toolbox variable
            form = parentForm; //assigns form parameter to class-wide form variable
            bitmappanel = parentForm.bitmappanel;
            toolboxPanel.Controls.Add(this); //adds the instantiated control to the toolbox(panel)
            this.Cursor = Cursors.Hand; //when mouse hovers over control, change cursor to 'hand'

            this.BackgroundImage = new Bitmap("ideaoff.png"); //icon lightbulb image
        }

        #endregion Constructors

        #region methods
        private void Light_BrightnessChanged(byte brightness)
        {
            if (brightness >= 50)
                this.BackgroundImage = new Bitmap("ideaoff.png"); //icon lightbulb image
            else
                this.BackgroundImage = new Bitmap("idea.png"); //icon lightbulb image
        }
        private void LightIcon_Click(object sender, EventArgs e)
        {
            //changes the icon on/off bool
            // if (isOn == false)  ---- ??         
            thisLight.ToggleOnOff();
            this.Invalidate();
        }
        #endregion methods

        #region dragndrop
        private void MyTimer_Tick(object sender, EventArgs e) //called every .01 seconds
        {
            if (Pressed) //if mouse is not pressed over control
            { //set location of user control(this) to location of mouse cursor
                this.Left = Parent.PointToClient(Cursor.Position).X - currentPoint.X;
                this.Top = Parent.PointToClient(Cursor.Position).Y - currentPoint.Y;
            }
        }
        private void LightIcon_MouseDown_1(object sender, MouseEventArgs e)
        {
            currentPoint = this.PointToClient(Cursor.Position); //assigns cursor position to variable to be used in timer code
            Pressed = true; //icon is currently being 'drug'
            myTimer.Enabled = true; //enables timer

            //remove icon from toolbox, add to form (change parent to form)
            toolboxPanel.Controls.Remove(this);
            form.bitmappanel.Controls.Add(this);

            //hide toolbox
            toolboxPanel.SendToBack();
            //this.BackgroundImage = new Bitmap("idea.png");

            thisLight.ToggleOnOff();
        }

        private void LightIcon_MouseUp_1(object sender, MouseEventArgs e)
        {

            Pressed = false; //icon is not being 'drug'
            myTimer.Enabled = false; //disable timer, timer code no longer runs

            //if mouse 'releases' icon within toolbox, add control to toolbox again 
            if (toolboxPanel.Bounds.Contains(form.PointToClient(Cursor.Position)))
            {
                toolboxPanel.Controls.Add(this);
            }
            //this.BackgroundImage = new Bitmap("ideaoff.png");
        }
        #endregion dragndrop

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesForm propertiesForm = new PropertiesForm();
            propertiesForm.Show();
            this.Hide();
        }
    }
}
