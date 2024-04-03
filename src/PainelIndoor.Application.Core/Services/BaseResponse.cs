
namespace PainelIndoor.Application.Core.Services
{
    public abstract class BaseResponse 
    {
        private readonly Dictionary<string, string[]> _errors = new() { };

        private readonly Dictionary<string, string[]> _messages = new() { };

        public BaseResponse() { }

        public void AddErrors(string key, string value)
        {
            _errors.Add(key, new string[] { value });
        }

        public void AddErrors(List<BaseMessage> errors)
        {
            foreach (var item in errors)
            {
                _errors.Add(item.Key, new string[] { item.Message });
            }
        }

        public void AddMessages(string key, string message)
        {
            _messages.Add("sucesso", new string[] { message });
        }

        public void AddMessages(List<BaseMessage> messages)
        {
            foreach (var item in messages)
            {
                _errors.Add("sucesso", new string[] { item.Message });
            }
        }

        public void Clear()
        {
            _messages?.Clear();
            _errors?.Clear();
        }

        public Dictionary<string, string[]> Messages => _messages;

        public Dictionary<string, string[]> Errors => _errors;

        public bool HasError() => !(Errors == null || Errors.Count == 0);
    }
}
