using Invillia.Challenge.CrossCutting.Common;

namespace Invillia.Challenge.Application.Exceptions
{
    public class ItemNotFoundException : BaseException
    {
        public ItemNotFoundException(string ItemId)
            : base(404, $"The item with ID {ItemId} was not found.")
        {
        }
    }
}
