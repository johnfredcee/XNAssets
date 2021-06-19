using System.IO;

namespace XNAssets
{
	public interface IAssetManager
	{
		T Get<T>(string assetName) where T : class;
		T Load<T>(string assetName) where T : class;
		Stream Open(string path);
		void ClearCache();
	}
}
