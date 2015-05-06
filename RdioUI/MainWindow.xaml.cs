using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Resources;
using RdioNet;

namespace RdioUI
{
	/// <summary>
	///     Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string _playbackToken;

		public MainWindow()
		{
			InitializeComponent();
			//Browser.LoadCompleted += (sender, args) => { Browser.InvokeScript("play", new object[] {"notThere"}); };
			var htmlResource = Application.GetResourceStream(new Uri("/player.html", UriKind.Relative));
			if (htmlResource != null) this.Browser.NavigateToStream(htmlResource.Stream);


			Loaded += (sender, args) => { ThreadPool.QueueUserWorkItem(state => { callRdio(); }); };
		}

		private void callRdio()
		{
			//var consumerKey = ConfigurationManager.AppSettings["consumerKey"];
			//var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
			//var accessToken = ConfigurationManager.AppSettings["accessToken"];
			//var accessSecret = ConfigurationManager.AppSettings["accessSecret"];
			//var client = new RdioClient(consumerKey, consumerSecret, accessToken, accessSecret);
			//_playbackToken = client.Playback.GetPlaybackTokenAsync("asdlkj").Result;
			// ...
		}
	}
}