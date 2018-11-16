namespace Palindrome
{

    /// <summary>
    /// Palindrome info class.
    /// </summary>
    public class PalindromeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PalindromeInfo"/> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="text">The text.</param>
        public PalindromeInfo(int index, string text)
        {
            Index = index;
            Text = text;
        }

        /// <summary>
        /// Gets the start index of palindrome text.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index { get; }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; }

        /// <summary>
        /// Gets the length of Palindrome text.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length => Text.Length;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Text: {Text}, Index: {Index}, Length: {Length}";
        }
    }
}
