using System;

class HangMan
{
    public int incorrectScore;
    public int incorrectCount;
    public string[] word;
    public string usingWord;
    public char[] blank;

    public HangMan()
    {
        this.word = new string[] { "tennis", "football", "badminton" };
        this.incorrectScore = 0;
    }

    public void GetRandomWord() //สุ่มคำ
    {
        Random random = new Random();
        int resultRandom = random.Next(0, 2);
        usingWord = word[resultRandom];
    }
    public void CreateBlank(string word) //สร้าง _ _ ตามจำนวนคำที่สุ่ม
    {
        blank = new char[word.Length];

        for (int i = 0; i < usingWord.Length; i++)
        {
            blank[i] = '_';
            Console.Write(" {0}", blank[i]);
        }
    }

    public void UpdateBlank(string word,char letter) //อัพเดทช่องว่างและเช็คตัวอักษร
    {
        char[] check = word.ToCharArray();
        for (int i = 0; i < word.Length; i++) //สำหรับเช็คคำ
        {
            if (letter == check[i]) //ตัวอักษรตรงกัน
            {
                blank[i] = letter;
            }
            else
            {
                blank[i] = blank[i];
                incorrectCount += 1;
            }
        }
    }
}
