using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ShockwaveFlashObjects;
using AxShockwaveFlashObjects;
using System.Windows.Forms.Integration;

namespace RdioUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		AxShockwaveFlash _player = new AxShockwaveFlash();
		WindowsFormsHost _host = new WindowsFormsHost();

		public MainWindow()
		{
			InitializeComponent();

			_host.Child = _player;
			this.MyGrid.Children.Add(_host);
			_player.LoadMovie(0, "http://www.rdio.com/media/flash/b2b4f7d856c1158435aa86d0320dd01b/api.swf");
			_player.Play();
			_player.CallFunction("rdio_play");
		}
	}
}
