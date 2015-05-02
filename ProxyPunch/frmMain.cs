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

namespace ProxyPunch
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
			notifyln("UI Initialized.");
			notifyln("Ready to bind a SOCKS IP:PORT to 127.0.0.1:PORT");
		}

		private void notify(string input)
		{
			// txtOutput.Text += input;
			txtOutput.AppendText(input);
		}

		private void ServerAction(string strSocksIP, int socksPort, int localPort)
		{
			Reactor.Loop.Start(System.Threading.SynchronizationContext.Current);
			notifyln("Attempting to connect to proxy server...");

			Reactor.Tcp.Server.Create(LocalListener =>
			{
				notifyln("Local listener created.");

				Reactor.Tcp.Socket ProxyClient = Reactor.Tcp.Socket.Create(strSocksIP, socksPort);
				ProxyClient.OnConnect += () =>
				{
					notifyln(String.Format("Connection established with proxy server {0}:{1}.", strSocksIP, socksPort));

					// route socket data to the local listener.
					LocalListener.OnData += ProxyClient.Write;
					LocalListener.OnEnd += ProxyClient.End;

					// Make sure connection state is reciprocal.
					ProxyClient.OnEnd += LocalListener.End;

					// route local events to the socket.
					ProxyClient.OnData += (data) =>
					{
						LocalListener.Write(data);
						notifyln(data.ToString(Encoding.ASCII));
					};

					ProxyClient.OnError += (error) =>
					{
						LocalListener.End();
						notifyln(String.Format("Connection to proxy server dropped:\n{0}\n", error.Message));
						Reactor.Loop.Stop();
					};

					ProxyClient.OnEnd += () =>
					{
						LocalListener.End();
						notifyln("Connection to proxy server dropped.");
						Reactor.Loop.Stop();
					};

					LocalListener.OnData += (data) =>
					{
						notifyln(data.ToString(Encoding.ASCII));
					};

					LocalListener.OnConnect += () =>
					{
						notifyln(String.Format("Listening on 127.0.0.1:{0}", localPort));
						notifyln("Please point your application's proxy settings to that address.");
					};

					LocalListener.OnError += (error) =>
					{
						ProxyClient.End();
						notifyln(String.Format("Connection on local listener dropped:\n\r{0}\n", error.Message));
						Reactor.Loop.Stop();
					};

					LocalListener.OnEnd += () =>
					{
						notifyln("Connection ended locally.");
						Reactor.Loop.Stop();
					};

				};
			}).Listen(localPort);
			// Reactor.Loop.Stop();
		}

		private void notifyln(string input)
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
			ServerAction(txtSocksIP.Text, Convert.ToInt32(txtSocksPort.Text), Convert.ToInt32(txtLocalPort.Text));
		}

		private void txtOutput_TextChanged(object sender, EventArgs e)
		{
			// scroll to bottom
			txtOutput.SelectionStart = txtOutput.TextLength;
			txtOutput.ScrollToCaret();
			txtOutput.Refresh();
		}
	}
}
