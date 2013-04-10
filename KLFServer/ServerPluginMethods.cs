
using System;
using KLFServerPluginAPI;

namespace KLFServer
{
	/// <summary>
	/// Description of ServerPluginMethods.
	/// </summary>
	partial class Server : IServerAPI
	{
		public void WriteConsole(string text){
			stampedConsoleWriteLine(text);
		}
	}
}
