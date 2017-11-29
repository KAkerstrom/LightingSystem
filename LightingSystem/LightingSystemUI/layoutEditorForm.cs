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
        int pointToValue;
        string Oleg = "Shkliaiev";
        long olegMoney = 1000000000;
        string WEGETITTOWORK = "FUCKOFF";
        string WEGETITTOWORK2 = "DI more THINGS";
        [Serializable()]
        public struct FloorPlan
        {
            public List<Rectangle> rectList;
            public List<Tuple<Point, Point>> lines;
            public List<Dictionary<string, Point>> ListRectCorners;
        }
        
        private static Timer myTimer;
        //Lists of lines and rectangles(rooms)
        public static List<Rectangle> Rooms = new List<Rectangle>();
        public static List<Tuple<Point, Point>> myListOfLines = new List<Tuple<Point, Point>>();
        //temporary values for drawing rectangles(rooms) and lines
        public static Tuple<Point, Point> myLine;
        public Rectangle rectTmp;
        public Dictionary<string, Point> RectangleCorners;
        public List<Dictionary<string, Point>> ListRectCorners = new List<Dictionary<string, Point>>();
        //bools for rectangles(rooms)
        public bool rectDrawBegin = false;
        public bool rectDrawing = false;
        
        
        //bools for lines
        Point pnt, dest, prevdest;
        bool lineDrawBegin = false;
        bool lineDrawing = false;
        //used for both rectangles and lines
        Point currentPoint;
        Point startPoint, endPoint;

        Bitmap tmpBitmap;
        public layoutEditorForm(string fileName)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            myTimer = new Timer();
            myTimer.Interval = 1;
            myTimer.Tick += MyTimer_Tick;
            LoadLayOut(fileName);
            pointToValue = 50;
        }
        public layoutEditorForm()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            myTimer = new Timer();
            myTimer.Interval = 1;
            myTimer.Tick += MyTimer_Tick;
            pointToValue = 50;
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {

            if (rectDrawing)
            {

                ControlPaint.DrawReversibleFrame(rectTmp, Color.Black, FrameStyle.Dashed);
                int width = (Cursor.Position).X - currentPoint.X;
                int height = (Cursor.Position).Y - currentPoint.Y;
                rectTmp = new Rectangle(currentPoint.X, currentPoint.Y, width, height);
                ControlPaint.DrawReversibleFrame(rectTmp, Color.Black, FrameStyle.Dashed);

            }

            else if (lineDrawing)
            {

                dest = new Point((Cursor.Position).X, (Cursor.Position).Y);
                if (!prevdest.IsEmpty)
                    DrawLine(pnt, prevdest);
                DrawLine(pnt, dest);
                prevdest = new Point(dest.X, dest.Y);

            }

            panel1.Invalidate();
        }

        private void DrawLine(Point start, Point end)
        {
            ControlPaint.DrawReversibleLine(start, end, Color.Black);
        }

        private void layoutEditorForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void layoutEditorForm_Click(object sender, EventArgs e)
        {
            if (rectDrawBegin == true)
            {
                lblError.Text = "You must draw the rectangle within the white panel";
                lblError.Visible = true;
            }
            else if (lineDrawBegin == true)
            {
                lblError.Text = "You must draw the line within the white panel";
                lblError.Visible = true;
            }
            else
                lblError.Visible = false;
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = Cursor.Position;
            if (rectDrawBegin == true)
            {
                myTimer.Enabled = true;
                currentPoint = (Cursor.Position);
                rectTmp.X = currentPoint.X;
                rectTmp.Y = currentPoint.Y;
                rectDrawBegin = false;
                lblError.Visible = false;
                rectDrawing = true;
            }
            else { }

            if (lineDrawBegin == true)
            {
                if (Rooms.Count != 0)
                {
                    startPoint = panel1.PointToClient(pointLine(Cursor.Position));
                }
                lineDrawing = true;
                myTimer.Enabled = true;
                lineDrawBegin = false;
                if (pnt.IsEmpty)
                    pnt = new Point(Cursor.Position.X, Cursor.Position.Y);

            }
        }

        private Point pointLine(Point point)
        {
            for (int rectInd = 0; rectInd < Rooms.Count; rectInd++)
            {

                if ((Math.Abs(point.X - ((ListRectCorners[rectInd]["TopLeft"].X) + this.Location.X + panel1.Location.X)) <= pointToValue) &&
                    (Math.Abs(point.Y - ((ListRectCorners[rectInd]["TopLeft"].Y) + this.Location.Y + panel1.Location.Y)) <= pointToValue))
                {
                    point = new Point(ListRectCorners[rectInd]["TopLeft"].X + this.Location.X + panel1.Location.X,
                        ListRectCorners[rectInd]["TopLeft"].Y + this.Location.Y + panel1.Location.Y);
                    point = new Point(Math.Abs(point.X) + 8, Math.Abs(point.Y) + 31);
                }
                else if ((Math.Abs(point.X - ((ListRectCorners[rectInd]["TopRight"].X) + this.Location.X + panel1.Location.X)) <= pointToValue) &&
                  (Math.Abs(point.Y - ((ListRectCorners[rectInd]["TopRight"].Y) + this.Location.Y + panel1.Location.Y)) <= pointToValue))
                {
                    point = new Point(ListRectCorners[rectInd]["TopRight"].X + this.Location.X + panel1.Location.X,
                        ListRectCorners[rectInd]["TopRight"].Y + this.Location.Y + panel1.Location.Y);
                    point = new Point(Math.Abs(point.X) + 8, Math.Abs(point.Y) + 31);
                }
                else if ((Math.Abs(point.X - ((ListRectCorners[rectInd]["BottomLeft"].X) + this.Location.X + panel1.Location.X)) <= pointToValue) &&
                  (Math.Abs(point.Y - ((ListRectCorners[rectInd]["BottomLeft"].Y) + this.Location.Y + panel1.Location.Y)) <= pointToValue))
                {
                    point = new Point(ListRectCorners[rectInd]["BottomLeft"].X + this.Location.X + panel1.Location.X,
                        ListRectCorners[rectInd]["BottomLeft"].Y + this.Location.Y + panel1.Location.Y);
                    point = new Point(Math.Abs(point.X) + 8, Math.Abs(point.Y) + 31);
                }
                else if ((Math.Abs(point.X - ((ListRectCorners[rectInd]["BottomRight"].X) + this.Location.X + panel1.Location.X)) <= pointToValue) &&
                 (Math.Abs(point.Y - ((ListRectCorners[rectInd]["BottomRight"].Y) + this.Location.Y + panel1.Location.Y)) <= pointToValue))
                {
                    point = new Point(ListRectCorners[rectInd]["BottomRight"].X + this.Location.X + panel1.Location.X,
                        ListRectCorners[rectInd]["BottomRight"].Y + this.Location.Y + panel1.Location.Y);
                    point = new Point(Math.Abs(point.X) + 8, Math.Abs(point.Y) + 31);
                }
                else
                { //ONLY CHECK FOR SIDE IF STATEMENT SHOULD CONCIDER HEIGHT FOR X AXIS, AND WIDTH FOR Y AXIS
                    if ((Math.Abs(point.X - (Rooms[rectInd].Location.X + this.Location.X + panel1.Location.X)) <= pointToValue) && 
                        ((point.Y >= (Rooms[rectInd].Location.Y + this.Location.Y + panel1.Location.Y) && (point.Y <= (Rooms[rectInd].Location.Y + Rooms[rectInd].Height + this.Location.Y + panel1.Location.Y)))))
                    {
                        point = new Point(Rooms[rectInd].Location.X + this.Location.X + panel1.Location.X + 8, Cursor.Position.Y);
                        point = new Point(Math.Abs(point.X), Math.Abs(point.Y));
                    }
                    else if ((Math.Abs(point.X - (Rooms[rectInd].Location.X + Rooms[rectInd].Width + this.Location.X + panel1.Location.X)) <= pointToValue) &&
                        ((point.Y >= (Rooms[rectInd].Location.Y + this.Location.Y + panel1.Location.Y) && (point.Y <= (Rooms[rectInd].Location.Y + Rooms[rectInd].Height + this.Location.Y + panel1.Location.Y)))))
                    {
                        point = new Point(Rooms[rectInd].Location.X + this.Location.X + panel1.Location.X + 8 + Rooms[rectInd].Width, Cursor.Position.Y);
                        point = new Point(Math.Abs(point.X), Math.Abs(point.Y));
                    }
                    else if ((Math.Abs(point.Y - (Rooms[rectInd].Location.Y + this.Location.Y + panel1.Location.Y)) <= pointToValue) &&
                        ((point.X >= (Rooms[rectInd].Location.X + this.Location.X + panel1.Location.X) && (point.X <= (Rooms[rectInd].Location.X + Rooms[rectInd].Width + this.Location.X + panel1.Location.X)))))
                    {
                        point = new Point(Cursor.Position.X, Rooms[rectInd].Location.Y + this.Location.Y + panel1.Location.Y + 31);
                        point = new Point(Math.Abs(point.X), Math.Abs(point.Y));
                    }
                    else if ((Math.Abs(point.Y - (Rooms[rectInd].Location.Y + Rooms[rectInd].Height + this.Location.Y + panel1.Location.Y)) <= pointToValue) &&
                        ((point.X >= (Rooms[rectInd].Location.X + this.Location.X + panel1.Location.X) && (point.X <= (Rooms[rectInd].Location.X + Rooms[rectInd].Width + this.Location.X + panel1.Location.X)))))
                    {
                        point = new Point(Cursor.Position.X, Rooms[rectInd].Height + Rooms[rectInd].Location.Y + this.Location.Y + panel1.Location.Y + 30);
                        point = new Point(Math.Abs(point.X), Math.Abs(point.Y));
                    }
                }
            }
            return point;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            endPoint = Cursor.Position;
            if (rectDrawing == true)
            {

                rectDrawing = false;
                rectTmp.X = panel1.PointToClient(rectTmp.Location).X;
                rectTmp.Y = panel1.PointToClient(rectTmp.Location).Y;
                rectTmp.Width = (panel1.PointToClient(Cursor.Position).X - rectTmp.X);
                rectTmp.Height = (panel1.PointToClient(Cursor.Position).Y - rectTmp.Y);

                if ((rectTmp.Width > 0) && (rectTmp.Height > 0))
                    Rooms.Add(rectTmp);
                RectangleCorners = new Dictionary<string, Point>();
                RectangleCorners.Add("TopRight", new Point(rectTmp.Location.X + rectTmp.Width, rectTmp.Location.Y));
                RectangleCorners.Add("BottomLeft", new Point(rectTmp.Location.X, rectTmp.Location.Y + rectTmp.Height));
                RectangleCorners.Add("BottomRight", new Point(rectTmp.Location.X + rectTmp.Width, rectTmp.Location.Y + rectTmp.Height));
                RectangleCorners.Add("TopLeft", new Point(rectTmp.Location.X, rectTmp.Location.Y));
                ListRectCorners.Add(RectangleCorners);


                if ((rectTmp.Width > 0) && (rectTmp.Height < 0))
                {
                    rectTmp.Y += rectTmp.Height;
                    rectTmp.Height *= -1;
                    Rooms.Add(rectTmp);
                }
                if ((rectTmp.Width < 0) && (rectTmp.Height > 0))
                {
                    rectTmp.X += rectTmp.Width;
                    rectTmp.Width *= -1;
                    Rooms.Add(rectTmp);
                }
                if ((rectTmp.Width < 0) && (rectTmp.Height < 0))
                {
                    rectTmp.X += rectTmp.Width;
                    rectTmp.Width *= -1;
                    rectTmp.Y += rectTmp.Height;
                    rectTmp.Height *= -1;
                    Rooms.Add(rectTmp);
                }
                myTimer.Enabled = false;

            }
            if (lineDrawing == true)
            {
                if (Rooms.Count != 0)
                {
                    myTimer.Enabled = false;
                    pnt = panel1.PointToClient(Cursor.Position);
                    myLine = new Tuple<Point, Point>(startPoint, panel1.PointToClient(pointLine(endPoint)));
                    myListOfLines.Add(myLine);
                    lineDrawing = false;
                    prevdest = Point.Empty;
                    pnt = Point.Empty;
                }
                else
                {
                    myTimer.Enabled = false;
                    pnt = panel1.PointToClient(Cursor.Position);
                    myLine = new Tuple<Point, Point>(panel1.PointToClient(startPoint), panel1.PointToClient(endPoint));
                    myListOfLines.Add(myLine);
                    lineDrawing = false;
                    prevdest = Point.Empty;
                    pnt = Point.Empty;
                }
            }
            panel1.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            foreach (Tuple<Point, Point> tmp in myListOfLines)
            {
                e.Graphics.DrawLine(Pens.Black, tmp.Item1, tmp.Item2);
            }

            foreach (Rectangle tmp in Rooms)
            {
                e.Graphics.DrawRectangle(Pens.Black, tmp);
            }
        }

        private void btnSaveLayout_Click(object sender, EventArgs e)
        {
            tmpBitmap = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(tmpBitmap, panel1.ClientRectangle);
            string input = Interaction.InputBox("Enter Name Of The File for Your Personal Floor Plan",
                "Enter Name for your FloorPlan", "Default", -1, -1);
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
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SaveLayouts(input);
        }

        private void layoutEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLayouts("Default");

        }
        private void LoadLayOut(string fileName)
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FloorPlan floorPlan = new FloorPlan();
                    floorPlan = (FloorPlan)bf.Deserialize(stream);
                    Rooms = floorPlan.rectList;
                    myListOfLines = floorPlan.lines;
                    ListRectCorners = floorPlan.ListRectCorners;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //if (numericUpDown1.Value > 100)
            //{
            //    numericUpDown1.Value = 100;
            //    pointToValue = (int) numericUpDown1.Value;
            //} else if (numericUpDown1.Value < 0)
            //{
            //    numericUpDown1.Value = 0;
            //    pointToValue = (int) numericUpDown1.Value;
            //} else
            //{
            //    pointToValue = (int)numericUpDown1.Value;
            //}
        }

        private void layoutEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Rooms.Clear();
            myListOfLines.Clear();
        }

        private void SaveLayouts(string fileName)
        {
            FloorPlan floorPlan = new FloorPlan();
            floorPlan.lines = myListOfLines;
            floorPlan.rectList = Rooms;
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
            {
                MessageBox.Show("Error: {" + ex.Message + "}");
            }

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

    }
}
