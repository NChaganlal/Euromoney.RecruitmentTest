namespace Content.Manipulation
{
    /// <summary>
    /// This interface represents a negative word scanner
    /// </summary>
    public interface INegativeWordScanner
    {
        /// <summary>
        /// Counts negative words in a given input
        /// </summary>
        /// <param name="contentToScan">Input to scan</param>
        /// <returns>Number of Negative words on the input</returns>
        int CountNegativeWords(string contentToScan);

        string FilterNegativeWordsFromContent(string contentToScan);
    }
}
