
namespace DeliveryDevil.Domain;


public class Paging
{
    public int? Size { get; private set; }
    public int? Number { get; private set; }
    public bool HasPaging { get => Size.HasValue && Number.HasValue; }
    public void SetPage(int? size, int? number)
    {
        Size = size;
        Number = number;
    }
}
