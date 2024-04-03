using System.Data.SqlTypes;

namespace PainelIndoor.Application.Core.Services
{
    public class BaseRequest : BaseMessage
    {
        public BaseRequest() { }

        public Guid? Id { get; set; }
    }
}
