

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Daan.control
{
	public class LISPop : System.ComponentModel.Component
	{
		public interface IPopupUserControl
		{
			bool AcceptPopupClosing();
		}

		public enum ePlacement
		{
			Left = 1,
			Right = 2,
			Top = 4,
			Bottom = 8,
			TopLeft = Top | Left,
			TopRight = Top | Right,
			BottomLeft = Bottom | Left,
			BottomRight = Bottom | Right
		}

		private bool mResizable = false;
		private Control mUserControl;
		private Control mParent;
		private ePlacement mPlacement = ePlacement.BottomRight;
		private Color mBorderColor = Color.DarkGray;
		private int mAnimationSpeed = 50;
		private bool mShowShadow = true;
		protected decimal mOpacity = 1;
        public bool bShow = false;
		public PopupForm mForm;

		public LISPop(Control UserControl, Control parent)
		{
			mParent = parent;
			mUserControl = UserControl;
		}



        //public void Show()
        //{
        //    // I use a shared variable in PopupForm class level for this ShowShadow
        //    // because the CreateParams is called from within the form constructor 
        //    // and we need a way to inform the form if a shadow is nescessary or not
        //    PopupForm.mShowShadow = this.mShowShadow;
        //    if(mForm != null)
        //    {
        //        mForm.DoClose();
        //    }
        //    mForm = new PopupForm(this);
        //    OnDropDown(mParent, new EventArgs());
        //    mForm.isShow = true;
        //}


        public void Show()
        {

            PopupForm.mShowShadow = this.mShowShadow;
            if (mForm != null)
            {
                mForm.Show();
            }
            else
            {
                mForm = new PopupForm(this);
                
            }
            OnDropDown(mParent, new EventArgs());
            bShow = true;
        }

        public void Close()
        {

            if (mForm != null)
            {
                mForm.DoClose();
            }

        }


		public class PopupForm : Form
		{
			public static bool mShowShadow;
			private bool mClosing;
			private const int BORDER_MARGIN = 1;
			private Timer mTimer;
			private Size mControlSize;
			private Size mWindowSize = new Size(0, 0);
			private Point mNormalPos;
			private Rectangle mCurrentBounds = new Rectangle(0, 0, 0, 0);
			private LISPop mPopup;
			private ePlacement mPlacement;
			private DateTime mTimerStarted;
			private decimal mProgress;
			private int mx, my;
			private bool mResizing;
			public Panel mResizingPanel;
			private const int CS_DROPSHADOW = 0x20000;
			private static Image mBackgroundImage;

			public event EventHandler DropDown;
			public event EventHandler DropDownClosed;
			public PopupForm(LISPop popup)
			{
				mPopup = popup;
				SetStyle(ControlStyles.ResizeRedraw, true);
				FormBorderStyle = FormBorderStyle.None;
				StartPosition = FormStartPosition.Manual;
				this.ShowInTaskbar = false;
				this.DockPadding.All = BORDER_MARGIN;
				mControlSize = mPopup.mUserControl.Size;
				mPopup.mUserControl.Dock = DockStyle.Fill;
				Controls.Add(mPopup.mUserControl);
				mWindowSize.Width = mControlSize.Width + 2 * BORDER_MARGIN;
				mWindowSize.Height = mControlSize.Height + 2 * BORDER_MARGIN;
				this.Opacity =Convert.ToDouble( popup.mOpacity);

				//These are here to suppress warnings.
				this.DropDown += new EventHandler(DoNothing);
				this.DropDownClosed += new EventHandler(DoNothing);
				
				Form parentForm = mPopup.mParent.FindForm();
				if(parentForm != null)
				{
					parentForm.AddOwnedForm(this);
				}
				
				if(mPopup.mResizable)
				{
					mResizingPanel = new Panel();
					if(mBackgroundImage == null)
					{
						System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LISPop));
						mBackgroundImage = (System.Drawing.Image)resources.GetObject("CornerPicture.Image");
					}
					mResizingPanel.BackgroundImage = mBackgroundImage;
					mResizingPanel.Width = 12;
					mResizingPanel.Height = 12;
					mResizingPanel.BackColor = Color.Red;
					mResizingPanel.Left = mPopup.mUserControl.Width - 15;
					mResizingPanel.Top = mPopup.mUserControl.Height - 15;
					mResizingPanel.Cursor = Cursors.SizeNWSE;
					mResizingPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
					mResizingPanel.Parent = this;
					mResizingPanel.BringToFront();

					this.mResizingPanel.MouseUp += new MouseEventHandler(mResizingPanel_MouseUp);
					this.mResizingPanel.MouseDown += new MouseEventHandler(mResizingPanel_MouseDown);
					this.mResizingPanel.MouseMove += new MouseEventHandler(mResizingPanel_MouseMove);
				}
				mPlacement = mPopup.mPlacement;

				ReLocate();
											 

				Rectangle workingArea = Screen.FromControl(mPopup.mParent).WorkingArea;
				if(mNormalPos.X + this.Width > workingArea.Right)
				{
					if((mPlacement & ePlacement.Right) != 0)
					{
						mPlacement = (mPlacement & ~ePlacement.Right) | ePlacement.Left;
					}
				}
				else
				{
					if(mNormalPos.X < workingArea.Left)
					{
						if((mPlacement & ePlacement.Left) != 0)
						{
							mPlacement = (mPlacement & ~ePlacement.Left) | ePlacement.Right;
						}
					}
				}
				
				if(mNormalPos.Y + this.Height > workingArea.Bottom)
				{
					if((mPlacement & ePlacement.Bottom) != 0)
					{
						mPlacement = (mPlacement & ~ePlacement.Bottom) | ePlacement.Top;
					}
				}
				else
				{
					if(mNormalPos.Y < workingArea.Top)
					{
						if((mPlacement & ePlacement.Top) != 0)
						{
							mPlacement = (mPlacement & ~ePlacement.Top) | ePlacement.Bottom;
						}
					}
				}
				
				if(mPlacement != mPopup.mPlacement)
				{
					ReLocate();
				}
				

				if(mNormalPos.X + mWindowSize.Width > workingArea.Right)
				{
					mNormalPos.X = workingArea.Right - mWindowSize.Width;
				}
				else
				{
					if(mNormalPos.X < workingArea.Left)
					{
						mNormalPos.X = workingArea.Left;
					}
				}
				
				if(mNormalPos.Y + mWindowSize.Height > workingArea.Bottom)
				{
					mNormalPos.Y = workingArea.Bottom - mWindowSize.Height;
				}
				else
				{
					if(mNormalPos.Y < workingArea.Top)
					{
						mNormalPos.Y = workingArea.Top;
					}
				}
				
				// Initialize the animation
				mProgress = 0;
				if(mPopup.mAnimationSpeed > 0)
				{
					mTimer = new Timer();
					
	
					mTimer.Interval = 1000 / 25;
					mTimerStarted = DateTime.Now;
					mTimer.Tick += new EventHandler(Showing);
					mTimer.Start();
					Showing(null, null);
				}
				else
				{
					SetFinalLocation();
				}
				
				Show();
				mPopup.OnDropDown(mPopup.mParent, new EventArgs());
			}

			public static bool DropShadowSupported()
			{
				OperatingSystem os = Environment.OSVersion;
				return ((os.Platform == PlatformID.Win32NT) && (os.Version.CompareTo(new Version(5, 1, 0, 0)) >= 0));
			}

			protected override CreateParams CreateParams
			{
				get
				{
					CreateParams parameters = base.CreateParams;
					if(mShowShadow && DropShadowSupported())
					{
						parameters.ClassStyle = parameters.ClassStyle | CS_DROPSHADOW;
					}
					return parameters;
				}
			}

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (mTimer != null)
                    {
                        mTimer.Dispose();
                    }
                }
                try
                {
                    base.Dispose(disposing);
                }
                catch
                { }
            }

			private void ReLocate()
			{
				int rW = mWindowSize.Width, rH = mWindowSize.Height;
				
				mNormalPos = mPopup.mParent.PointToScreen(Point.Empty);
				switch(mPlacement)
				{
					case ePlacement.Top:
					case ePlacement.TopLeft:
					case ePlacement.TopRight:
						mNormalPos.Y -= rH;
						break;
					case ePlacement.Bottom:
					case ePlacement.BottomLeft:
					case ePlacement.BottomRight:
						mNormalPos.Y += mPopup.mParent.Height;
						break;
					case ePlacement.Left:
					case ePlacement.Right:
						mNormalPos.Y += (mPopup.mParent.Height - rH) / 2;
						break;
				}
				
				switch(mPlacement)
				{
					case ePlacement.Left:
						mNormalPos.X -= rW;
						break;
					case ePlacement.TopRight:
					case ePlacement.BottomRight:
						break;
					case ePlacement.Right:
						mNormalPos.X += mPopup.mParent.Width;
						break;
					case ePlacement.TopLeft:
					case ePlacement.BottomLeft:
						mNormalPos.X += mPopup.mParent.Width - rW;
						break;
					case ePlacement.Top:
					case ePlacement.Bottom:
						mNormalPos.X += (mPopup.mParent.Width - rW) / 2;
						break;
				}
			}

			private void Showing(object sender, EventArgs e)
			{
				mProgress =Convert.ToDecimal( DateTime.Now.Subtract(mTimerStarted).TotalMilliseconds / mPopup.mAnimationSpeed);
				if(mProgress >= 1)
				{
					mTimer.Stop();
					mTimer.Tick -= new EventHandler(Showing);
					AnimateForm(1);
				}
				else
				{
					AnimateForm(mProgress);
				}
			}

			protected override void OnDeactivate(EventArgs e)
			{
				base.OnDeactivate (e);

                //if(mClosing == false)
                //{
                //    if(this.mPopup.mUserControl is IPopupUserControl)
                //    {
                //        mClosing = ((IPopupUserControl)this.mPopup.mUserControl).AcceptPopupClosing();
                //    }
                //    else
                //    {
                //        mClosing = true;
                //    }

                //    if(mClosing)
                //    {
                //        DoClose();
                //    }
                //}
			}

			protected override void OnPaintBackground(PaintEventArgs pevent)
			{
				pevent.Graphics.DrawRectangle(new Pen(mPopup.mBorderColor), 0, 0, this.Width - 1, this.Height - 1);
			}

			private void SetFinalLocation()
			{
				mProgress = 1;
				AnimateForm(1);
				Invalidate();
			}

			private void AnimateForm(decimal Progress)
			{
				decimal x = 0, y = 0, w = 0, h = 0;

				if(Progress <=Convert.ToDecimal( 0.1))
				{
					Progress =Convert.ToDecimal( 0.1);
				}

				switch(mPlacement)
				{
					case ePlacement.Top:
					case ePlacement.TopLeft:
					case ePlacement.TopRight:
						y = 1 - Progress;
						h = Progress;
						break;
					case ePlacement.Bottom:
					case ePlacement.BottomLeft:
					case ePlacement.BottomRight:
						y = 0;
						h = Progress;
						break;
					case ePlacement.Left:
					case ePlacement.Right:
						y = 0;
						h = 1;
						break;
				}

				switch(mPlacement)
				{
					case ePlacement.TopRight:
					case ePlacement.BottomRight:
					case ePlacement.Right:
						x = 0;
						w = Progress;
						break;
					case ePlacement.TopLeft:
					case ePlacement.BottomLeft:
					case ePlacement.Left:
						x = 1 - Progress;
						w = Progress;
						break;
					case ePlacement.Top:
					case ePlacement.Bottom:
						x = 0;
						w = 1;
						break;
				}
				
				mCurrentBounds.X = mNormalPos.X + (int)(x * mControlSize.Width);
				mCurrentBounds.Y = mNormalPos.Y + (int)(y * mControlSize.Height);
				mCurrentBounds.Width = (int)(w * mControlSize.Width) + 2 * BORDER_MARGIN;
				mCurrentBounds.Height = (int)(h * mControlSize.Height) + 2 * BORDER_MARGIN;
				this.Bounds = mCurrentBounds;
			}

			public void DoClose()
			{
				try
				{
					mPopup.OnDropDownClosed(mPopup.mParent, EventArgs.Empty);
				}
				finally
				{

                    mPopup.mUserControl.Parent = null;
                    mPopup.mUserControl.Size = mControlSize;
                    mPopup.mForm = null;
                    Form parentForm = mPopup.mParent.FindForm();
                    if(parentForm != null)
                    {
                        parentForm.RemoveOwnedForm(this);
                    }
                    //parentForm.Focus();
                    Close();
                    mPopup.bShow = false;

				}
			}
			
			private void mResizingPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				mResizing = false;
				Invalidate();
			}

			private void mResizingPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				if(mResizing)
				{
					Size s = Size;
					s.Width += (e.X - mx);
					s.Height += (e.Y - my);
					this.Size = s;
				}
			}

			private void mResizingPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				if(e.Button == MouseButtons.Left)
				{
					mResizing = true;
					mx = e.X;
					my = e.Y;
				}
			}

			protected override void OnLoad(EventArgs e)
			{
				base.OnLoad(e);
	
				this.Bounds = mCurrentBounds;
			}

			private void DoNothing(object sender, EventArgs e) {}
		}

		protected virtual void OnDropDown(object sender, EventArgs e)
		{
			if(DropDown != null)
			{
				DropDown(sender, e);
			}
		}

		protected virtual void OnDropDownClosed(object sender, EventArgs e)
		{
			if(DropDownClosed != null)
			{
				DropDownClosed(sender, e);
			}
		}

		#region Public properties and events

		public event EventHandler DropDown;
		public event EventHandler DropDownClosed;

		[DefaultValue(false)]
		public bool Resizable
		{
			get
			{
				return mResizable;
			}
			set
			{
				mResizable = value;
			}
		}

		[Browsable(false)]
		public Control UserControl
		{
			get
			{
				return mUserControl;
			}
			set
			{
				mUserControl = value;
			}
		}

		[Browsable(false)]
		public Control Parent
		{
			get
			{
				return mParent;
			}
			set
			{
				mParent = value;
			}
		}

		[DefaultValue(typeof(ePlacement), "BottomLeft")]
		public ePlacement HorizontalPlacement
		{
			get
			{
				return mPlacement;
			}
			set
			{
				mPlacement = value;
			}
		}

		[DefaultValue(typeof(Color), "DarkGray")]
		public Color BorderColor
		{
			get
			{
				return mBorderColor;
			}
			set
			{
				mBorderColor = value;
			}
		}

		[DefaultValue(true)]
		public bool ShowShadow
		{
			get
			{
				return mShowShadow;
			}
			set
			{
				mShowShadow = value;
			}
		}

		[DefaultValue(150)]
		public int AnimationSpeed
		{
			get
			{
				return mAnimationSpeed;
			}
			set
			{
				mAnimationSpeed = value;
			}
		}

		[DefaultValue(1d), TypeConverter(typeof(OpacityConverter))]
		public decimal Opacity
		{
			get
			{
				return mOpacity;
			}
			set
			{
				mOpacity = value;
			}
		}

		#endregion

		public System.Windows.Forms.PictureBox CornerPicture;
		

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LISPop));
			this.CornerPicture = new System.Windows.Forms.PictureBox();

			this.CornerPicture.Image = ((System.Drawing.Image)(resources.GetObject("CornerPicture.Image")));
			this.CornerPicture.Location = new System.Drawing.Point(17, 17);
			this.CornerPicture.Name = "CornerPicture";
			this.CornerPicture.TabIndex = 0;
			this.CornerPicture.TabStop = false;

		}
	}
}
