using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ProxyPunch
{
	public partial class frmMain : Form
	{
		public string ProxyEndpoint
		{
			get { return txtSocksIP.Text; }
		}

		public string ProxyPort
		{
			get { return txtSocksPort.Text; }
		}

		public string LocalPort
		{
			get { return txtLocalPort.Text; }
		}

		public string LogLine
		{
			set { txtOutput.AppendText(value + Environment.NewLine); }
		}

		public static frmMain _formHandle;

		public frmMain()
		{
			InitializeComponent();
			notifyln("UI Initialized.");
			_formHandle = this;

			notifyln("Ready to bind a SOCKS IP:PORT to 127.0.0.1:PORT");
		}

		public void notifyln(string input)
		{
			txtOutput.AppendText(input + Environment.NewLine);
		}

		// some basic byte/string conversion tricks
		static byte[] GetBytes(string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		static string GetString(byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}

		private void btnBind_Click(object sender, EventArgs e)
		{
			if ( txtSocksIP.Text.Equals("") | txtSocksPort.Text.Equals("") | txtLocalPort.Text.Equals("") )
			{
				notifyln("You've entered incorrect values.  Please try again.");
			}
			else
			{
				// ServerAction(txtSocksIP.Text, Convert.ToInt32(txtSocksPort.Text), Convert.ToInt32(txtLocalPort.Text));
				TSocket ThisSocket = new TSocket(_formHandle);
				ThisSocket.CreateListener(1234);
			}
		}

		private void txtOutput_TextChanged(object sender, EventArgs e)
		{
			// scroll to bottom
			txtOutput.SelectionStart = txtOutput.TextLength;
			txtOutput.ScrollToCaret();
			txtOutput.Refresh();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{

		}
	}

	public class TSocket
	{

		public static IPAddress LOCALHOST = IPAddress.Parse("127.0.0.1");

		public static ManualResetEvent tcpClientConnected = new ManualResetEvent(false);

		// using the class constructor to interface with the form fields

		private readonly frmMain form;

		public TSocket(frmMain form)
		{
			this.form = form;
		}

		// this will cause a threading issue from different threads....
		public void log (string entry)
		{
			form.LogLine = entry;
		}

		public void CreateListener(int ListenerPort)
		{
			log( "Creating a listener socket..." );
			TcpListener LocalListener = new TcpListener(LOCALHOST, ListenerPort);
			log( "Listener socket created." );

			log( "Starting socket..." );
			LocalListener.Start();

			DoBeginAcceptTcpClient(LocalListener);

			// Byte[] bytes = new Byte[256];
			// String data = null;

		}

		public void DoBeginAcceptTcpClient(TcpListener listener)
		{
			// Set the event to nonsignaled state.
			tcpClientConnected.Reset();

			// Start to listen for connections from a client.
			log( "Waiting for a connection..." );

			// Accept the connection.
			// BeginAcceptSocket() creates the accepted socket.
			listener.BeginAcceptTcpClient( new AsyncCallback( DoAcceptTcpClientCallback ), listener );
			log( String.Format( "Listening on {0}:{1}", LOCALHOST, ( (IPEndPoint)listener.LocalEndpoint ).Port.ToString() ) );

			// Wait until a connection is made and processed before
			// continuing.
			tcpClientConnected.WaitOne();
		}

		// Process the client connection.
		public void DoAcceptTcpClientCallback(IAsyncResult ar)
		{
			// Get the listener that handles the client request.
			TcpListener listener = (TcpListener)ar.AsyncState;

			// End the operation and display the received data on
			// the console.
			TcpClient client = listener.EndAcceptTcpClient(ar);

			// Process the connection here. (Add the client to a
			// server table, read data, etc.)
			form.LogLine = "Client connected completed";

			// Signal the calling thread to continue.
			tcpClientConnected.Set();
		}




	}
}
