using System.Collections.Generic;

namespace Client.Algs.Strings
{
    public class IsomorphicStrings
    {
        public bool Check(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;


            var dic = new Dictionary<char, char>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (dic.ContainsKey(s1[i]))
                {
                    if (dic[s1[i]] == s2[i])
                        continue;

                    return false;
                }

                dic.Add(s1[i], s2[i]);
            }

            return true;
        }
    }

}