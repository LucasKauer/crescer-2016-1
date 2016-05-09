using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Digite um número:");
                var numero = Console.ReadLine();

                var numeroConvertido = Convert.ToInt32(numero);

                if (numeroConvertido == 13)
                    throw new NumeroAzarException("Você digitou um número do azar");

                Console.WriteLine("O número convertido é:" + numeroConvertido);
            }
            catch (FormatException)
            {
                //Logger.LogarErro(ex);
                Console.WriteLine("Você deve digitar somente números!");
                throw;                
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("O número deve estar no intervalo de -2147483648 a 2147483648!");
            }
            catch (NumeroAzarException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                Console.Clear();
            }            
        }
    }
}
