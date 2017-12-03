using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;

namespace asgn5v1
{
	/// <summary>
	/// Summary description for Transformer.
	/// </summary>
	public class Transformer : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
        //private bool GetNewData();

        double centerX = 0;
        double centerY = 0;
        double centerZ = 0;



		// basic data for Transformer

		int numpts = 0;
		int numlines = 0;
		bool gooddata = false;		
		double[,] vertices;
		double[,] scrnpts;
		int button = 0;
		double[,] ctrans = new double[4,4];  //your main transformation matrix
		private System.Windows.Forms.ImageList tbimages;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton transleftbtn;
		private System.Windows.Forms.ToolBarButton transrightbtn;
		private System.Windows.Forms.ToolBarButton transupbtn;
		private System.Windows.Forms.ToolBarButton transdownbtn;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton scaleupbtn;
		private System.Windows.Forms.ToolBarButton scaledownbtn;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton rotxby1btn;
		private System.Windows.Forms.ToolBarButton rotyby1btn;
		private System.Windows.Forms.ToolBarButton rotzby1btn;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton rotxbtn;
		private System.Windows.Forms.ToolBarButton rotybtn;
		private System.Windows.Forms.ToolBarButton rotzbtn;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton shearrightbtn;
		private System.Windows.Forms.ToolBarButton shearleftbtn;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton resetbtn;
		private System.Windows.Forms.ToolBarButton exitbtn;
		private Timer timer1;
		int[,] lines;

		public Transformer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			Text = "COMP 4560:  Assignment 5 (200830) (Hugh A00971421,Nelson A00957058)";
			ResizeRedraw = true;
			BackColor = Color.Black;
			MenuItem miNewDat = new MenuItem("New &Data...",
				new EventHandler(MenuNewDataOnClick));
			MenuItem miExit = new MenuItem("E&xit", 
				new EventHandler(MenuFileExitOnClick));
			MenuItem miDash = new MenuItem("-");
			MenuItem miFile = new MenuItem("&File",
				new MenuItem[] {miNewDat, miDash, miExit});
			MenuItem miAbout = new MenuItem("&About",
				new EventHandler(MenuAboutOnClick));
			Menu = new MainMenu(new MenuItem[] {miFile, miAbout});

			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transformer));
			this.tbimages = new System.Windows.Forms.ImageList(this.components);
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.transleftbtn = new System.Windows.Forms.ToolBarButton();
			this.transrightbtn = new System.Windows.Forms.ToolBarButton();
			this.transupbtn = new System.Windows.Forms.ToolBarButton();
			this.transdownbtn = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.scaleupbtn = new System.Windows.Forms.ToolBarButton();
			this.scaledownbtn = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.rotxby1btn = new System.Windows.Forms.ToolBarButton();
			this.rotyby1btn = new System.Windows.Forms.ToolBarButton();
			this.rotzby1btn = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.rotxbtn = new System.Windows.Forms.ToolBarButton();
			this.rotybtn = new System.Windows.Forms.ToolBarButton();
			this.rotzbtn = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.shearrightbtn = new System.Windows.Forms.ToolBarButton();
			this.shearleftbtn = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.resetbtn = new System.Windows.Forms.ToolBarButton();
			this.exitbtn = new System.Windows.Forms.ToolBarButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// tbimages
			// 
			this.tbimages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tbimages.ImageStream")));
			this.tbimages.TransparentColor = System.Drawing.Color.Transparent;
			this.tbimages.Images.SetKeyName(0, "");
			this.tbimages.Images.SetKeyName(1, "");
			this.tbimages.Images.SetKeyName(2, "");
			this.tbimages.Images.SetKeyName(3, "");
			this.tbimages.Images.SetKeyName(4, "");
			this.tbimages.Images.SetKeyName(5, "");
			this.tbimages.Images.SetKeyName(6, "");
			this.tbimages.Images.SetKeyName(7, "");
			this.tbimages.Images.SetKeyName(8, "");
			this.tbimages.Images.SetKeyName(9, "");
			this.tbimages.Images.SetKeyName(10, "");
			this.tbimages.Images.SetKeyName(11, "");
			this.tbimages.Images.SetKeyName(12, "");
			this.tbimages.Images.SetKeyName(13, "");
			this.tbimages.Images.SetKeyName(14, "");
			this.tbimages.Images.SetKeyName(15, "");
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.transleftbtn,
            this.transrightbtn,
            this.transupbtn,
            this.transdownbtn,
            this.toolBarButton1,
            this.scaleupbtn,
            this.scaledownbtn,
            this.toolBarButton2,
            this.rotxby1btn,
            this.rotyby1btn,
            this.rotzby1btn,
            this.toolBarButton3,
            this.rotxbtn,
            this.rotybtn,
            this.rotzbtn,
            this.toolBarButton4,
            this.shearrightbtn,
            this.shearleftbtn,
            this.toolBarButton5,
            this.resetbtn,
            this.exitbtn});
			this.toolBar1.Dock = System.Windows.Forms.DockStyle.Right;
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.tbimages;
			this.toolBar1.Location = new System.Drawing.Point(484, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(24, 306);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// transleftbtn
			// 
			this.transleftbtn.ImageIndex = 1;
			this.transleftbtn.Name = "transleftbtn";
			this.transleftbtn.ToolTipText = "translate left";
			// 
			// transrightbtn
			// 
			this.transrightbtn.ImageIndex = 0;
			this.transrightbtn.Name = "transrightbtn";
			this.transrightbtn.ToolTipText = "translate right";
			// 
			// transupbtn
			// 
			this.transupbtn.ImageIndex = 2;
			this.transupbtn.Name = "transupbtn";
			this.transupbtn.ToolTipText = "translate up";
			// 
			// transdownbtn
			// 
			this.transdownbtn.ImageIndex = 3;
			this.transdownbtn.Name = "transdownbtn";
			this.transdownbtn.ToolTipText = "translate down";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Name = "toolBarButton1";
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// scaleupbtn
			// 
			this.scaleupbtn.ImageIndex = 4;
			this.scaleupbtn.Name = "scaleupbtn";
			this.scaleupbtn.ToolTipText = "scale up";
			// 
			// scaledownbtn
			// 
			this.scaledownbtn.ImageIndex = 5;
			this.scaledownbtn.Name = "scaledownbtn";
			this.scaledownbtn.ToolTipText = "scale down";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Name = "toolBarButton2";
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// rotxby1btn
			// 
			this.rotxby1btn.ImageIndex = 6;
			this.rotxby1btn.Name = "rotxby1btn";
			this.rotxby1btn.ToolTipText = "rotate about x by 1";
			// 
			// rotyby1btn
			// 
			this.rotyby1btn.ImageIndex = 7;
			this.rotyby1btn.Name = "rotyby1btn";
			this.rotyby1btn.ToolTipText = "rotate about y by 1";
			// 
			// rotzby1btn
			// 
			this.rotzby1btn.ImageIndex = 8;
			this.rotzby1btn.Name = "rotzby1btn";
			this.rotzby1btn.ToolTipText = "rotate about z by 1";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Name = "toolBarButton3";
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// rotxbtn
			// 
			this.rotxbtn.ImageIndex = 9;
			this.rotxbtn.Name = "rotxbtn";
			this.rotxbtn.ToolTipText = "rotate about x continuously";
			// 
			// rotybtn
			// 
			this.rotybtn.ImageIndex = 10;
			this.rotybtn.Name = "rotybtn";
			this.rotybtn.ToolTipText = "rotate about y continuously";
			// 
			// rotzbtn
			// 
			this.rotzbtn.ImageIndex = 11;
			this.rotzbtn.Name = "rotzbtn";
			this.rotzbtn.ToolTipText = "rotate about z continuously";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.Name = "toolBarButton4";
			this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// shearrightbtn
			// 
			this.shearrightbtn.ImageIndex = 12;
			this.shearrightbtn.Name = "shearrightbtn";
			this.shearrightbtn.ToolTipText = "shear right";
			// 
			// shearleftbtn
			// 
			this.shearleftbtn.ImageIndex = 13;
			this.shearleftbtn.Name = "shearleftbtn";
			this.shearleftbtn.ToolTipText = "shear left";
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.Name = "toolBarButton5";
			this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// resetbtn
			// 
			this.resetbtn.ImageIndex = 14;
			this.resetbtn.Name = "resetbtn";
			this.resetbtn.ToolTipText = "restore the initial image";
			// 
			// exitbtn
			// 
			this.exitbtn.ImageIndex = 15;
			this.exitbtn.Name = "exitbtn";
			this.exitbtn.ToolTipText = "exit the program";
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Transformer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(508, 306);
			this.Controls.Add(this.toolBar1);
			this.Name = "Transformer";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Transformer_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Transformer());
		}

        private void translatation(double x,double y,double z)
        {
            int k;
            double temp;
            double[,] transMatrix = new double[4, 4];
            double[,] newCtrans = new double[4, 4];
            setIdentity(transMatrix, 4, 4);
            transMatrix[3, 0] = x;
            transMatrix[3, 1] = y;
            transMatrix[3, 2] = z;

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    temp = 0.0d;
                    for (k = 0; k < 4; k++)
                        temp += ctrans[i, k] * transMatrix[k, j];
                    newCtrans[i, j] = temp;
                }
            }
            ctrans = newCtrans;
        }		
        private void scale(double xfactor,double yfactor,double zfactor)
        {
            int k;
            double temp;
            double[,] scaleMatrix = new double[4, 4];
            double[,] newCtrans = new double[4, 4];
            setIdentity(scaleMatrix, 4, 4);
            scaleMatrix[0, 0] = scaleMatrix[0, 0] * xfactor;
            scaleMatrix[1, 1] = scaleMatrix[1, 1] * yfactor;
            scaleMatrix[2, 2] = scaleMatrix[2, 2] * zfactor;

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    temp = 0.0d;
                    for (k = 0; k < 4; k++)
                        temp += ctrans[i, k] * scaleMatrix[k, j];
                    newCtrans[i, j] = temp;
                }
            }
            ctrans = newCtrans;
        }

        private void shearX(double sf) {
            double X = scrnpts[17, 0];
            double Y = scrnpts[17, 1];
            double Z = scrnpts[17, 2];
            int k;
            double temp;
            double[,] shearx = new double[4, 4];
            double[,] newCtrans = new double[4, 4];
            setIdentity(shearx, 4, 4);
            shearx[1, 0] = sf;
            translatation(-X, -Y, -Z);

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    temp = 0.0d;
                    for (k = 0; k < 4; k++)
                        temp += ctrans[i, k] * shearx[k, j];
                    newCtrans[i, j] = temp;
                }
            }
            ctrans = newCtrans;
            translatation(X, Y, Z);
        }

        private void rotateX(double radians) {
            int k;
            double temp;
            double[,] rotateX = new double[4, 4];
            double[,] newCtrans = new double[4, 4];
            setIdentity(rotateX, 4, 4);
            rotateX[1, 1] = Math.Cos(radians);
            rotateX[1, 2] = -Math.Sin(radians);
            rotateX[2, 1] = Math.Sin(radians);
            rotateX[2, 2] = Math.Cos(radians);

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    temp = 0.0d;
                    for (k = 0; k < 4; k++)
                        temp += ctrans[i, k] * rotateX[k, j];
                    newCtrans[i, j] = temp;
                }
            }
            ctrans = newCtrans;
        }

        private void rotateY(double radians) {
            int k;
            double temp;
            double[,] rotateY = new double[4, 4];
            double[,] newCtrans = new double[4, 4];
            setIdentity(rotateY, 4, 4);
            rotateY[0, 0] = Math.Cos(radians);
            rotateY[0, 2] = -Math.Sin(radians);
            rotateY[2, 0] = Math.Sin(radians);
            rotateY[2, 2] = Math.Cos(radians);

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    temp = 0.0d;
                    for (k = 0; k < 4; k++)
                        temp += ctrans[i, k] * rotateY[k, j];
                    newCtrans[i, j] = temp;
                }
            }
            ctrans = newCtrans;
        }

        private void rotateZ(double radians) {
            int k;
            double temp;
            double[,] rotateZ = new double[4, 4];
            double[,] newCtrans = new double[4, 4];
            setIdentity(rotateZ, 4, 4);
            rotateZ[0, 0] = Math.Cos(radians);
            rotateZ[0, 1] = Math.Sin(radians);
            rotateZ[1, 0] = -Math.Sin(radians);
            rotateZ[1, 1] = Math.Cos(radians);

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    temp = 0.0d;
                    for (k = 0; k < 4; k++) { 
                        temp += ctrans[i, k] * rotateZ[k, j];
                    }
                    newCtrans[i, j] = temp;
                }
            }
            ctrans = newCtrans;
        }

		private void moveToOrigin()
		{
			centerX = scrnpts[0, 0];
			centerY = scrnpts[0, 1];
			centerZ = scrnpts[0, 2];
			translatation(-centerX, -centerY, -centerZ);
		}

		private void InitializeObject()
        {
			double maxY = 0;
			double minY = scrnpts[0, 1];
			double height = 0;
			double n = 0;
			for (int i = 0; i < numpts; i++)
			{
				if (vertices[i, 1] > maxY)
				{
					maxY = vertices[i, 1];
				}

				if (vertices[i, 1] < minY)
				{
					minY = vertices[i, 1];
				}

				//Console.WriteLine("Y: " + scrnpts[i, 1]);
			}
			height = maxY - minY;
			double windowWidth = this.Width;
			double windowHeight = this.Height;

			n = windowHeight / 2 / height;
			//move the centoid to origin
			translatation(-centerX, -centerY, -centerZ);

            //rotate 90 degree aroung z axis
            rotateZ(Math.PI / 2);

            //universal scale 20 times 
            scale(n, n, n);

			Console.WriteLine("max: " + maxY + "  height is : " + height);

			//shearX(-1.5);

			//find out the width and height of the form window 
			

            //move the centroid to the screen center
            translatation(windowWidth / 2, windowHeight / 2, 0);

        }

        protected override void OnPaint(PaintEventArgs pea)
		{
			Graphics grfx = pea.Graphics;
            Pen pen = new Pen(Color.White, 3);
			double temp;
			int k;
            

            if (gooddata)
            {
                //create the screen coordinates:
                // scrnpts = vertices*ctrans

                for (int i = 0; i < numpts; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        temp = 0.0d;
                        for (k = 0; k < 4; k++)
                            temp += vertices[i, k] * ctrans[k, j];
                        scrnpts[i, j] = temp;
                    }
                }

                //now draw the lines

                for (int i = 0; i < numlines; i++)
                {
                    grfx.DrawLine(pen, (int)scrnpts[lines[i, 0], 0], (int)scrnpts[lines[i, 0], 1],
                        (int)scrnpts[lines[i, 1], 0], (int)scrnpts[lines[i, 1], 1]);
                }


            } // end of gooddata block	
		} // end of OnPaint

		void MenuNewDataOnClick(object obj, EventArgs ea)
		{
			//MessageBox.Show("New Data item clicked.");
			gooddata = GetNewData();
			RestoreInitialImage();
			InitializeObject();
			
		}

		void MenuFileExitOnClick(object obj, EventArgs ea)
		{
			Close();
		}

		void MenuAboutOnClick(object obj, EventArgs ea)
		{
			AboutDialogBox dlg = new AboutDialogBox();
			dlg.ShowDialog();
		}

		void RestoreInitialImage()
		{
            
            Invalidate();
		} // end of RestoreInitialImage

		bool GetNewData()
		{
			string strinputfile,text;
			ArrayList coorddata = new ArrayList();
			ArrayList linesdata = new ArrayList();
			OpenFileDialog opendlg = new OpenFileDialog();
			opendlg.Title = "Choose File with Coordinates of Vertices";
			if (opendlg.ShowDialog() == DialogResult.OK)
			{
				strinputfile=opendlg.FileName;				
				FileInfo coordfile = new FileInfo(strinputfile);
				StreamReader reader = coordfile.OpenText();
				do
				{
					text = reader.ReadLine();
					if (text != null) coorddata.Add(text);
				} while (text != null);
				reader.Close();
				DecodeCoords(coorddata);
			}
			else
			{
				MessageBox.Show("***Failed to Open Coordinates File***");
				return false;
			}
            
			opendlg.Title = "Choose File with Data Specifying Lines";
			if (opendlg.ShowDialog() == DialogResult.OK)
			{
				strinputfile=opendlg.FileName;
				FileInfo linesfile = new FileInfo(strinputfile);
				StreamReader reader = linesfile.OpenText();
				do
				{
					text = reader.ReadLine();
					if (text != null) linesdata.Add(text);
				} while (text != null);
				reader.Close();
				DecodeLines(linesdata);
			}
			else
			{
				MessageBox.Show("***Failed to Open Line Data File***");
				return false;
			}
			scrnpts = new double[numpts,4];
			setIdentity(ctrans,4,4);  //initialize transformation matrix to identity

        /*
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    Console.Write(ctrans[i, j]);
                }
                Console.WriteLine();  
            }
       */

            return true;
		} // end of GetNewData

		void DecodeCoords(ArrayList coorddata)
		{
			//this may allocate slightly more rows that necessary
			vertices = new double[coorddata.Count,4];
			numpts = 0;
			string [] text = null;
			for (int i = 0; i < coorddata.Count; i++)
			{
				text = coorddata[i].ToString().Split(' ',',');
				vertices[numpts,0]=double.Parse(text[0]);
				if (vertices[numpts,0] < 0.0d) break;
				vertices[numpts,1]=double.Parse(text[1]);
				vertices[numpts,2]=double.Parse(text[2]);
				vertices[numpts,3] = 1.0d;
				numpts++;						
			}

            // initialize shape data
            centerX = vertices[0, 0];
            centerY = vertices[0, 1];
            centerZ = vertices[0, 2];
        }// end of DecodeCoords

		void DecodeLines(ArrayList linesdata)
		{
			//this may allocate slightly more rows that necessary
			lines = new int[linesdata.Count,2];
			numlines = 0;
			string [] text = null;
			for (int i = 0; i < linesdata.Count; i++)
			{
				text = linesdata[i].ToString().Split(' ',',');
				lines[numlines,0]=int.Parse(text[0]);
				if (lines[numlines,0] < 0) break;
				lines[numlines,1]=int.Parse(text[1]);
				numlines++;						
			}
		} // end of DecodeLines

		void setIdentity(double[,] A,int nrow,int ncol)
		{
			for (int i = 0; i < nrow;i++) 
			{
				for (int j = 0; j < ncol; j++) A[i,j] = 0.0d;
				A[i,i] = 1.0d;
			}
		}// end of setIdentity
      

		private void Transformer_Load(object sender, System.EventArgs e)
		{
			
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == transleftbtn)
			{
				timer1.Stop();
				translatation(-75d, 0, 0);
				Refresh();
			}
			if (e.Button == transrightbtn) 
			{
				timer1.Stop();
				translatation(75d, 0, 0);
				Refresh();
			}
			if (e.Button == transupbtn)
			{
				timer1.Stop();
				translatation(0, -35d, 0);
				Refresh();
			}
			
			if(e.Button == transdownbtn)
			{
				timer1.Stop();
				translatation(0, 35d, 0);
				Refresh();
			}
			if (e.Button == scaleupbtn) 
			{
				timer1.Stop();
				centerX = scrnpts[0, 0];
				centerY = scrnpts[0, 1];
				centerZ = scrnpts[0, 2];
				translatation(-centerX, -centerY, -centerZ);
				scale(1.1, 1.1, 1.1);
				translatation(centerX, centerY, centerZ);
				Refresh();
			}
			if (e.Button == scaledownbtn) 
			{
				timer1.Stop();
				centerX = scrnpts[0, 0];
				centerY = scrnpts[0, 1];
				centerZ = scrnpts[0, 2];

				translatation(-centerX, -centerY, -centerZ);
				scale(0.9, 0.9, 0.9);
				translatation(centerX, centerY, centerZ);
				Refresh();
			}
			if (e.Button == rotxby1btn) 
			{
				timer1.Stop();
				moveToOrigin();
				rotateX(0.05);
				translatation(centerX, centerY, centerZ);
				Refresh();
			}
			if (e.Button == rotyby1btn) 
			{
				timer1.Stop();
				moveToOrigin();
				rotateY(0.05);
				translatation(centerX, centerY, centerZ);
				Refresh();
			}
			if (e.Button == rotzby1btn) 
			{
				timer1.Stop();
				moveToOrigin();
				rotateZ(0.05);
				translatation(centerX, centerY, centerZ);
				Refresh(); 
			}

			if (e.Button == rotxbtn) 
			{
				button = 1;
				timer1.Stop();
				timer1.Start();
			}
			if (e.Button == rotybtn) 
			{
				button = 2;
				timer1.Stop();
				timer1.Start();
			}
			
			if (e.Button == rotzbtn) 
			{
				button = 3;
				timer1.Stop();
				timer1.Start();
			}

			if(e.Button == shearleftbtn)
			{
                shearX(-0.1);
                timer1.Stop();
                Refresh();
            }

			if (e.Button == shearrightbtn) 
			{
                shearX(0.1);
                timer1.Stop();
                //shearX(1.1);
                Refresh();
            }

			if (e.Button == resetbtn)
			{

                setIdentity(ctrans,4,4);
                InitializeObject();
                Refresh();
                //RestoreInitialImage();
			}

			if(e.Button == exitbtn) 
			{
				Close();
			}

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			moveToOrigin();
			if (button == 1)
			{
				rotateX(0.05d);
			}
			else if (button == 2)
			{
				rotateY(0.05d);
			}
			else if (button == 3)
			{
				rotateZ(0.05d);
			}
			translatation(centerX, centerY, centerZ);
			timer1.Enabled = true;
			Refresh();
		}
	}

	
}
