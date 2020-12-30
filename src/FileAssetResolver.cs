using System.IO;

namespace XNAssets
{
	public class FileAssetResolver : IAssetResolver
	{
		public string BaseFolder { get; set; }

		public FileAssetResolver(string baseFolder)
		{
			BaseFolder = baseFolder;
		}

		private string ResolvePath(string assetName)
		{
			if (AssetManager.SeparatorSymbol != Path.DirectorySeparatorChar)
			{
				assetName = assetName.Replace(AssetManager.SeparatorSymbol, Path.DirectorySeparatorChar);
			}

			if (!Path.IsPathRooted(assetName) && !string.IsNullOrEmpty(BaseFolder))
			{
				assetName = Path.Combine(BaseFolder, assetName);
			}
			return assetName;
		}

		public Stream Open(string assetName)
		{
			var resolvedPath = ResolvePath(assetName);	
			return File.OpenRead(resolvedPath);
		}



	}
}
