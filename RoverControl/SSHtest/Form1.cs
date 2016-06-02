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
using System.Collections;
using System.Threading;
using System.Net.Sockets;


// This application uses the Sharp SSH library to connect to Rover
namespace RoverControl
{
    public partial class Form1 : Form
    {
        
        const int CommandLimit = 15; //Maximum Number of commands in the command List
        DialogCustom CM;
        UdpClient sendClient;
        System.Net.IPEndPoint ep;
        bool sendstate;

        public Form1()
        {
            InitializeComponent();
            SendState(false);
            SndRcv_Wrkr.WorkerReportsProgress = true;
            SndRcv_Wrkr.WorkerSupportsCancellation = true;
            lbl_Conn.Hide();
            CM = new DialogCustom();
            sendClient = new UdpClient("192.168.0.104", 8888);
            ep = new System.Net.IPEndPoint(System.Net.IPAddress.Parse("192.168.0.104"), 0);
            sendClient.Client.ReceiveTimeout=10000;
            
        }

        #region Events

        /// <summary>
        /// Begins the sending of commands to the Rover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbx_Commands.Items.Count != 0)
                {
                    SendState(true);
                    //tb_Console.Clear();
                    //tb_Console.AppendText("Connecting" + Environment.NewLine);
                    string[] temp = new string[] { }; //Temporary list for passing the commands on to the backgroundworker
                    Array.Resize(ref temp, lbx_Commands.Items.Count); //Resize list to size of command list
                    lbx_Commands.Items.CopyTo(temp, 0); //Copy commands over
                    SndRcv_Wrkr.RunWorkerAsync(temp); //Begin background process of sending commands
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unexpected Error");
            }
            
        }

        /// <summary>
        /// Event for when kid presses buttons. Takes picturebox name and builds the list
        /// based off which picture is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {

            
            if (lbx_Commands.Items.Count < CommandLimit) //Prevents more that 15 commands in the list
            {
                switch ((sender as PictureBox).Name.Split('_').Last())
                {
                    case ("Forward"):
                        lbx_Commands.Items.Add("Forward");
                        break;
                    case ("Reverse"):
                        lbx_Commands.Items.Add("Reverse");
                        break;
                    case ("TurnLeft"):
                        lbx_Commands.Items.Add("Turn_Left");
                        break;
                    case ("TurnRight"):
                        lbx_Commands.Items.Add("Turn_Right");
                        break;
                    case ("SlideLeft"):
                        lbx_Commands.Items.Add("Slide_Left");
                        break;
                    case ("SlideRight"):
                        lbx_Commands.Items.Add("Slide_Right");
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Connects to Rover via SSH stream
        /// </summary>
        /// <returns></returns>
        public bool Connect ()
        {
            try
            {

                sendClient.Send(ASCIIEncoding.ASCII.GetBytes("R"), ASCIIEncoding.ASCII.GetBytes("R").Length);
                string response = ASCIIEncoding.ASCII.GetString(sendClient.Receive(ref ep));

                    if (response == "R")
                    {
                        return true;
                    }   
            }

            catch (Exception ex)
            {
                //tb_Console.Text = "Rover Did Not Respond";
                return false;
                
            }
            return false;
        }
        

        /// <summary>
        /// Locks out certian buttons while sending commands. 
        /// During sending, only abort is enabled.
        /// During not sending, everything but abort is enabled.
        /// </summary>
        /// <param name="state"></param>
        private void SendState(bool state)
        {
            
            btn_send.Enabled = (!state);

            btn_Forward.Enabled = (!state);
            btn_Reverse.Enabled = (!state);
            btn_SlideLeft.Enabled = (!state);
            btn_SlideRight.Enabled = (!state);
            btn_TurnLeft.Enabled = (!state);
            btn_TurnRight.Enabled = (!state);
            sendstate = state;
            
        }


        #endregion

        #region SndRcvWorkerCode
        /// <summary>
        /// Main working code of background worker. Connects to the Rover, sends commands, and updates front panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SndRcv_Wrkr_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SndRcv_Wrkr.ReportProgress(0, "Connecting");
                string[] commands = (string[])e.Argument; //Get the list of commands out of the passed parameter
                string Comm = "";
                string response = "C"; //Must be C. Otherwise code will not run loop. Each iteration looks for a value of 'C' to know the last command is complete.
                
                Thread.Sleep(50);
                if (Connect()) //Create connection and continue if the connection is good
                {
                    SndRcv_Wrkr.ReportProgress(0, "Connection Ready"); //Tell front panel connection is good
                    foreach(string command in commands) //Iterate through all the commands
                    {
                        if (SndRcv_Wrkr.CancellationPending == false) // Cancel if requested
                        {
                            if (response == "C") // Continue if last command is complete
                            {
                                try // Proper Error Handling
                                {
                                    switch (command) // Check the command to be sent and translate it to a single character for Arduino
                                    {
                                        case ("Forward"):
                                            Comm = "W";
                                            break;
                                        case ("Reverse"):
                                            Comm = "S";
                                            break;
                                        case ("Turn_Left"):
                                            Comm = "Q";
                                            break;
                                        case ("Turn_Right"):
                                            Comm = "E";
                                            break;
                                        case ("Slide_Left"):
                                            Comm = "A";
                                            break;
                                        case ("Slide_Right"):
                                            Comm = "D";
                                            break;
                                        default:
                                            break;
                                    }
                                    sendClient.Send(ASCIIEncoding.ASCII.GetBytes(Comm), ASCIIEncoding.ASCII.GetBytes(Comm).Length);
                                    //shell.Write(Comm); //Send Command
                                    //SndRcv_Wrkr.ReportProgress(0, "Sent: " + command + Environment.NewLine); //Update front panel
                                    response = ASCIIEncoding.ASCII.GetString( sendClient.Receive(ref ep)); // Get the important character out of the response
                                    switch (response) // Check the Response Character 
                                    {
                                        case "C": //Command Complete
                                            //SndRcv_Wrkr.ReportProgress(0, "Received: Complete" + Environment.NewLine); //Update Front Panel
                                            SndRcv_Wrkr.ReportProgress(0, "Next");
                                            e.Result = "Complete"; //Set Ending value
                                            System.Threading.Thread.Sleep(500);
                                            break;
                                        case "O": //Obstacle Detected
                                            //SndRcv_Wrkr.ReportProgress(0, "Obstacle Detected; Program Aborted" + Environment.NewLine);//Update Front Panel
                                            e.Result = "Obstacle Detected; Program Aborted";//Set Ending value
                                            SndRcv_Wrkr.CancelAsync(); //Request Cancellation
                                            break;
                                        default: //Anything Else
                                            //SndRcv_Wrkr.ReportProgress(0, "Unexpected Error" + Environment.NewLine);//Update Front Panel
                                            e.Result = "Unexpected Error";//Set Ending value
                                            SndRcv_Wrkr.CancelAsync();//Request Cancellation
                                            break;
                                    }


                                }
                                //Catch a thrown error so the program can continue
                                catch (Exception exc)
                                {
                                    throw new Exception("Rover Did Not Respond");
                                }
                            }
                            //If the return character is not 'C', escape loop
                            else
                            {
                               break;
                            }

                        }
                        //If cancellation was request, escape loop
                        else
                        {
                            if (e.Result.ToString() == "Obstacle Detected; Program Aborted") //Special Case
                                throw new Exception(e.Result.ToString());

                            else
                                throw new Exception("Program Aborted");
                        }

                    }
                    
                }
                //If connection usuccessful, escape thread
                else
                {
                    throw new Exception("Connection Failed");
                }
            }
            //Catch and pass error
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        /// <summary>
        /// Update Front panel bassed on string passed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SndRcv_Wrkr_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Update the front panel
            try
            {
                switch (e.UserState.ToString())
                {
                    case "Next": if (lbx_Commands.SelectedIndex < lbx_Commands.Items.Count -1 ) lbx_Commands.SelectedIndex += 1; break;
                    case "Connecting": lbl_Conn.Show(); break;
                    case "Connection Ready": lbx_Commands.SelectedIndex = 0; lbl_Conn.Hide(); break;
                    
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Unexpected Error");
            }
        }

        /// <summary>
        /// Happens when the worker is finished working. Clears and updates panel. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SndRcv_Wrkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result.ToString() != "Connection Failed")
                {
                    if (e.Result.ToString() == "Obstacle Detected; Program Aborted")
                        CM.ShowDiag("Obstacle Detected; Program Aborted");
                    
                    lbx_Commands.Items.Clear();
                    SendState(false);

                }
                else
                {
                    lbx_Commands.Items.Clear();
                    CM.ShowDiag(e.Result.ToString()+ Environment.NewLine + "Please Try Again");
                    lbl_Conn.Hide();
                    SendState(false);
                }
            }
            catch (Exception ex)
            {
                lbx_Commands.Items.Clear();
                SendState(false);

            }
            
        }

        /// <summary>
        /// Used to request cancellation on the worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Abort_Click(object sender, EventArgs e)
        {
            if (sendstate)
                SndRcv_Wrkr.CancelAsync();
            else
                lbx_Commands.Items.Clear();
        }
        #endregion 


    }   
}
