using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Diagnostics; 

namespace Ch07Ex01 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            int[] testArray = {4, 7, 4, 2, 7, 3, 7, 8, 3, 9, 1, 9}; 
            int[] maxVallndices; 
            int maxVal = Maxima (testArray, out maxVallndices) ;
            Console.WriteLine("Maximum value {0} found at element indices:", maxVal);
                               // Вывод максимального значения и его индексов  
            foreach (int index in maxVallndices) 
            { 
                Console.WriteLine(index); 
            } 
            Console.ReadKey(); 
        }    
        
        static int Maxima(int[] integers, out int[] indices) 
        { 
            Debug.WriteLine ("Maximum value search started.") ; 
                               // Начало поиска максимального значения 
            indices = new int[1]; 
            int maxVal = integers [0]; 
            indices[0] = 0; 
            int count = 1; 
            Debug.WriteLine(string.Format("Maximum value initialized to {0}, at element index 0.", maxVal)); 
                               // Инициализация максимального значения элементом с индексом 0 
            for (int i = 1; i < integers. Length; i++) 
            { 
                Debug.WriteLine(string.Format("Now looking at element at index {0}.", i)); 
                               // Просмотр очередного элемента 
                if (integers[i] > maxVal)
                {
                    maxVal = integers[i];
                    count = 1;
                    indices = new int[1];
                    indices[0] = i;
                    Debug.WriteLine(string.Format("New maximum found. New value is {0}, at element index {1}.", maxVal,
                        i));
                    // Найдено новое максимальное значение  
                }
                else
                {
                    if (integers[i] == maxVal)
                    {
                        count++;
                        int[] oldlndices = indices;
                        indices = new int[count];
                        oldlndices.CopyTo(indices, 0);
                        indices[count - 1] = i;
                        Debug.WriteLine(string.Format("Duplicate maximum found at element index {0}.", i));
                        // Найден дубликат максимального значения 
                    }
                }
            } 
            Trace.WriteLine(string.Format("Maximum value {0} found, with {1} occurrences.", maxVal, count)); 
                        // Вывод максимального значения и количества его вхождений 
            Debug. WriteLine ("Maximum value search completed.") ; 
                        // Поиск максимального значения завершен 
            return maxVal; 
        } 
    } 
} 
