using System.Configuration;
using System.Linq;
using NUnit.Framework;
using RdioNet;

namespace RdioClientTests
{
	/// <summary>
	///     Just some dummy-test for playing with /probing the RdioNet-RdioClient
	/// </summary>
	[TestFixture]
	public class RdioNetTests
	{
		/// <summary>
		///     Kommentar
		/// </summary>
		[Test, Ignore]
		public void TestClient01()
		{
			var consumerKey = ConfigurationManager.AppSettings["consumerKey"];
			var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
			var accessToken = ConfigurationManager.AppSettings["accessToken"];
			var accessSecret = ConfigurationManager.AppSettings["accessSecret"];
			var client = new RdioClient(consumerKey, consumerSecret, accessToken, accessSecret);

			//var res = client.RequestUserAuthorizationAsync().Result;
			//////Process.Start(res.AuthorizationUrl.ToString()).WaitForExit();
			//string verifier = "";
			//var res2 = client.CompleteUserAuthorizationAsync(verifier).Result;
			var response = client.Playback.GetPlaybackTokenAsync("asdlkj").Result;
			var playlists = client.Playlists.GetPlaylistsAsync().Result;
			var myplaylist = playlists.Owned.First();
		}
	}
}