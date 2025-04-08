using ValueOf;

namespace Domain.ValueObjects
{
    public class State : ValueOf<string, State>
    {
        public static implicit operator string(State state) => state.Value;
        public static implicit operator State(string state) => From(state);
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Estado é obrigatório.", nameof(Value));
            if (Value.Length < 2)
                throw new ArgumentException("Estado inválido.", nameof(Value));
        }
    }
}
