using Invillia.Challenge.CrossCutting.Common;

namespace Invillia.Challenge.Application.Exceptions
{
    public class ItemListNotFoundException : BaseException
    {
        public ItemListNotFoundException()
            : base(404, "No items found.")
        {
        }
    }
}
