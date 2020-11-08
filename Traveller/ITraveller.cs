using System;

namespace Traveller
{
    public interface ITraveller
    {
        /// <summary>
        /// Возвращает цену, т.к. функция GetMinTravelPrice из задания должна быть private, потому её невозможно обкладывать тестами
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cells"></param>
        /// <returns></returns>
        int Travel(int index, int[][] cells);//  
    }
}
