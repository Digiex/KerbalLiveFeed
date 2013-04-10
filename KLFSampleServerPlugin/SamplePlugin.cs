using KLFServerPluginAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Reflection;

namespace KLFSampleServerPlugin
{
	/// <summary>
	/// A Sample plugin for KLF Server
	/// </summary>
	[Export(typeof(IServerPlugin))]
	public class SamplePlugin : IServerPlugin
	{
		public IServerAPI Server { get; set; }
		public void OnEnable(){
			Server.WriteConsole("SamplePlugin enabled!");
		}
		public void OnDisable(){
			Server.WriteConsole("SamplePlugin disabled.");
		}
		public void Associate(IServerAPI Server){
			this.Server = Server;
		}
	}
}