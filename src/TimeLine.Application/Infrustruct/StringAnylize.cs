using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLine.Infrustruct
{
    public class StringAnylize : IStringAnylize
    {
        private static string[] oper = { "+", "-", "*", "/" };

        public string Describe { get; set; }

        public Queue<string> Middle2SuffixExp(string exp)
        {
            Stack<char> s = new Stack<char>();
            Queue<string> result = new Queue<string>();
            var b = exp.ToCharArray();
            int i = 0;
            StringBuilder r = new StringBuilder();
            char c;

            Describe = string.Empty;

            while (i < b.Length)
            {
                i = SkipSpace(exp, i);
                c = b[i++];
                switch (c)
                {
                    case '+':
                    case '-':
                        result.Enqueue(r.ToString());
                        r.Clear();
                        while (s.Count > 0 && ((c = s.Peek()) == '/' || c == '*'))
                        {
                            result.Enqueue(c.ToString());
                            s.Pop();
                        }
                        s.Push(b[i - 1]);
                        break;
                    case ')':
                        result.Enqueue(r.ToString());
                        while ((c = s.Pop()) != '(')
                            result.Enqueue(c.ToString());

                        r.Clear();
                        break;
                    case '*':
                    case '/':
                        result.Enqueue(r.ToString());
                        r.Clear();
                        s.Push(c);
                        break;
                    case '(':
                        s.Push(c);
                        break;
                    case '{':
                        result.Enqueue(r.ToString());
                        r.Clear();
                        break;
                    case '}':
                        Describe = r.ToString();
                        r.Clear();
                        break;
                    default:
                        r.Append(c);
                        break;
                }
            }

            if (r.Length > 0)
                result.Enqueue(r.ToString());
            while (s.Count > 0)
                result.Enqueue(s.Pop().ToString());
            return result;
        }

        public int SkipSpace(string s, int i)
        {
            while (i < s.Length && s[i] == ' ')
                i++;

            return i;
        }

        public bool IsOperation(string o)
        {
            return oper.Contains(o);
        }
    }
}
