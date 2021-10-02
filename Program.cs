using System;

enum Menu
{
    PlayGame = 1,
    Exit = 2
}


namespace Midterm1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMenuScreen();
        }

        static void PrintMenuScreen() //หน้าแรก
        {
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Play game");
            Console.WriteLine("2. Exit");
            InputSelectMenu();
        }

        static void InputSelectMenu() //เลือกเมนูในหน้าแรก
        {
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu) //แสดงหน้าเมนูที่เลือก
        {
            if (menu == Menu.PlayGame)
            {
                ShowHangManGame();
            }
            else if (menu == Menu.Exit)
            {
            }
            else
            {
                ShowMessageInputMenuIsIncorrect();
            }
        }

        static void ShowHangManGame() //หน้าเกม+สร้างinstance
        {
            Console.Clear();
            HangMan randomWord = new HangMan();
            randomWord.GetRandomWord();
            CreateGame(randomWord);
        }
        static void CreateGame(HangMan randomWord) //หน้าแสดงผล+แสดงคำที่สุ่มมา
        {
            PrintHangManHead(randomWord);
            randomWord.CreateBlank(randomWord.usingWord);
            randomWord.UpdateBlank(randomWord.usingWord, InputLetterAlphabetFromKeyBoard());
            CheckIncorrectScore(randomWord);

            do
            {
                Console.Clear();
                PrintHangManHead(randomWord);
                for (int i = 0; i < randomWord.usingWord.Length; i++) //ใส่คำ
                {
                    Console.Write(" {0}", randomWord.blank[i]);
                }
                randomWord.UpdateBlank(randomWord.usingWord, InputLetterAlphabetFromKeyBoard());
                CheckIncorrectScore(randomWord);
                
            }
            while (EndCodition(randomWord.incorrectScore,randomWord.usingWord,randomWord.blank)==false);

        }

        static void CheckIncorrectScore(HangMan randomWord) //เพิ่มincorrectScoreเมื่อผิด
        {
            if (randomWord.incorrectCount == randomWord.usingWord.Length)
            {
                randomWord.incorrectScore += 1;
            }
            randomWord.incorrectCount = 0;
        }

        static bool EndCodition(int incorrectScore, string usingWord, char[] blank) //เงื่อนไขจบการทำงาน--> เมื่อผิดครบ6ครั้งหรือทายถูกทุกตัว
        {
            bool end = false;
            string blankWord = new string(blank);
            if(incorrectScore == 6)
            {
                Console.WriteLine("Game Over");
                end = true;
            }
            else if (blankWord == usingWord)
            {
                Console.WriteLine("Your Win !!");
                end = true;
            }
            return end;
        }

        static void PrintHangManHead(HangMan randomWord) //หน้าเกม
        {
            Console.WriteLine("Play Game HangMan");
            Console.WriteLine("-----------------");
            Console.WriteLine("Incorrect Score : " + randomWord.incorrectScore);
        }

        static char InputLetterAlphabetFromKeyBoard() //รับตัวอักษร
        {
            Console.Write("\nInput letter alphabet: ");
            return char.Parse(Console.ReadLine());
        }
        
        static void ShowMessageInputMenuIsIncorrect() //ผู้ใช้กรอกเมนูผิด
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again");

            InputSelectMenu();
        }

    }
}
