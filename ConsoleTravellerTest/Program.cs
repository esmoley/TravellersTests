using System;
using System.Collections.Generic;
using AdvancedTraveller;
using SimpleTraveller;
using Traveller;

namespace ConsoleTravellerTest
{
    class Program
    {
        public static ITraveller traveller;
        static void Main(string[] args)
        {
            var cellsCollection = new List<int[][]>
            {
                new int[][] {
                    new int[] { 0 }
                },
                new int[][] {
                    new int[] { 0, 0, 1 },
                    new int[] { 0, 1, 0 },
                    new int[] { 0, 1, 0}
                },
                new int[][]
                {
                    new int[]{ 0, 0, 0, 1},
                    new int[]{ 0, 1, 0, 1},
                    new int[]{ 1, 0, 0, 1},
                    new int[]{ 0, 0, 1, 1},
                    new int[]{ 0, 0, 0, 0},
                }
            };


            for (int i=0; i<cellsCollection.Count; i++)
            {
                Console.WriteLine((i != 0?Environment.NewLine:"")+"Обычный путешественник");
                traveller = new SimpleTraveller.SimpleTraveller(); // Обычный путешественник
                traveller.Travel(i + 1, cellsCollection[i]);
                Console.WriteLine(Environment.NewLine+ "Продвинутый путешественник");
                traveller = new AdvancedTraveller.AdvancedTraveller(); // Продвинутый путешественник
                traveller.Travel(i + 1, cellsCollection[i]);

            }
            
        }
        
    }
}
