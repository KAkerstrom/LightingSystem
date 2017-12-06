using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualBasic;

namespace LightingSystemUI
{

    public partial class layoutEditorForm : Form
    {
        [Serializable()]

        #region init
        public struct FloorPlan
        {
            public List<Rectangle> rectList;
            public List<Tuple<Point, Point>> lines;
            public List<Dictionary<string, Point>> ListRectCorners;
        }

        static Timer drawTimer;
        //Lists of lines and rectangles(rooms)
        static List<Rectangle> drawnRectangles = new List<Rectangle>();
        static List<Tuple<Point, Point>> drawnLines = new List<Tuple<Point, Point>>();
        //temporary values for drawing rectangles(rooms) and lines
        static Tuple<Point, Point> tmpLine;
        Rectangle tmpRectangle;
        public Dictionary<string, Point> RectangleCorners;
        public List<Dictionary<string, Point>> ListRectCorners = new List<Dictionary<string, Point>>();
        //bools for rectangles(rooms)
        bool rectDrawBegin, rectDrawing = false;
        //bools for lines       
        bool lineDrawBegin, lineDrawing = false;
        //used for both rectangles and lines
        Point currentPoint, startPoint, endPoint;
        Point tmpLinePoint, tmpLineDest, tmpLinePrevdest;
        int lineSnapDistance = 50;

        Bitmap tmpBitmap;
        #endregion

        #region Constructors
        public layoutEditorForm(string fileName)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            drawTimer = new Timer();
            drawTimer.Interval = 1;
            drawTimer.Tick += MyTimer_Tick;
            LoadGeometry(fileName);
        }
        public layoutEditorForm()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            drawTimer = new Timer();
            drawTimer.Interval = 1;
            drawTimer.Tick += MyTimer_Tick;
        }
        #endregion

        #region panelEvents
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = Cursor.Position;
            if (rectDrawBegin) //change rectangle bools, set temp values for rectangle drawing
            {
                drawTimer.Enabled = true;
                currentPoint = Cursor.Position;
                tmpRectangle.X = currentPoint.X;
                tmpRectangle.Y = currentPoint.Y;
                rectDrawBegin = false;
                lblError.Visible = false;
                rectDrawing = true;
            }
            else

            if (lineDrawBegin)//change line bools, set temp values for line drawing
            {
                if (drawnRectangles.Count != 0)
                {
                    startPoint = panel1.PointToClient(pointLine(Cursor.Position));
                }
                lineDrawing = true;
                drawTimer.Enabled = true;
                lineDrawBegin = false;
                if (tmpLinePoint.IsEmpty)
                    tmpLinePoint = new Point(Cursor.Position.X, Cursor.Position.Y);

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            endPoint = Cursor.Position;
            if (rectDrawing)
            {
                // Draw rectangle based on current cursor position and previous temp values, record and store rect corner co-ordinates
                rectDrawing = false;
                tmpRectangle.X = panel1.PointToClient(tmpRectangle.Location).X;
                tmpRectangle.Y = panel1.PointToClient(tmpRectangle.Location).Y;
                tmpRectangle.Width = (panel1.PointToClient(Cursor.Position).X - tmpRectangle.X);
                tmpRectangle.Height = (panel1.PointToClient(Cursor.Position).Y - tmpRectangle.Y);

                if ((tmpRectangle.Width > 0) && (tmpRectangle.Height > 0))
                    drawnRectangles.Add(tmpRectangle);
                RectangleCorners = new Dictionary<string, Point>();
                RectangleCorners.Add("TopRight", new Point(tmpRectangle.Location.X + tmpRectangle.Width, tmpRectangle.Location.Y));
                RectangleCorners.Add("BottomLeft", new Point(tmpRectangle.Location.X, tmpRectangle.Location.Y + tmpRectangle.Height));
                RectangleCorners.Add("BottomRight", new Point(tmpRectangle.Location.X + tmpRectangle.Width, tmpRectangle.Location.Y + tmpRectangle.Height));
                RectangleCorners.Add("TopLeft", new Point(tmpRectangle.Location.X, tmpRectangle.Location.Y));
                ListRectCorners.Add(RectangleCorners);

                // Draw rectangle based on where temp rectangle values are compared to cursor
                if ((tmpRectangle.Width > 0) && (tmpRectangle.Height < 0))
                {
                    tmpRectangle.Y += tmpRectangle.Height;
                    tmpRectangle.Height *= -1;
                    drawnRectangles.Add(tmpRectangle);
                }
                if ((tmpRectangle.Width < 0) && (tmpRectangle.Height > 0))
                {
                    tmpRectangle.X += tmpRectangle.Width;
                    tmpRectangle.Width *= -1;
                    drawnRectangles.Add(tmpRectangle);
                }
                if ((tmpRectangle.Width < 0) && (tmpRectangle.Height < 0))
                {
                    tmpRectangle.X += tmpRectangle.Width;
                    tmpRectangle.Width *= -1;
                    tmpRectangle.Y += tmpRectangle.Height;
                    tmpRectangle.Height *= -1;
                    drawnRectangles.Add(tmpRectangle);
                }
                drawTimer.Enabled = false;
            }

            if (lineDrawing)
            // Draw line based on current cursor position and previous temp values
            {
                drawTimer.Enabled = false;
                tmpLinePoint = panel1.PointToClient(Cursor.Position);
                if (drawnRectangles.Count != 0)
                    tmpLine = new Tuple<Point, Point>(startPoint, panel1.PointToClient(pointLine(endPoint)));
                else
                    tmpLine = new Tuple<Point, Point>(panel1.PointToClient(startPoint), panel1.PointToClient(endPoint));

                drawnLines.Add(tmpLine);
                lineDrawing = false;
                tmpLinePrevdest = Point.Empty;
                tmpLinePoint = Point.Empty;
            }

            panel1.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Tuple<Point, Point> tmp in drawnLines)
                e.Graphics.DrawLine(Pens.Black, tmp.Item1, tmp.Item2);

            foreach (Rectangle tmp in drawnRectangles)
                e.Graphics.DrawRectangle(Pens.Black, tmp);
        }

        #endregion

        #region methods

        private void DrawReversibleRectangle()
        {
            ControlPaint.DrawReversibleFrame(tmpRectangle, Color.Black, FrameStyle.Dashed);
            int width = (Cursor.Position).X - currentPoint.X;
            int height = (Cursor.Position).Y - currentPoint.Y;
            tmpRectangle = new Rectangle(currentPoint.X, currentPoint.Y, width, height);
            ControlPaint.DrawReversibleFrame(tmpRectangle, Color.Black, FrameStyle.Dashed);
        }

        private void DrawReversibleLine()
        {
            tmpLineDest = new Point((Cursor.Position).X, (Cursor.Position).Y);
            if (!tmpLinePrevdest.IsEmpty)
                ControlPaint.DrawReversibleLine(tmpLinePoint, tmpLinePrevdest, Color.Black);
            ControlPaint.DrawReversibleLine(tmpLinePoint, tmpLineDest, Color.Black);
            tmpLinePrevdest = new Point(tmpLineDest.X, tmpLineDest.Y);
        }
        private Point pointLine(Point point)
        {
            for (int rectInd = 0; rectInd < drawnRectangles.Count; rectInd++)
            {

                if ((Math.Abs(point.X - ((ListRectCorners[rectInd]["TopLeft"].X) + this.Location.X + panel1.Location.X)) <= lineSnapDistance) &&
                    (Math.Abs(point.Y - ((ListRectCorners[rectInd]["TopLeft"].Y) + this.Location.Y + panel1.Location.Y)) <= lineSnapDistance))
                {
                    point = new Point(ListRectCorners[rectInd]["TopLeft"].X + this.Location.X + panel1.Location.X,
                        ListRectCorners[rectInd]["TopLeft"].Y + this.Location.Y + panel1.Location.Y);
                    point = new Point(Math.Abs(point.X) + 8, Math.Abs(point.Y) + 31);
                }
                else if ((Math.Abs(point.X - ((ListRectCorners[rectInd]["TopRight"].X) + this.Location.X + panel1.Location.X)) <= lineSnapDistance) &&
                  (Math.Abs(point.Y - ((ListRectCorners[rectInd]["TopRight"].Y) + this.Location.Y + panel1.Location.Y)) <= lineSnapDistance))
                {
                    point = new Point(ListRectCorners[rectInd]["TopRight"].X + this.Location.X + panel1.Location.X,
                        ListRectCorners[rectInd]["TopRight"].Y + this.Location.Y + panel1.Location.Y);
                    point = new Point(Math.Abs(point.X) + 8, Math.Abs(point.Y) + 31);
                }
                else if ((Math.Abs(point.X - ((ListRectCorners[rectInd]["BottomLeft"].X) + this.Location.X + panel1.Location.X)) <= lineSnapDistance) &&
                  (Math.Abs(point.Y - ((ListRectCorners[rectInd]["BottomLeft"].Y) + this.Location.Y + panel1.Location.Y)) <= lineSnapDistance))
                {
                    point = new Point(ListRectCorners[rectInd]["BottomLeft"].X + this.Location.X + panel1.Location.X,
                        ListRectCorners[rectInd]["BottomLeft"].Y + this.Location.Y + panel1.Location.Y);
                    point = new Point(Math.Abs(point.X) + 8, Math.Abs(point.Y) + 31);
                }
                else if ((Math.Abs(point.X - ((ListRectCorners[rectInd]["BottomRight"].X) + this.Location.X + panel1.Location.X)) <= lineSnapDistance) &&
                 (Math.Abs(point.Y - ((ListRectCorners[rectInd]["BottomRight"].Y) + this.Location.Y + panel1.Location.Y)) <= lineSnapDistance))
                {
                    point = new Point(ListRectCorners[rectInd]["BottomRight"].X + this.Location.X + panel1.Location.X,
                        ListRectCorners[rectInd]["BottomRight"].Y + this.Location.Y + panel1.Location.Y);
                    point = new Point(Math.Abs(point.X) + 8, Math.Abs(point.Y) + 31);
                }
                else
                { //ONLY CHECK FOR SIDE IF STATEMENT SHOULD CONCIDER HEIGHT FOR X AXIS, AND WIDTH FOR Y AXIS
                    if ((Math.Abs(point.X - (drawnRectangles[rectInd].Location.X + this.Location.X + panel1.Location.X)) <= lineSnapDistance) &&
                        ((point.Y >= (drawnRectangles[rectInd].Location.Y + this.Location.Y + panel1.Location.Y) && (point.Y <= (drawnRectangles[rectInd].Location.Y + drawnRectangles[rectInd].Height + this.Location.Y + panel1.Location.Y)))))
                    {
                        point = new Point(drawnRectangles[rectInd].Location.X + this.Location.X + panel1.Location.X + 8, Cursor.Position.Y);
                        point = new Point(Math.Abs(point.X), Math.Abs(point.Y));
                    }
                    else if ((Math.Abs(point.X - (drawnRectangles[rectInd].Location.X + drawnRectangles[rectInd].Width + this.Location.X + panel1.Location.X)) <= lineSnapDistance) &&
                        ((point.Y >= (drawnRectangles[rectInd].Location.Y + this.Location.Y + panel1.Location.Y) && (point.Y <= (drawnRectangles[rectInd].Location.Y + drawnRectangles[rectInd].Height + this.Location.Y + panel1.Location.Y)))))
                    {
                        point = new Point(drawnRectangles[rectInd].Location.X + this.Location.X + panel1.Location.X + 8 + drawnRectangles[rectInd].Width, Cursor.Position.Y);
                        point = new Point(Math.Abs(point.X), Math.Abs(point.Y));
                    }
                    else if ((Math.Abs(point.Y - (drawnRectangles[rectInd].Location.Y + this.Location.Y + panel1.Location.Y)) <= lineSnapDistance) &&
                        ((point.X >= (drawnRectangles[rectInd].Location.X + this.Location.X + panel1.Location.X) && (point.X <= (drawnRectangles[rectInd].Location.X + drawnRectangles[rectInd].Width + this.Location.X + panel1.Location.X)))))
                    {
                        point = new Point(Cursor.Position.X, drawnRectangles[rectInd].Location.Y + this.Location.Y + panel1.Location.Y + 31);
                        point = new Point(Math.Abs(point.X), Math.Abs(point.Y));
                    }
                    else if ((Math.Abs(point.Y - (drawnRectangles[rectInd].Location.Y + drawnRectangles[rectInd].Height + this.Location.Y + panel1.Location.Y)) <= lineSnapDistance) &&
                        ((point.X >= (drawnRectangles[rectInd].Location.X + this.Location.X + panel1.Location.X) && (point.X <= (drawnRectangles[rectInd].Location.X + drawnRectangles[rectInd].Width + this.Location.X + panel1.Location.X)))))
                    {
                        point = new Point(Cursor.Position.X, drawnRectangles[rectInd].Height + drawnRectangles[rectInd].Location.Y + this.Location.Y + panel1.Location.Y + 30);
                        point = new Point(Math.Abs(point.X), Math.Abs(point.Y));
                    }
                }
            }
            return point;
        }

        private void SaveGeometry(string fileName)
        {
            FloorPlan floorPlan = new FloorPlan();
            floorPlan.lines = drawnLines;
            floorPlan.rectList = drawnRectangles;
            floorPlan.ListRectCorners = ListRectCorners;
            try
            {
                using (Stream stream = File.Open("./Layouts/serialized/" + fileName + ".bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, floorPlan);
                }
            }
            catch (IOException ex)
            { MessageBox.Show("Error: {" + ex.Message + "}"); }
        }

        private void SavePanelAsBitmap(Panel panel)
        {
            tmpBitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(tmpBitmap, panel.ClientRectangle);
            string input = Interaction.InputBox("Enter a name for your floor plan", "Name your floor plan", "default", -1, -1);
            try
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream("./Layouts/bitmaps/" + input, FileMode.Create, FileAccess.ReadWrite))
                    {
                        tmpBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SaveGeometry(input);
        }
        private void LoadGeometry(string fileName)
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FloorPlan floorPlan = new FloorPlan();
                    floorPlan = (FloorPlan)bf.Deserialize(stream);
                    drawnRectangles = floorPlan.rectList;
                    drawnLines = floorPlan.lines;
                    ListRectCorners = floorPlan.ListRectCorners;
                }
            }
            catch (IOException ex)
            { MessageBox.Show("Error: " + ex.Message); }
        }

        #endregion

        #region buttons/misc
        private void btnSaveLayout_Click(object sender, EventArgs e)
        {
            SavePanelAsBitmap(panel1);
        }
        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            lineDrawBegin = true;
            rectDrawBegin = false;
        }
        public void btnDrawRectangle_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
            rectDrawBegin = true;
            lineDrawBegin = false;
        }
        private void MyTimer_Tick(object sender, EventArgs e) //for when lines and rectangles are being "traced"
        {
            if (rectDrawing) DrawReversibleRectangle();
            else if (lineDrawing) DrawReversibleLine();
            panel1.Invalidate();
        }
        private void layoutEditorForm_Click(object sender, EventArgs e) //make sure user is drawing in the panel
        {
            if (rectDrawBegin)
            {
                lblError.Text = "You must draw the rectangle within the white panel";
                lblError.Visible = true;
            }
            else if (lineDrawBegin)
            {
                lblError.Text = "You must draw the line within the white panel";
                lblError.Visible = true;
            }
            else
                lblError.Visible = false;
        }
        private void layoutEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveGeometry("Default");
        }
        private void layoutEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            drawnRectangles.Clear();
            drawnLines.Clear();
        }
        #endregion  
    }
}
