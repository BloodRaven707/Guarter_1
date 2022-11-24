namespace Console_Program
{
    class Project
    {
        /// <summary>Функция преобразует массив строчных элементов в красивую строку</summary>
        /// <param name="some_array">Массив произвольной длинны, состоящий из строк</param>
        /// <returns>Строка, похожая на List из Python</returns>
        public static string ArrayToString(string[] some_array) {
            string result = "[";

            // Если массив не пустой, делаем красивую строку, для вывода            
            if ( some_array.Length != 0 ) {
                result += $"\"{some_array[0]}\"";

                for ( int i = 1; i < some_array.Length; i++ )
                    result +=  $", \"{some_array[i]}\"";
            }

            return result + "]";
        }


        /// <summary>Функция запрашивает у пользователя строку из элементов, через запятую и/или пробел</summary>
        /// <returns>Массив произвольной длинны, состоящий из строк</returns>
        public static string[] GetStrinToArray() {
            string[] result_array;

            Console.Write( "\nВведите с клавиатуры элементы массива, через запятую и/или пробел:\n> " );
            // Запрашиваем строку
            string some_string = Console.ReadLine() ?? "";

            // Массив символов - разделителей для строки
            char[] separators = new char[] { ',', ' ' };

            // Преобразуем строку в массив
            result_array = some_string.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return result_array;
        }


        /// <summary>Функция фильтрует массив произвольной длинны, состоящий из строк, согласно условию</summary>
        /// <param name="some_array">Массив произвольной длинны, состоящий из строк</param>
        /// <returns>Массив с удовлетворяющими условию элемантами</returns>
        public static string[] FindAllInArray(string[] some_array) {
            string[] result_array = {};

            foreach (string element in some_array) {
                // Фильтруем элементы
                if ( element.Length <= 3 ) {
                    Array.Resize(ref result_array, result_array.Length + 1);
                    result_array[result_array.Length - 1] = element;
                }
            }

            return result_array;
        }


        /// <summary>Основной обработчик, выполнит программу и распечатает в консоль результат ее работы</summary>
        /// <param name="some_array">Массив произвольной длинны, состоящий из строк</param>
        public static void ConsoleWriteResult(string[] some_array) {
            // Выполнить фильтрацию и напечатать
            Console.WriteLine( "\nРезультат выполнения программы:" );
            Console.WriteLine( $"> { ArrayToString( some_array ) } -> { ArrayToString( FindAllInArray( some_array ) ) }\n" );
        }


        private static void Main( string[] args ) {
            Console.WriteLine( "\nИтоговая проверочная работа v 2.0\n" );

            while ( true ) {
                //
                // Набор тестовых данных
                //
                List<List<string>> list_tests = new List<List<string>>();
                list_tests.Add( new List<string>{ "hello", "2", "world", ":-)" } );
                list_tests.Add( new List<string>{ "1234", "1567", "-2", "computer science" } );
                list_tests.Add( new List<string>{ "Russia", "Denmark", "Kazan" } );

                //
                // Меню
                //
                Console.WriteLine( "Доступные числовые команды:" );
                Console.WriteLine( "0 -> Задать собственный массив:" );
                for ( int i = 0; i < list_tests.Count; i++ ) {
                    Console.WriteLine( $"{ i + 1 } -> Использовать массив: { ArrayToString( list_tests[i].ToArray() ) }" );
                }
                Console.WriteLine( "9 -> Выход из программы" );
                Console.Write( "\nВведите числовую команду: " );

                //
                // Обработка ввода пользователя
                //
                int command_id;
                if ( int.TryParse( Console.ReadKey().KeyChar.ToString() ?? "", out command_id ) ) {
                    Console.WriteLine();

                    // Завершение программы
                    if ( command_id == 9 ) {
                        Console.WriteLine( "\n[+] Работа программы успешно завершена\n" );
                        Environment.Exit(0);
                    }

                    // Конструктор массива
                    else if ( command_id == 0 )
                        ConsoleWriteResult( GetStrinToArray() );

                    // Использовать тестовые пресаты
                    else if ( command_id > 0 && command_id <= list_tests.Count )
                        ConsoleWriteResult( list_tests[command_id - 1].ToArray() );

                    // Нет такой числовой команды
                    else
                        Console.WriteLine("[!!!] Вы ввели не верную числовую команду, пожалуйста будьте внимательнее!\n");

                }

                // Нажата не числовая кнопка
                else
                    Console.WriteLine("\n[!!!] Если вы хотели задать массив, нажмите 0, для перехода в режим ввода!\n");
            }
        }
    }
}
