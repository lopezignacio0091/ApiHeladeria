using System.Collections.Generic;
using System.Linq;

namespace Positano.ApiModel
{
    public class ApiResponse
    {
        public static ApiResponse Create(object data)
        {
            return new ApiResponse
            {
                Data = data,
                Status = ResponseStatus.Ok.ToString(),
                Messages = new List<Failure>()
            };
        }

        public static ApiResponse Create(object data, IEnumerable<(string key, string value)> messages)
        {
            return new ApiResponse
            {
                Data = data,
                Status = ResponseStatus.Ok.ToString(),
                Messages = messages.Select(m => new Failure(m))
            };
        }

        public static ApiResponse Create(object data, string message = "")
        {
            return new ApiResponse
            {
                Data = data,
                Status = ResponseStatus.Ok.ToString(),
                Messages = new List<Failure> { new Failure(("", message)) }
            };
        }

        public static ApiResponse Create(IEnumerable<(string key, string value)> messages)
        {
            return new ApiResponse
            {
                Status = ResponseStatus.Error.ToString(),
                Messages = messages.Select(m => new Failure(m))
            };
        }

        public static ApiResponse Create((string key, string value) message)
        {
            return new ApiResponse
            {
                Status = ResponseStatus.Error.ToString(),
                Messages = new List<Failure> { new Failure(message) }
            };
        }

        public static ApiResponse Create(string message)
        {
            return new ApiResponse
            {
                Status = ResponseStatus.Error.ToString(),
                Messages = new List<Failure> { new Failure(("", message)) }
            };
        }

        public object Data { get; set; }
        public string Status { get; set; }
        public IEnumerable<Failure> Messages { get; set; }

        public class Failure
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public Failure() { }
            public Failure((string key, string value) message)
            {
                Key = message.key;
                Value = message.value;
            }
        }
    }
}
