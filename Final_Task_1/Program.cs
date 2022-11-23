namespace Console_Program
{
    class Project
    {
        private static void Main( string[] args ) {
            Console.WriteLine( "\nИтоговая проверочная работа v1\n" );

            Console.Write( "Введите с клавиатуры элементы массива, через запятую:\n> " );
            
            // Запрашиваем строку
            string some_string = Console.ReadLine() ?? "";

            // Преобразуем в массив
            string[] some_array = some_string.Split(',');

            int array_size = some_array.Length;
            string[] result_array = {};
            
            // Фильтруем элементы
            foreach (string element in some_array)
                if ( element.Length <= 3 ) {
                    Array.Resize(ref result_array, result_array.Length + 1);
                    result_array[result_array.Length - 1] = element;
                }

            // Печатаем результат
            Console.Write( "\nРезультат выполнения программы:\n> [" );
            for ( int i = 0; i < some_array.Length; i++ )
                Console.Write( $"\"{some_array[i]}\", " );
            Console.Write( $"] -> [" );

            for ( int i = 0; i < result_array.Length; i++ )
                Console.Write( $"\"{result_array[i]}\", " );
            Console.Write( $"]\n\n" );
        }
    }
}
