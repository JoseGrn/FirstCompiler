using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//using System.Text.RegularExpressions;

namespace Compiladores
{
    public enum TokenType
    {
        Plus = '+',
        Star = '*',
        Division = '/',
        Minus = '-',
        LParen = '(',
        RParen = ')',
        EOF = (char)0,
        Number = (char)1,
    }
}
