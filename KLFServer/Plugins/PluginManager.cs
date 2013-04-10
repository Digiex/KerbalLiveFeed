using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.IO;
using KLFServerPluginAPI;

namespace KLFServer.Plugins
{
	/// <summary>
	/// Loads the plugins to the server
	/// </summary>
	public class PluginManager : IPluginManager
	{
		Server server;
		#pragma warning disable 649
		[ImportMany(typeof(IServerPlugin))]
		private IEnumerable<IServerPlugin> plugins;
		#pragma warning restore 649

		internal PluginManager(Server server){
			this.server = server;
		}
		
		internal void DoImport()
		{
			//An aggregate catalog that combines multiple catalogs
			var catalog = new AggregateCatalog();
			//Adds all the parts found in all assemblies in
			//the same directory as the executing program
			catalog.Catalogs.Add(
				new DirectoryCatalog(
					Path.GetDirectoryName(
						Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + "KLFPlugins"));

			//Create the CompositionContainer with the parts in the catalog
			CompositionContainer container = new CompositionContainer(catalog);

			//Fill the imports of this object
			container.ComposeParts(this);
		}

		public int AvailableNumberOfPlugins
		{
			get
			{
				return (plugins != null ? plugins.Count() : 0);
			}
		}
		
		public void LoadPlugins(){
			if(plugins != null){
				//Associate
				foreach(IServerPlugin pl in plugins){
					pl.Associate(this.server);
				}
			}
		}
		
		public void EnablePlugins(){
			if(plugins != null){
				//Enable
				foreach(IServerPlugin pl in plugins){
					pl.OnEnable();
				}
			}
		}
		
		public void DisablePlugins(){
			if(plugins != null){
				//Disable
				foreach(IServerPlugin pl in plugins){
					pl.OnDisable();
				}
			}
		}

	}
}
