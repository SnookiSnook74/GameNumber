using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox_Modul_3
{
    #region HomeWork-3

    // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

    // Требуемый опыт работы: без опыта
    // Частичная занятость, удалённая работа
    //
    // Описание 
    //
    // Стартап «Micarosppoftle» занимающийся разработкой
    // многопользовательских игр ищет разработчиков в свою команду.
    // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
    // но желающих развиваться в сфере разработки игр на платформе .NET.
    //
    // Должность Интерн C#/
    //
    // Основные требования:
    // C#, операторы ввода и вывода данных, управляющие конструкции 
    // 
    // Конкурентным преимуществом будет знание процедурного программирования.
    //
    // Не технические требования: 
    // английский на уровне понимания документации и справочных материалов
    //
    // В качестве тестового задания предлагается решить следующую задачу.
    //
    // Написать игру, в которою могут играть два игрока.
    // При старте, игрокам предлагается ввести свои никнеймы.
    // Никнеймы хранятся до конца игры.
    // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
    // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
    // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
    // введенное число вычитается из gameNumber
    // Новое значение gameNumber показывается игрокам на экране.
    // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
    // Игра поздравляет победителя, предлагая сыграть реванш
    // 
    // * Бонус:
    // Подумать над возможностью реализации разных уровней сложности.
    // В качестве уровней сложности может выступать настраиваемое, в начале игры,
    // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

    // *** Сложный бонус
    // Подумать над возможностью реализации однопользовательской игры
    // т е игрок должен играть с компьютером


    // Демонстрация
    // Число: 12,
    // Ход User1: 3
    //
    // Число: 9
    // Ход User2: 4
    //
    // Число: 5
    // Ход User1: 2
    //
    // Число: 3
    // Ход User2: 3
    //
    // User2 победил!

    #endregion
    class Game
    {
        //Имена игроков
        private string player1,player2,player3,player4;
        //Случайное число с которого начинается игра
        private int gameNumber;
        //Значение которое введет пользователь
        private int userTry;
        //Проверка какой из двух игроков ходит(true - первый, false-2) *применяется только в игре на двоих
        private bool oneOrtwo = true;
        //Переменная которая позволяет поочередно давать ход игрокам. *Используется для игры на 4 человек
        private int playerCount;
        //Генератор случайного числа
        private Random randomNumber = new Random();

        /// <summary>
        /// Легкий уровень сложности
        /// </summary>
        public void StartEasy()
        {
            //Создаем случайное число в диапозоне от 12 до 120
            gameNumber = randomNumber.Next(12, 120);
            Console.WriteLine($" {"Добро пожаловать в игру \"Занимательные числа\"", 50}");
            Console.WriteLine("Введите имя первого игрока:");
            player1 = Console.ReadLine();
            Console.WriteLine("Введите имя второго игрока:");
            player2 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Приветсвую Вас {player1} и {player2} загаданное число: {gameNumber}");
            Console.WriteLine($"Ваша задача уменьшить это число до 0 используя числа 1,2,3,4");
            Console.WriteLine($"Побеждает тот игрок ход которого окажется последним");
            Console.WriteLine();

            //Запускаем цикл до момента пока загаданное число не станет равно 0
            while (gameNumber>0)
            {
                Console.WriteLine($"Число: {gameNumber}");
                //В зависимости от того какое значение принимает переменная oneOrTwo true(ходит первый игрок) или false(ходит второй игрок)
                Console.WriteLine("Ходит {0}", oneOrtwo ? player1:player2);
                userTry = Convert.ToInt32(Console.ReadLine());

                    //Пока значнеие верно крутим цикл
                    while (userTry > 4 || userTry <= 0)
                    {
                        Console.WriteLine("Введите число в диапозоне от 1 до 4");
                        userTry = Convert.ToInt32(Console.ReadLine());
                    }
                    //Записываем новое значение в игровое число, для этого вычитаем из текущего числа, число которое написал игрок
                    gameNumber -= userTry;
                    //Меняем значение на противоположное 
                    oneOrtwo=!oneOrtwo;
            }
            //После выхода из цикла выводим имя победителя
            Console.WriteLine("Победа за {0}! \n{1} Попробуйте взять реванш в следующей игре!", oneOrtwo?player2:player1, oneOrtwo ? player1 : player2);
            Console.ReadKey();

        }
        /// <summary>
        /// Тяжелый уровень сложности
        /// </summary>
        public void StartHard()
        {
            //Загадываем случайное число с которого начнется игра, но диапозон значений и шаг для хода выше. В остальном метод работает также как и StartEasy
            gameNumber = randomNumber.Next(12, 555);
            Console.WriteLine($" {"Добро пожаловать в игру \"Занимательные числа\"",50}");
            Console.WriteLine("Введите имя первого игрока:");
            player1 = Console.ReadLine();
            Console.WriteLine("Введите имя второго игрока:");
            player2 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Приветсвую Вас {player1} и {player2} загаданное число: {gameNumber}");
            Console.WriteLine($"Ваша задача уменьшить это число до 0 используя числа от 1 до 10");
            Console.WriteLine($"Побеждает тот игрок ход которого окажется последним");
            Console.WriteLine();

            while (gameNumber > 0)
            {
                Console.WriteLine($"Число: {gameNumber}");
                Console.WriteLine("Ходит {0}", oneOrtwo ? player1 : player2);
                userTry = Convert.ToInt32(Console.ReadLine());

                while (userTry > 10 || userTry <= 0)
                {
                    Console.WriteLine("Введите число в диапозоне от 1 до 10");
                    userTry = Convert.ToInt32(Console.ReadLine());
                    
                }

                gameNumber -= userTry;
                oneOrtwo = !oneOrtwo;
            }

            Console.WriteLine("Победа за {0}! \n{1} Попробуйте взять реванш в следующей игре!", oneOrtwo ? player2 : player1, oneOrtwo ? player1 : player2);
            Console.ReadKey();

        }
        /// <summary>
        /// Игра против Компьютера
        /// </summary>
        public void StartSolo()
        {
            //Загадываем случайное число с которого начнется игра
            gameNumber = randomNumber.Next(12, 120);
            Console.WriteLine($" {"Добро пожаловать в игру \"Занимательные числа\"",50}");
            Console.WriteLine("Введите имя первого игрока:");
            player1 = Console.ReadLine();
            //Даем имя нашему компьютеру
            player2 = "ArtificialIntelligence";
            Console.Clear();
            Console.WriteLine($"Приветсвую Вас {player1} загаданное число: {gameNumber}");
            Console.WriteLine($"Ваша задача уменьшить это число до 0 используя числа от 1 до 4");
            Console.WriteLine($"Побеждает тот игрок ход которого окажется последним");
            Console.WriteLine();
            Random randomAI = new Random();

            //Крутим цикл пока загаданное число больше 0
            while (gameNumber > 0)
            {
                Console.WriteLine($"Число: {gameNumber}");
                //Говорим кто сейчас ходит игрок или компьютер
                Console.WriteLine("Ходит {0}", oneOrtwo ? player1 : player2);

                //Если ходит комьютер, генерируем случайное чилсо от 1 до 4
                if (oneOrtwo == false)
                {
                    userTry = randomNumber.Next(1, 5);
                    Console.WriteLine(userTry);
                }
                //Если ходит человек просим его ввести число
                else userTry = Convert.ToInt32(Console.ReadLine());

                //Входим в цикл для проверки введеного числа
                while (userTry > 4 || userTry <= 0)
                {
                    Console.WriteLine("Введите число в диапозоне от 1 до 4");
                    userTry = Convert.ToInt32(Console.ReadLine());
                    
                }
                //Из загаданного числа вычитаем число введенное игроком, получаем новое число с которого продолжится игра
                gameNumber -= userTry;
                //Меняем значнеие переменной для передачи хода к другому игроку
                oneOrtwo = !oneOrtwo;
            }

            Console.WriteLine("Победа за {0}! \n{1} Попробуйте взять реванш в следующей игре!", oneOrtwo ? player2 : player1, oneOrtwo ? player1 : player2);
            Console.ReadKey();

        }
        /// <summary>
        /// Игра на 4 человека
        /// </summary>
        public void Multigame()
        {
            //Задаем значение в переменную для инициализации игрока
            playerCount = 0;
            //Генерируем случайно число с которого начнется игра
            gameNumber = randomNumber.Next(12, 120);
            Console.WriteLine("Введите имя первого игрока: ");
            player1 = Console.ReadLine();
            Console.WriteLine("Введите имя второго игрока: ");
            player2 = Console.ReadLine();
            Console.WriteLine("Введите имя третьего игрока: ");
            player3 = Console.ReadLine();
            Console.WriteLine("Введите имя четвертого игрока: ");
            player4 = Console.ReadLine();

            //Переменная переключатель
            int counter = 1;
            //Переменная которая в зависимоти от переключателя присвает значение игроку
            string currentPlayer = player1;

            //Крутим цикл пока загаданное число больше 0
            while (gameNumber > 0)
            {
              
                switch (counter)
                {
                    case 1:
                        currentPlayer = player1;
                        break;
                    case 2:
                        currentPlayer = player2;
                        break;
                    case 3:
                        currentPlayer = player3;
                        break;
                    case 4:
                        currentPlayer = player4;
                        break;
                }
                
                Console.WriteLine($"Число: {gameNumber}");
                Console.WriteLine($"Ходит {currentPlayer}");
                userTry = Convert.ToInt32(Console.ReadLine());
                while (userTry>4 || userTry <= 0)
                {
                    Console.WriteLine("Введите число в диапозоне от 1 до 4");
                    userTry = Convert.ToInt32(Console.ReadLine());
                }
                counter++;
                if (counter == 5) counter = 1;
                gameNumber -= userTry;
            }
            Console.WriteLine($"Победил {currentPlayer}");
            //Заканчиваем игру
            Console.ReadKey();

        }


        static void Main(string[] args)
        {
            // Создаем новую игру
            Game game = new Game();
            //Спрашиваем игрока хочет ли он сыграть один или с друзьями
            Console.WriteLine("Вы хотите сыграть один? Введите да/нет");
            string solo = Console.ReadLine();
            //В зависимости от ответа направлем его в нужный метод
            if (solo.Equals("да")) game.StartSolo();
            else if (solo.Equals("нет"))
            {
                Console.WriteLine("Выбирите колличество игроков: 2 или 4");
                int countPlayer = Convert.ToInt32(Console.ReadLine());

                if (countPlayer == 2)
                {
                    Console.WriteLine("Выбери уровень сложности Easy or Hard");
                    string levl = Console.ReadLine();
                    if (levl.Equals("Hard") || levl.Equals("hard"))
                    {
                        Console.WriteLine("Отлично вы решили начать с уровня Hard");
                        Console.ReadKey();
                        Console.Clear();
                        game.StartHard();
                    }
                    else
                    {
                        Console.WriteLine("Отлично вы решили начать с уровня Easy");
                        Console.ReadKey();
                        Console.Clear();
                        game.StartEasy();
                    }
                }
                else
                {
                    Console.WriteLine("Вы начали игру на 4 игроков");
                    game.Multigame();
                }

            }

        }
    }

}
