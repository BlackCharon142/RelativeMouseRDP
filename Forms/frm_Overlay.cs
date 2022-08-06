using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace RelativeMouseRDP
{
    public partial class frm_Overlay : Form
    {
        public frm_Overlay()
        {
            InitializeComponent();
            GlobalShortcut.StartHook();
        }

        #region Form Methods

        private void frm_Overlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalShortcut.StopHook();
        }

        private void frm_Overlay_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Position = new Point((this.Left + this.Width / 2), (this.Top + this.Height / 2));
            new InputSimulator().Mouse.LeftButtonDoubleClick();
            new InputSimulator().Mouse.MoveMouseBy(0, 1);
            Cursor.Clip = this.Bounds;
        }

        #endregion

        #region Fast Action Menu Items

        private void tsmiSendMenuShortcut_Click(object sender, EventArgs e)
        {

        }

        private void tsmiDisableOverlay_Click(object sender, EventArgs e)
        {
            if (true)
            {

            }
        }

        private void tsmiHideCursor_Click(object sender, EventArgs e)
        {
            if (Cursor.Current.IsVisible() && tsmiHideCursor.Checked)
                Cursor.Hide();
            else
                Cursor.Show();
        }

        #endregion

        #region Public Form Changes

        public void SetSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void SetLocation(int top, int left)
        {
            this.Top = top;
            this.Left = left;
        }

        public void OpenFastActionMenu()
        {
            Cursor.Clip = new Rectangle();
            tsmiSendMenuShortcut.Text = "Send " + new KeysConverter().ConvertToInvariantString(GlobalShortcut.ShortcutFastActionMenu);
            cmsFunctions.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        #endregion

        #region Recording Actions

        private void RecorderCheck_Tick(object sender, EventArgs e)
        {
            if (LastInputInfo.GetLastInputTime() >= 150)
                RecordingIndicator();
            else
                RecordingIndicator(true);
        }

        private void RecordingIndicator(bool recording = false)
        {
            if (recording)
            {
                pbRecordingIndicator.Refresh();
                Graphics g = pbRecordingIndicator.CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.FillEllipse(Brushes.Red, (pbRecordingIndicator.Width / 4), (pbRecordingIndicator.Height / 4), pbRecordingIndicator.Width / 3, pbRecordingIndicator.Height / 3);
                g.DrawEllipse(new Pen(Brushes.Red, 2), (pbRecordingIndicator.Width / 4) - 3, (pbRecordingIndicator.Height / 4) - 3, (pbRecordingIndicator.Width / 3) + 6, (pbRecordingIndicator.Height / 3) + 6);
            }
            else
            {
                pbRecordingIndicator.Refresh();
                Graphics g = pbRecordingIndicator.CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.DrawRectangle(new Pen(Color.FromArgb(21, 224, 91), 4), (pbRecordingIndicator.Width / 4) - 3, (pbRecordingIndicator.Height / 4) - 3, (pbRecordingIndicator.Width / 2), (pbRecordingIndicator.Height / 2));
                //g.FillEllipse(new SolidBrush(Color.FromArgb(21, 224, 91)), (pbRecordingIndicator.Width / 4), (pbRecordingIndicator.Height / 4), pbRecordingIndicator.Width / 3, pbRecordingIndicator.Height / 3);
                //g.DrawEllipse(new Pen(Color.FromArgb(21, 224, 91), 2), (pbRecordingIndicator.Width / 4) - 3, (pbRecordingIndicator.Height / 4) - 3, (pbRecordingIndicator.Width / 3) + 6, (pbRecordingIndicator.Height / 3) + 6);
            }
        }

        #endregion

        #region Actions

        Point lastCursorPosition;

        private void frm_Overlay_MouseDown(object sender, MouseEventArgs e)
        {
            InputData.DownEvent(e.Button);
            label1.Text = e.Button.ToString() + e.Clicks;
        }

        private void frm_Overlay_MouseMove(object sender, MouseEventArgs e)
        {
            if (tsmiGameMode.Checked)
            {
                Point currentCursorPosition = new Point(e.X - (this.Bounds.Width / 2)/* + 9*/, e.Y - (this.Bounds.Height / 2) /*+ 38*/);

                if (currentCursorPosition.X < -50 || currentCursorPosition.X > +50 || currentCursorPosition.Y < -50 || currentCursorPosition.Y > 50)
                {
                    Cursor.Position = new Point(Location.X + this.Bounds.Width / 2, Location.Y + this.Bounds.Height / 2);
                    lastCursorPosition.X = 0;
                    lastCursorPosition.Y = 0;
                    currentCursorPosition.X = 0;
                    currentCursorPosition.Y = 0;
                }
                else
                {
                    int X;
                    int Y;
                    if (lastCursorPosition.X == currentCursorPosition.X)
                    {
                        X = 0;
                    }
                    else if (lastCursorPosition.X > currentCursorPosition.X)
                    {
                        X = currentCursorPosition.X - lastCursorPosition.X;
                        lastCursorPosition.X = currentCursorPosition.X;
                    }
                    else
                    {
                        X = currentCursorPosition.X - lastCursorPosition.X;
                        lastCursorPosition.X = currentCursorPosition.X;
                    }

                    if (lastCursorPosition.Y == currentCursorPosition.Y)
                    {
                        Y = 0;
                    }
                    else if (lastCursorPosition.Y > currentCursorPosition.Y)
                    {
                        Y = currentCursorPosition.Y - lastCursorPosition.Y;
                        lastCursorPosition.Y = currentCursorPosition.Y;
                    }
                    else
                    {
                        Y = currentCursorPosition.Y - lastCursorPosition.Y;
                        lastCursorPosition.Y = currentCursorPosition.Y;
                    }

                    InputData.Delta(new Point(X, Y));
                    InputData.Position(e.Location);

                    //radioButton1.Left += X;
                    //radioButton1.Top += Y;
                    //label1.Text = "X=" + X + ";Y=" + Y;
                }
            }
            else
            {
                Point mousePos = MousePosition;

                if (mousePos == lastCursorPosition)
                    return;

                //int deltaX = (mousePos.X - lastCursorPosition.X);
                //int deltaY = (mousePos.Y - lastCursorPosition.Y);

                lastCursorPosition = MousePosition;

                pbRecordingIndicator.Left += (mousePos.X - lastCursorPosition.X);
                pbRecordingIndicator.Top += (mousePos.Y - lastCursorPosition.Y);


                //label1.Text = "X: " + deltaX.ToString() + " Y: " + deltaY.ToString() + "\r\n" + pbRecordingIndicator.Location.ToString();
            }
        }

        private void frm_Overlay_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void frm_Overlay_MouseWheel(object sender, MouseEventArgs e)
        {
            label1.Text = e.Delta.ToString();
        }

        private void frm_Overlay_KeyDown(object sender, KeyEventArgs e)
        {
            label1.Text = e.KeyData.ToString();
        }

        #endregion

    }
}
