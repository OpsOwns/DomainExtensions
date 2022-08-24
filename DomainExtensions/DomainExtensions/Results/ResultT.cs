namespace DomainExtensions.Results
{
    [Serializable]
    public class Result<T> : Result, ISerializable
    {
        private readonly T _value;

        internal Result(T value, bool isSuccess, Error error)
            : base(isSuccess, error)
            => _value = value;


        public static implicit operator Result<T>(T value)
        {
            if (value is Result<T> result)
            {
                var error = result.Error;
                return new Result<T>(result._value, false, error);
            }

            return null;
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IsFailure", IsFailure);
            info.AddValue("IsSuccess", IsSuccess);

            if (IsFailure)
            {
                info.AddValue("Error", Error);
            }

            if (IsSuccess)
            {
                info.AddValue("Value", Value);
            }
        }

        public T Value => IsSuccess
            ? _value
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");
    }
}