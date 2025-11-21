using StarMap.API;
using KSA;

namespace KSADiscordRichPresence
{
	[StarMapMod]
	public class KSADiscordRichPresence
	{
		private DiscordRpcClientManager? DiscordRpcClientManager { get; set; }

		[StarMapImmediateLoad]
		public void Init(Mod definingMod)
		{
			DiscordRpcClientManager = new DiscordRpcClientManager();
			DiscordRpcClientManager?.Setup();
			DiscordRpcClientManager?.SetPresence("Sailing the Stars");
		}
	}
};
