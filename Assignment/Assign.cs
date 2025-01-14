﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Assign//<TTrans, TEq>
    {
        //public static  Compute(int[][] input)
        //{
        
        //

        public static List<Tuple<int, int>> Compute(int[,] input, int rowCount, int columnCount)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            // по строкам
            for (int i = 0; i < rowCount; i++)
            {
                int min = input[i,0];

                for (int j = 1; j < columnCount; j++)
                {
                    int cell = input[i,j];
                    if (cell < min)
                    {
                        min = cell;
                    }
                }

                for (int j = 0; j < columnCount; j++)
                {
                    int cell = input[i,j];
                    input[i,j] = cell - min;
                }
            }

            // по столбцам
            for (int j = 0; j < columnCount; j++)                
            {
                int min = input[0,j];

                for (int i = 1; i < rowCount; i++)
                {
                    int cell = input[i,j];
                    if (cell < min)
                    {
                        min = cell;
                    }
                }

                for (int i = 0; i < rowCount; i++)
                {
                    int cell = input[i,j];
                    input[i,j] = cell - min;
                }
            }

            // определяем оптимальность
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    int cell = input[i,j];
                    if (cell == 0)
                    {
                        result.Add(new Tuple<int, int>(i, j));
                        break;
                    }
                }
            }

            #region Not
            // нет допустимого решения
            if (result.Count < rowCount)
            {
                //// считаем кол нулей в строках
                //List<Tuple<int, int>> rows = new List<Tuple<int, int>>();

                //for (int i = 0; i < rowCount; i++)
                //{
                //    int countZero = 0;
                //    for (int j = 0; j < columnCount; j++)
                //    {
                //        int cell = input[i, j];
                //        if (cell == 0)
                //        {
                //            countZero++;
                //        }
                //    }
                //    rows.Add(new Tuple<int, int>(i, countZero));
                //}

                //rows.Sort(new ZeroComparer());
                //rows.Reverse();                

                //// считаем кол нулей в столбцах
                //List<Tuple<int, int>> columns = new List<Tuple<int, int>>();
                //for (int j = 0; j < columnCount; j++)                    
                //{
                //    int countZero = 0;
                //    for (int i = 0; i < rowCount; i++)
                //    {
                //        int cell = input[i, j];
                //        if (cell == 0)
                //        {
                //            countZero++;
                //        }
                //    }
                //    columns.Add(new Tuple<int, int>(j, countZero));
                //}

                //columns.Sort(new ZeroComparer());
                //columns.Reverse();

                //if (rows[0].Item2 > columns[0].Item2)
                //{

                //}
            }
            #endregion Not

            return result;
        }

        //private static void ActionCell(int[][] input, int columnCount, int i, Action<int> action)
        //{
        //    for (int j = 0; j < columnCount; j++)
        //    {
        //        action(input[i][j]);
        //    }
        //}

        public static KeyValuePair<string, int> GetMinimum(Dictionary<string, int> input)
        {
            KeyValuePair<string, int> min = new KeyValuePair<string, int>(string.Empty, int.MaxValue);
            foreach (var p in input)
            {
                if (p.Value < min.Value)
                {
                    min = p;
                }
            }

            return min;
        }
    }

    
}
