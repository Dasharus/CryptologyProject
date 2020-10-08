using System;

namespace Task2Space
{
    interface ICipher
    {
        string Encode(string str);
        string Decode(string str);
    }
    enum LanguageAbr { Ukr, Rus, Eng };
    enum LanguageLettersAmount : int { UkrAmount = 33, RusAmount = 33, EngAmount = 26 };
    class Languages
    {
        private const string UkrAlphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        private const string RusAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const string EngAlphabet = "abcdefghijklmnopqrstuvwxyz";

        private LanguageAbr CurrentLanguage;
        private LanguageLettersAmount CurrentLettersAmount;
        private string CurrentAlphabet;

        public Languages()
        {
            SetLanguage(LanguageAbr.Eng);
        }

        public int LettersAmount
        {
            get
            {
                return (int)CurrentLettersAmount;
            }
        }

        public string Alphabet
        {
            get
            {
                return CurrentAlphabet;
            }
        }

        public char this[int index]
        {
            get
            {
                return CurrentAlphabet[index];
            }
        }

        public LanguageAbr Language
        {
            get
            {
                return CurrentLanguage;
            }

            set
            {
                SetLanguage(value);
            }
        }

        public void SetLanguage(LanguageAbr language)
        {
            if (language != CurrentLanguage)
            {
                switch (language)
                {
                    case LanguageAbr.Ukr:
                        CurrentLanguage = LanguageAbr.Ukr;
                        CurrentAlphabet = UkrAlphabet;
                        CurrentLettersAmount = LanguageLettersAmount.UkrAmount;
                        break;

                    case LanguageAbr.Rus:
                        CurrentLanguage = LanguageAbr.Rus;
                        CurrentAlphabet = RusAlphabet;
                        CurrentLettersAmount = LanguageLettersAmount.RusAmount;
                        break;

                    case LanguageAbr.Eng:
                        CurrentLanguage = LanguageAbr.Eng;
                        CurrentAlphabet = EngAlphabet;
                        CurrentLettersAmount = LanguageLettersAmount.EngAmount;
                        break;

                    default: break;
                }
            }
        }
    }
    class CeaserCipher : ICipher
    {
        private int n;

        private Languages CurrentLanguage = new Languages();

        private string Keys;

        public string GetAlphabet()
        {
            return CurrentLanguage.Alphabet;
        }

        private string GetKeys()
        {
            string KeysAlphabet = "";
            for (int i = 0; i < CurrentLanguage.LettersAmount; ++i)
            {
                if ((i + n) > 0)
                    KeysAlphabet += CurrentLanguage.Alphabet[(i + n) % CurrentLanguage.LettersAmount];
                else
                    KeysAlphabet += CurrentLanguage.Alphabet[(i + n + CurrentLanguage.LettersAmount) % CurrentLanguage.LettersAmount];
            }
            return KeysAlphabet;
        }

        public CeaserCipher()
        {
            this.n = 1;
            CurrentLanguage.SetLanguage(LanguageAbr.Eng);
            Keys = GetKeys();
        }

        public CeaserCipher(int n, LanguageAbr language)
        {
            this.n = n;
            CurrentLanguage.SetLanguage(language);
            Keys = GetKeys();
        }

        public int N
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
                Keys = GetKeys();
            }
        }

        public void SetLanguage(LanguageAbr language)
        {
            if (language != CurrentLanguage.Language)
            {
                CurrentLanguage.SetLanguage(language);
                Keys = GetKeys();
            }
        }

        public string Encode(string str)
        {
            str = str.ToLower();
            char[] CipherText = new char[str.Length];
            int index;
            int Cti = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                index = CurrentLanguage.Alphabet.IndexOf(str[i]);
                if (index != -1)
                {
                    CipherText[Cti++] = Keys[index];
                }
            }
            return (new string(CipherText));
        }

        public string Decode(string str)
        {
            str = str.ToLower();
            char[] CipherText = new char[str.Length];
            int index;
            int cin = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                index = Keys.IndexOf(str[i]);
                if (index != -1)
                {
                    CipherText[cin++] = CurrentLanguage.Alphabet[index];
                }
            }
            return (new string(CipherText));
        }

        public string GetCurrentKeys()
        {
            return Keys;
        }

        public bool SetKeys(string keys)
        {
            if (keys.Length == CurrentLanguage.LettersAmount)
            {
                bool[] flags = new bool[CurrentLanguage.LettersAmount];
                for (int i = 0; i < flags.Length; ++i)
                    flags[i] = false;
                int index = -1;
                for (int i = 0; i < CurrentLanguage.LettersAmount; ++i)
                {
                    index = CurrentLanguage.Alphabet.IndexOf(keys[i]);
                    if (index != -1)
                    {
                        if (flags[index] == true) return false;
                        flags[index] = true;
                    }
                    else return false;
                }

                if (Array.TrueForAll(flags, f => f == true))
                {
                    Keys = keys;
                    return true;
                }
                else return false;
            }
            else return false;
        }

    }
}