using System.Collections.Generic;
using System.Linq;

namespace Client.Algs.Strings
{
    public class WordLadder
    {
        internal class WordLevel
        {
            internal int Level;
            internal string Word;
        }

        private List<string> words;
        private List<string> except;
        public WordLadder(List<string> words)
        {
            this.words = words;
            this.except = new List<string>();
        }

        public List<string> NextWords(string s)
        {
            var result = new List<string>();
            var nextWordsCnadidates = words.Except(except);

            foreach (var w in nextWordsCnadidates)
            {
                var dist = EditDistance(s, w);

                if (dist == 1)
                {
                    result.Add(w);
                    except.Add(w);
                }
            }

            return result;
        }

        private int EditDistance(string s, string w)
        {
            return w.Select((t, i) => (s[i] != t ? 1 : 0)).Sum();
        }

        public int FromTo(string s1, string s2)
        {
            var nextWords = NextWords(s1);
            var queue = new Queue<WordLevel>();
            nextWords.ForEach(w => queue.Enqueue(new WordLevel() { Level = 1, Word = w }));

            while (queue.Peek() != null)
            {
                var candidate = queue.Dequeue();
                if (EditDistance(candidate.Word, s2) == 1)
                {
                    return candidate.Level + 1;
                }

                nextWords = NextWords(candidate.Word);
                nextWords.ForEach(w => queue.Enqueue(new WordLevel() { Level = candidate.Level + 1, Word = w }));
            }

            return -1;
        }
    }
}