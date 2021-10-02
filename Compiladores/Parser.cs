using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class Parser
    {
        Scanner _scanner;
        Token _token;
        //Transiciones de la gramática revisada

        public double InitializeExpression(string regexp)
        {
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();

            double Answer = 0;

            switch (_token.Tag)
            {
                case TokenType.Minus:
                case TokenType.Number:
                case TokenType.LParen:
                    Answer = E();
                    break;
                default:
                    break;
            }
            MatchToken(TokenType.EOF);
            return Answer;
        }

        public double E()
        {
            switch (_token.Tag)
            {
                case TokenType.Minus:
                case TokenType.Number:
                case TokenType.LParen:
                    return T() + ES();
                default:
                    throw new Exception("Error");
            }
        }
        public double ES()
        {
            switch (_token.Tag)
            {
                case TokenType.Plus:
                    _token = _scanner.GetToken();
                    return T() + ES();
                case TokenType.Minus:
                    _token = _scanner.GetToken();
                    return -T() + ES();
                default:
                    return 0;
            }
        }

        public double T()
        {
            switch (_token.Tag)
            {
                case TokenType.Minus:
                case TokenType.Number:
                case TokenType.LParen:
                    double i = F() * TS();
                    return i;
                default:
                    throw new Exception("Error");
            }
        }

        public double TS()
        {
            switch (_token.Tag)
            {
                case TokenType.Star:
                    _token = _scanner.GetToken();
                    return M() * TS();
                case TokenType.Division:
                    _token = _scanner.GetToken();
                    return (1/M()) * TS();
                default:
                    return 1;
            }
        }

        public double F()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Number:
                    return +M();
                case TokenType.Minus:
                    MatchToken(TokenType.Minus);
                    return -F();
                default:
                    throw new Exception("Error");
            }
        }

        public double M()
        {
            switch (_token.Tag)
            {
                case TokenType.Number:
                    return Convert.ToInt16(Numbers());
                case TokenType.LParen:
                    MatchToken(TokenType.LParen);
                    double result = E();
                    MatchToken(TokenType.RParen);
                    return result;
                default:
                    throw new Exception("Error");
            }
        }

        private string Chain()
        {
            switch (_token.Tag)
            {
                case TokenType.Number:
                    return Numbers();
                default:
                    return "";
            }
        }
        
        private string Numbers()
        {
            string Cadena = new string(_token.Value, 1); 
            MatchToken(TokenType.Number);
            Cadena += Chain();
            return Cadena;
        }

        private void MatchToken(TokenType Tag)
        {
            if (_token.Tag == Tag)
            {
                _token = _scanner.GetToken();
            }
            else
            {
                throw new Exception("Error");
            }
        }

    }
}
