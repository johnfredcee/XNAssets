using System.IO;

namespace XNAssets
{
	public interface IAssetManager
	{
		T Load<T>(string assetName);
		Stream Open(string path);

		void ClearCache();
	}
}
