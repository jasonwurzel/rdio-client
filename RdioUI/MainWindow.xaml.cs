using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Forms.Integration;
using AxShockwaveFlashObjects;
using RdioNet;

namespace RdioUI
{
	/// <summary>
	///     Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly WindowsFormsHost _host = new WindowsFormsHost();
		private readonly AxShockwaveFlash _player = new AxShockwaveFlash();
		private object _lockObj = new object();
		private string _playbackToken;

		public MainWindow()
		{
			InitializeComponent();


			Loaded += (sender, args) => { ThreadPool.QueueUserWorkItem(state => { callRdio(); }); };
		}

		private void callRdio()
		{
			var client = new RdioClient("ashm7aksmgqmx8w5atatrnh6", "y4R62SPJNF", "mev3b4ysg5q76ca7mt6axh4tmxdz2yrjwzs7tqa7499kk4vhbh92dyy5xjrd34kq", "jUEF8Zt8xVZ7");
			_playbackToken = client.Playback.GetPlaybackTokenAsync("asdlkj").Result;
			//var playlists = client.Playlists.GetPlaylistsAsync().Result;
			//var myplaylist = playlists.Owned.First();

			_host.Dispatcher.InvokeAsync(() =>
										{
											_host.Child = _player;
											MyGrid.Children.Add(_host);
											_player.LoadMovie(0, string.Format("http://www.rdio.com/api/swf/?enableLogging=1&playbackToken={0}", _playbackToken));
											//_player.LoadMovie(0, "http://www.rdio.com/media/flash/b2b4f7d856c1158435aa86d0320dd01b/api.swf");
											_player.OnReadyStateChange += (sender, @event) =>
											{
												var ns = @event.newState;
												var message = string.Format(@"<invoke name=""rdio_play"" returntype=""xml""></invoke>", _playbackToken);
												//var message = string.Format(@"<invoke name=""rdio_play""><arguments><string>{0}</string></arguments></invoke>", playbackToken);
												//_player.CallFunction(message);
											};
											_player.FlashCall += (sender, @event) =>
																{
																	var req = @event.request;
																	log(req);
																};
											_player.FSCommand += (sender, @event) =>
																{
																	var args = @event.args;
																	var command = @event.command;
																	log(string.Format("command {0} args {1}", command, args));
																};
											
											_player.Play();

											Thread.Sleep(5000);
											
											//_player.RaiseOnFlashCall(this, new _IShockwaveFlashEvents_FlashCallEvent(message));
											
											//_player.CallFunction(string.Format("rdio_play('{0}')", playbackToken));
											//_player.CallFunction("rdio_play()");
										});
			
		}

		private void log(string req)
		{
			lock (_lockObj)
			{
				File.AppendAllLines(@"x:\temp\flashlog.txt", new []{req});

				if (req.Contains("[api] initialized"))
				{
					//var message = string.Format(@"<invoke name=""rdio_play"" returntype=""xml""></invoke>", _playbackToken);
					//var message = string.Format(@"<invoke name=""rdio_play""><arguments><string>{0}</string></arguments></invoke>", _playbackToken);
					var message = string.Format(@"<invoke name=""KRAMPF""><arguments></arguments></invoke>", _playbackToken);
					//var message = string.Format(@"rdio_play('{0}')", _playbackToken);

					_player.CallFunction(message);
				}
			}
		}
	}
}