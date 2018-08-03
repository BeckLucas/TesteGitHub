using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGitHub
{
    class ConversorDatas
    {
		public int Soma(int a, int b)
		{
			return a + b;
		}
		
		public int Soma(int a, int b, int c)
		{
			return 30;
		}
		
        public bool isFunction()
        {
            return true;
        }

        public bool isFunction2()
        {
            int a = 1;
            int b = 2;

            int soma = a + b;

            return (soma == 2);
        }
    }
}
