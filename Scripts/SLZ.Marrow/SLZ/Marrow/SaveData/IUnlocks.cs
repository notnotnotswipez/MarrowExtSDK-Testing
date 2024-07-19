using SLZ.Marrow.Warehouse;

namespace SLZ.Marrow.SaveData
{
	public interface IUnlocks
	{
		int UnlockCountForBarcode(Barcode barcode);

		int IncrementUnlockForBarcode(Barcode barcode);

		bool ClearUnlockForBarcode(Barcode barcode);
	}
}
