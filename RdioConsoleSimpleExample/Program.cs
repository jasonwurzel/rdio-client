using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic;
using RdioNet;
using RdioNet.Models;
using RdioNet.OAuth;

namespace RdioConsoleSimpleExample
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new RdioClient("ashm7aksmgqmx8w5atatrnh6", "y4R62SPJNF", "mev3b4ysg5q76ca7mt6axh4tmxdz2yrjwzs7tqa7499kk4vhbh92dyy5xjrd34kq", "jUEF8Zt8xVZ7");
			//client.Credentials.Token = new OAuthToken { Secret = "YZ4Yp29F7QEW", Token = "ucgrkp3rr48udahdw4v9f9vc", Type = OAuthTokenType.Access};
			//client.Credentials.ConsumerKey = "ashm7aksmgqmx8w5atatrnh6";
			//client.Credentials.ConsumerSecret = "y4R62SPJNF";

			//var res = client.RequestUserAuthorizationAsync().Result;
			//////Process.Start(res.AuthorizationUrl.ToString()).WaitForExit();
			//string verifier = "";
			//var res2 = client.CompleteUserAuthorizationAsync(verifier).Result;
			var response = client.Playback.GetPlaybackTokenAsync("asdlkj").Result;
			
		}
	}
}
