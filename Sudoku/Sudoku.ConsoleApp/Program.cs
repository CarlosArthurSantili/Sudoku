using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Exemplo de Erro Linha
            string sudoku = @"1 3 2 5 7 9 4 6 5
                              4 9 8 2 6 1 3 7 8
                              7 5 6 3 8 4 2 1 9
                              6 4 3 1 5 8 7 9 2
                              5 2 1 7 9 3 8 4 6
                              9 8 7 4 2 6 5 3 1
                              2 1 4 9 3 5 6 8 7
                              3 6 5 8 1 7 9 2 4
                              8 7 9 6 4 2 1 5 3";
            */

            /*Exemplo de Erro Coluna
            string sudoku = @"1 3 2 5 7 9 4 6 8
                              9 4 8 2 6 1 3 7 5
                              7 5 6 3 8 4 2 1 9
                              6 4 3 1 5 8 7 9 2
                              5 2 1 7 9 3 8 4 6
                              9 8 7 4 2 6 5 3 1
                              2 1 4 9 3 5 6 8 7
                              3 6 5 8 1 7 9 2 4
                              8 7 9 6 4 2 1 5 3";
            */


            /*Exemplo de Erro Area
            string sudoku = @"1 3 2 5 7 9 4 6 8
                              4 9 8 2 6 1 3 7 5
                              7 5 6 3 8 4 2 1 9
                              6 4 3 1 5 8 7 9 2
                              5 2 1 7 9 3 8 4 6
                              2 1 4 9 3 5 6 8 7
                              9 8 7 4 2 6 5 3 1
                              3 6 5 8 1 7 9 2 4
                              8 7 9 6 4 2 1 5 3";
            */

            ///* Original
            string sudoku = @"1 3 2 5 7 9 4 6 8
                              4 9 8 2 6 1 3 7 5
                              7 5 6 3 8 4 2 1 9
                              6 4 3 1 5 8 7 9 2
                              5 2 1 7 9 3 8 4 6
                              9 8 7 4 2 6 5 3 1
                              2 1 4 9 3 5 6 8 7
                              3 6 5 8 1 7 9 2 4
                              8 7 9 6 4 2 1 5 3";
            //*/

            bool sudokuValido = ValidarSudoku(sudoku);

            if (sudokuValido == true)
            {
                Console.WriteLine("SIM");
            }
            else 
            {
                Console.WriteLine("NÃO");
            }
            Console.ReadLine();
            

        }

        private static bool ValidarSudoku(string sudoku)
        {
            bool sudokuValido = true;
            string[] linhasSudoku;
            int valida1 = 0;
            int valida2 = 0;
            int valida3 = 0;
            int valida4 = 0;
            int valida5 = 0;
            int valida6 = 0;
            int valida7 = 0;
            int valida8 = 0;
            int valida9 = 0;
            
            linhasSudoku = new string[9];
            int[] todosNumeros = new int[81];
            int i = 0;//contadores
            int j = 0;

            //Divide a string em linhas
            using (StringReader reader = new StringReader(sudoku))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    linhasSudoku[i] = line;
                    //Console.WriteLine(linhasSudoku[i]);
                    //Console.WriteLine();
                    //Console.ReadLine();
                    i++;
                }
            }


            //atribui os valores das linhas para um vetor de inteiros
            i = 0;
            j = 0;
            for (i = 0; i < 9; i++)
            {
                foreach (char caractere in linhasSudoku[i])
                {
                    if (caractere.ToString().Equals("1") || caractere.ToString().Equals("2") || caractere.ToString().Equals("3") || caractere.ToString().Equals("4") || caractere.ToString().Equals("5") || caractere.ToString().Equals("6") || caractere.ToString().Equals("7") || caractere.ToString().Equals("8") || caractere.ToString().Equals("9"))
                    {
                        //todosNumeros[j] = Convert.ToInt32(caractere); dá errado
                        todosNumeros[j] = Convert.ToInt32(caractere.ToString());

                        //Console.WriteLine(caractere);
                        //EXIBE TODOS OS VALORES DENTRO DO SUDOKU OBTIDO
                        //Console.Write(todosNumeros[j]);
                        j++;
                    }
                }
                //Console.ReadLine();
            }


            //checar as linhas
            int k = 0;
            for (int linha = 0; linha < 9; linha++)
            {
                for(int coluna = 0; coluna < 9; coluna++)
                {
                    switch (todosNumeros[k])
                    {
                        case 1: valida1++; break;
                        case 2: valida2++; break;
                        case 3: valida3++; break;
                        case 4: valida4++; break;
                        case 5: valida5++; break;
                        case 6: valida6++; break;
                        case 7: valida7++; break;
                        case 8: valida8++; break;
                        case 9: valida9++; break;
                    }
                    k++;
                }

                if ((valida1 != 1) || (valida2 != 1) || (valida3 != 1) || (valida4 != 1) || (valida5 != 1) || (valida6 != 1) || (valida7 != 1) || (valida8 != 1) || (valida9 != 1))
                {
                    sudokuValido = false;
                }

                //se a linha estiver correta, faz a proxima validação
                if (sudokuValido == true)
                {
                    valida1 = 0;
                    valida2 = 0;
                    valida3 = 0;
                    valida4 = 0;
                    valida5 = 0;
                    valida6 = 0;
                    valida7 = 0;
                    valida8 = 0;
                    valida9 = 0;
                }
                else 
                {
                    Console.WriteLine("Sudoku Invalido: Linhas");
                    Console.ReadLine();
                    break;
                }
                
            }
            if (sudokuValido == false)
            {
                return sudokuValido;
            }

            //checar as colunas
            int c = 0;
            for (int coluna = 0; coluna < 9; coluna++)
            {
                for (int linha = 0; linha < 9; linha++)
                {
                    switch (todosNumeros[c])
                    {
                        case 1: valida1++; break;
                        case 2: valida2++; break;
                        case 3: valida3++; break;
                        case 4: valida4++; break;
                        case 5: valida5++; break;
                        case 6: valida6++; break;
                        case 7: valida7++; break;
                        case 8: valida8++; break;
                        case 9: valida9++; break;
                    }
                    c+=9;
                }

                if ((valida1 != 1) || (valida2 != 1) || (valida3 != 1) || (valida4 != 1) || (valida5 != 1) || (valida6 != 1) || (valida7 != 1) || (valida8 != 1) || (valida9 != 1))
                {
                    sudokuValido = false;
                }

                //se a linha estiver correta, faz a proxima validação
                if (sudokuValido == true)
                {
                    valida1 = 0;
                    valida2 = 0;
                    valida3 = 0;
                    valida4 = 0;
                    valida5 = 0;
                    valida6 = 0;
                    valida7 = 0;
                    valida8 = 0;
                    valida9 = 0;
                    c = coluna+1;
                }
                else
                {
                    Console.WriteLine("Sudoku Invalido: Colunas");
                    Console.ReadLine();
                    break;
                }

            }
            if (sudokuValido == false)
            {
                return sudokuValido;
            }



            //checar as areas 
            int a = 0;
            for (int linha = 0; linha < 9; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    switch (todosNumeros[a])
                    {
                        case 1: valida1++; break;
                        case 2: valida2++; break;
                        case 3: valida3++; break;
                        case 4: valida4++; break;
                        case 5: valida5++; break;
                        case 6: valida6++; break;
                        case 7: valida7++; break;
                        case 8: valida8++; break;
                        case 9: valida9++; break;
                    }
                    switch (todosNumeros[a+9])
                    {
                        case 1: valida1++; break;
                        case 2: valida2++; break;
                        case 3: valida3++; break;
                        case 4: valida4++; break;
                        case 5: valida5++; break;
                        case 6: valida6++; break;
                        case 7: valida7++; break;
                        case 8: valida8++; break;
                        case 9: valida9++; break;
                    }
                    switch (todosNumeros[a + 18])
                    {
                        case 1: valida1++; break;
                        case 2: valida2++; break;
                        case 3: valida3++; break;
                        case 4: valida4++; break;
                        case 5: valida5++; break;
                        case 6: valida6++; break;
                        case 7: valida7++; break;
                        case 8: valida8++; break;
                        case 9: valida9++; break;
                    }

                    //EXIBE OS "TRIOS" DA AREA QUADRADA
                    //Console.Write(todosNumeros[a]);
                    //Console.Write(todosNumeros[a+9]);
                    //Console.WriteLine(todosNumeros[a+18]);
                    //Console.ReadLine();
                    a++;
                }

                if ((valida1 != 1) || (valida2 != 1) || (valida3 != 1) || (valida4 != 1) || (valida5 != 1) || (valida6 != 1) || (valida7 != 1) || (valida8 != 1) || (valida9 != 1))
                {
                    sudokuValido = false;
                }

                //se a linha estiver correta, faz a proxima validação
                if (sudokuValido == true)
                {
                    valida1 = 0;
                    valida2 = 0;
                    valida3 = 0;
                    valida4 = 0;
                    valida5 = 0;
                    valida6 = 0;
                    valida7 = 0;
                    valida8 = 0;
                    valida9 = 0;
                    if ((linha==2)||(linha==5))//observar 0 à 80 posicionados em formato sudoku para entender logica
                    a += 18;
                }
                else
                {
                    //sair do for
                    Console.WriteLine("Sudoku Invalido: Area");
                    Console.ReadLine();
                    break;
                }

            }


            return sudokuValido;
        }
    }
}
