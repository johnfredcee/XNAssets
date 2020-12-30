#if !STRIDE

using System.IO;
using Microsoft.Xna.Framework;

namespace XNAssets
{
	public class TitleContainerAssetResolver: IAssetResolver
	{
		public string BaseFolder { get; set; }

		public TitleContainerAssetResolver()
		{
			BaseFolder = string.Empty;
		}

		public TitleContainerAssetResolver(string baseFolder)
		{
			BaseFolder = baseFolder;
		}

		private string ResolvePath(string assetName)
		{
			if (AssetManager.SeparatorSymbol != Path.DirectorySeparatorChar)
			{
				assetName = assetName.Replace(AssetManager.SeparatorSymbol, Path.DirectorySeparatorChar);
			}

			if (!string.IsNullOrEmpty(BaseFolder))
			{
				assetName = Path.Combine(BaseFolder, assetName);
			}
			return assetName;
		}
		public Stream Open(string assetName)
		{
			var resolvedPath = ResolvePath(assetName);
			return TitleContainer.OpenStream(resolvedPath);
		}
	}
}

#endif