namespace Infrastructure.Models
{
    public class ValueTextModel<TValue, TText>
    {
        public ValueTextModel()
        {
        }

        public ValueTextModel(TValue value, TText text)
        {
            Value = value;

            Text = text;
        }

        /// <summary>
        /// Value
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        public TText Text { get; set; }
    }
}
