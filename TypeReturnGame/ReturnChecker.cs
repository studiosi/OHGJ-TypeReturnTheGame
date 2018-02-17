using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeReturnGame
{ 

    public enum RETURN_TYPE
    {
        SUCCESS,
        ERROR_LENGTH,
        ERROR
    }

    class ReturnChecker
    {

        const int Idx_R = 0;
        const int Idx_E = 1;
        const int Idx_T = 2;
        const int Idx_U = 3;
        const int Idx_N = 4;

        const string okString = "RETURN";

        public char[] chars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
        'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        // RETURN contains RETUN Letters

        public char[] encoding;
        private Random r;

        public ReturnChecker()
        {
            encoding = new char[5];
            r = new Random();
        }

        public void generateEncoding()
        {
            List<int> alreadyUsedIdx = new List<int>();
            encoding = new char[5];
            
            for(int i = 0; i < 5; i++)
            {
                int charId = r.Next(0, chars.Length);
                while(alreadyUsedIdx.Contains(charId))
                {
                    charId = r.Next(0, chars.Length);
                }
                alreadyUsedIdx.Add(charId);
                encoding[i] = chars[charId];
            }

        }

        public string translateString(string inStr)
        {
            if(okString.Equals(inStr))
            {
                return "XXXXXX";
            }
            string retStr = "";
            foreach(char c in inStr)
            {
                if(c == encoding[Idx_R])
                {
                    retStr += 'R';
                }
                else if(c == encoding[Idx_E])
                {
                    retStr += 'E';
                }
                else if(c == encoding[Idx_T])
                {
                    retStr += 'T';
                }
                else if(c == encoding[Idx_U])
                {
                    retStr += 'U';
                }
                else if(c == encoding[Idx_N])
                {
                    retStr += 'N';
                }
                else
                {
                    retStr += c;
                }
            }
            return retStr;
        }

        public RETURN_TYPE checkString(string translatedStr)
        {
            if(translatedStr.Length > 10)
            {
                return RETURN_TYPE.ERROR_LENGTH;
            }
            if(translatedStr.Equals(okString))
            {
                return RETURN_TYPE.SUCCESS;
            }
            return RETURN_TYPE.ERROR;
        }

    }
}
