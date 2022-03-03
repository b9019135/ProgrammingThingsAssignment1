using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ConnorJenkins_ZumoGUI_ProgrmamingTHings
{
    public partial class Form1 : Form
    {

        string serialDataInput; // Receiving from the zumo robot

        private System.Windows.Forms.Timer labelchange; //used to change the labels involing turning.

        public Form1()
        {
            InitializeComponent();

            labelchange = new Timer { Interval = 5000 };
            labelchange.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); //Pulling the available port names for selection.
            CBoxComPort.Items.AddRange(ports);

            btnClose.Enabled = false; //If a port isn't open the close button is disabled.
            btnOpen.Enabled = true; //if a port isn't open the open button is enabled.
            lblStatus.Text = "Disconnected"; //Disconnected is shown when no connection has been made.
            lblAction.Text = "Awaiting"; //awaiting is displaed by default on the lable.

            CBoxBaudRate.Text = "9600"; //The default baud rate displayed is 9600.
        }

        private void btnOpen_Click(object sender, EventArgs e) //opening a connection.
        {
            try
            {
                serialPort1.PortName = CBoxComPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(CBoxBaudRate.Text);

                serialPort1.Open();


                btnClose.Enabled = true; //If a port is open the close button is enabled
                btnOpen.Enabled = false; //If a port is open the open button is disabled
                lblStatus.Text = "connected"; //Connected is shown if a port has been connected.

            }

            catch(Exception err)
            {
                MessageBox.Show(err.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // An error is shown if no port is selected. Or if the baud rate is unavailable. 
            }

        }

        private void btnClose_Click(object sender, EventArgs e) //closing a connection
        {

            try
            {
                serialPort1.Close(); //closes the current opened serialport.


                btnClose.Enabled = false;
                btnOpen.Enabled = true;
                lblStatus.Text = "Diconnected"; //disconnected is shown if no connected has been made.
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //Form closing.
        {
            if(serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Close(); //To ensure safety, upon closing the form the port is automaticlly closed.
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btnForward_Click(object sender, EventArgs e) //Zumo interaction - Moves the zumo forward
        {
            try
            {

                serialPort1.Write("f"); //code f is set through the serial port and is read by the zumo. This code represents forward.
                lblAction.Text = "Moving Forward"; //Moving forward is printed into the currentaction box.

            } catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e) //receiving data from the serial port.
        {
            serialDataInput = serialPort1.ReadExisting(); //the data is read in and assigned to the variable serialdatainput.
           this.Invoke(new EventHandler(ShowData)); //this data is passed into ShowData below.
        }

        private void ShowData(object sender, EventArgs e) //Responsible for displaying messages within the action and room log boxes.
        {
            // RTBoxReceive.Select(0, 0);
            //RTBoxReceive.SelectedText = serialDataInput + Environment.NewLine;

            bool empty = true;
            int roomid = 0;

            switch (serialDataInput) //A switch case is used, depending on the serial data read in, different outcomes occur.
            {
                case "1": //code 1 represents a wall has been detected, and as such the wall detected message is shown.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "Wall Detected! Please select a direction to travel" + Environment.NewLine;
                    actionpopup();
                    break;
                case "2": //code 2 represents the zumo moving forward. Upon receiving code 2, moving foward is displayed in the action box.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "Moving Foward" + Environment.NewLine;
                    break;
                case "3": //code 3 represents the zumo moving backwards. Upon receiving code 3, moving backwards is displayed in the action box.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "Moving Backwards" + Environment.NewLine;
                    break;
                case "4": //code 4 represents the zumo turning left. Upon receiving code 4, turning left is displayed in the action box.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "Turning Left" + Environment.NewLine;
                    break;
                case "5": //code 5 represents the zumo turning right. Upon receiving code 5, turning right is displayed in the action box.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "Turning Right" + Environment.NewLine;
                    break;
                case "6": //code 6 represents the zumo turning stopping. Upon receiving code 6, stopped is displayed in the action box.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "Stopped" + Environment.NewLine;
                    break;
                case "8": //code 8 represents the zumo turning stopping for a room. Upon receiving code 8, the message below is displayed.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "Stopped for a room" + Environment.NewLine;
                    roomid++;
                    break;
                case "9": //code 9 represents searching a room.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "Searching a Room" + Environment.NewLine;
                    break;
                case "o": //code o represents an object has been found.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "Object Found" + Environment.NewLine;
                    break;
                case "p": //code p represents no objects found.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "No Object Found" + Environment.NewLine;
                    break;
                case "h": //code h represents a scan has been completed.
                    RTBoxReceive.Select(0, 0);
                    RTBoxReceive.SelectedText = "Scan Complete" + Environment.NewLine;
                    
                    RTBRoomLog.Select(0, 0);
                    RTBRoomLog.SelectedText = "RoomID: " + roomid++ + "Empty: " + empty.ToString() + Environment.NewLine;
                    //Once a scan has been completed, a new log is added. This conists of a roomID, and whether or not the room was empty.
                    break;
                default:
                    break;
            }
        }


        private void RTBoxReceive_TextChanged(object sender, EventArgs e)
        {
            RTBoxReceive.SelectionStart = RTBoxReceive.Text.Length;
            //RTBoxReceive.ScrollToCaret();
        }


        private void actionpopup() //Zumo interaction - upon encourtering a wall, a popup box appears alerting the user. They are provided with 3 actions.
        {
            DialogResult UA = MessageBox.Show("Zumo robot has encountered a wall, please select a direction. \n Yes = Right \n No = Left \n Cancel = Stop ", "WALL DETECTED", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                
                if(UA == DialogResult.Yes)
                {
                    btnRight.PerformClick(); //simulates a button click on the turn right button.
                    serialPort1.Write("7"); //resets the walldetection. code 7 = reset wall detection
                    serialPort1.Write("a"); //continues the automatic process. code a = Automatic process.
            }
                
                if(UA == DialogResult.No)
                {
                    btnLeft.PerformClick(); //simulates a button click on the turn left button.
                    serialPort1.Write("7"); //resets the walldetection. code 7 = reset wall detection
                    serialPort1.Write("a"); //continues the automatic process. code a = Automatic process.
            }

                if(UA == DialogResult.Cancel)
            {
                btnSTOP.PerformClick(); //simulates a button click on the turn stop button.
                serialPort1.Write("6"); // stops the zumo. Code 6 = stopping.
                serialPort1.Write("7"); //resets the walldetection. Code 7 = reset wall detection.
            }
        }

        private void RoomPopUp() //Zumo interaction - Upon stopping for a room, the user is provided with the options to turn left or right.
        {
            DialogResult UA = MessageBox.Show("Zumo robot has Stopped for a room, please select a direction. \n Yes = Right \n No = Left  ", "ROOM DETECTED", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (UA == DialogResult.Yes)
            {
                btnRight.PerformClick(); //simulates a button click on the turn right button.
                serialPort1.Write("10"); //Upon making a right turn, the serial code 10 is made for a right turn.
                //This will be used to allow the robot to automatically return to the path.

            }

            if (UA == DialogResult.No)
            {
                btnLeft.PerformClick(); //simulates a button click on the turn left button.
                serialPort1.Write("11"); //Upon making a right turn, the serial code 11 is made for a left turn.
                //This will be used to allow the robot to automatically return to the path.
            }
        }
        private void btnLeft_Click(object sender, EventArgs e) //Zumo interaction - Turn left
        {
            try
            {

                serialPort1.Write("l"); //Code l = left turn.
                lblAction.Text = "Turning Left"; //Turning left is displayed

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnRight_Click(object sender, EventArgs e) //Zumo interaction - Turn right.
        {
            try
            {
                 
                serialPort1.Write("r"); //Code r = right turn
                lblAction.Text = "Turning Right"; //Turning right is displayed

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSTOP_Click(object sender, EventArgs e) //Zumo interaction - stop
        {
            try
            {

                serialPort1.Write("s"); //code s = stop
                lblAction.Text = "Stopped";

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)  //Zumo interaction - reverse
        {
            try
            {

                serialPort1.Write("b"); //code b = reverse
                lblAction.Text = "Reversing";

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnAutomatic_Click(object sender, EventArgs e)  //Zumo interaction - automatic.
        {
            try
            {
                serialPort1.Write("a");
                lblAction.Text = "Automatic";

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //Keyboard inputs for buttons. Allows the zumo to be controlled with keyboard.
        {
            switch(keyData)
            {
                case Keys.W:
                    btnForward.PerformClick();
                    return true;
                case Keys.A:
                    btnLeft.PerformClick();
                    return true;
                case Keys.D:
                    btnRight.PerformClick();
                    return true;
                case Keys.S:
                    btnBack.PerformClick();
                    return true;
                case Keys.Space:
                    btnSTOP.PerformClick();
                    return true;
                case Keys.Q:
                    btnAutomatic.PerformClick();
                    return true;
                case Keys.E:
                    btnStopForRoom.PerformClick();
                    return true;
                case Keys.R:
                    btnSearchRoom.PerformClick();
                    return true;
                case Keys.F:
                    btnReturn.PerformClick();
                        return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void btnStopForRoom_Click(object sender, EventArgs e)  //Zumo interaction - stop for a room.
        {
            try
            {
                serialPort1.Write("8"); //input code 8 = Stop for a room.
                lblAction.Text = "Stopped for Room"; 
                RoomPopUp();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void RTBRoomLog_TextChanged(object sender, EventArgs e) 
        {
            RTBRoomLog.SelectionStart = RTBoxReceive.Text.Length;
        }

        private void btnSearchRoom_Click_1(object sender, EventArgs e)  //Zumo interaction - search a room
        {
            try
            {
                serialPort1.Write("9"); // input code 9 = search a room.
                lblAction.Text = "SearchingRoom"; 

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e) //Zumo interaction - return after reaching T junction end.
        {
            try
            {
                serialPort1.Write("v"); //input code v = return.
                lblAction.Text = "Returning"; 

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
