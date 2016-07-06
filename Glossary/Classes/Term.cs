using System;
using System.Collections.Generic;
using System.Text;


namespace Glossary.Classes
{
    [Serializable]
    public class Term
    {
        private String[] russian = new string[3];
        private String[] english = new string[3];
        private String determination;
        private String category;

        public Term(String[] russian, String[] english, String determination, String category)
        {
            setRussian(russian);
            setEnglish(english);
            setDetermination(determination);
            setCategory(category);
        }

        /*
         Данный метод возвращает массив русских терминов в виде одной строки текста, разделенной
         запятыми. 
        */

        public String getRussianAsString()
        {
            StringBuilder russianStr = new StringBuilder();

            for (int i = 0; i < russian.Length; i++)
            {
                if (russian[i] != "")
                    russianStr.Append(russian[i] + ", ");
            }

            if (russianStr[russianStr.Length - 2] == ',')
            {
                russianStr.Remove(russianStr.Length - 2, 2);
            }

            return russianStr.ToString();
        }

        public String[] getRussianAsArray()
        {
            return russian;
        }

        /*
         Данный метод возвращает массив английских терминов в виде одной строки текста, разделенной
         запятыми. 
        */

        public String getEnglishAsString()
        {
            StringBuilder englishStr = new StringBuilder();

            for (int i = 0; i < english.Length; i++)
            {
                if (english[i] != "")
                    englishStr.Append(english[i] + ", ");
            }

            if (englishStr[englishStr.Length - 2] == ',')
            {
                englishStr.Remove(englishStr.Length - 2, 2);
            }

            return englishStr.ToString();
        }

        public String[] getEnglishAsArray()
        {
            return english;
        }

        /*
         Данный метод возвращает определение термина в виде строки текста.
        */

        public String getDetermination()
        {
            return determination;
        }
        /*
         Данный метод возвращает категорию термина в виде строки текста.
        */

        public String getCategory()
        {
            return category;
        }
        /*
         Данный принимает массив русских слов и добавляет его в объкт.
        */

        public void setRussian(String[] russian)
        {
            this.russian = russian;
            makeShiftInTheArray(russian);
        }

        /*
         Данный метод принимает массив английских слов и добавляет его в объект.
        */

        public void setEnglish(String[] english)
        {
            this.english = english;
            makeShiftInTheArray(english);
        }

        /*
         Данный метод принимает строку с определением термина и добавляет её в объект.
        */

        public void setDetermination(String determination)
        {
            this.determination = determination;
        }
        /*
        Данный метод принимает строку с категорией термина и добавляет её в объект
        */
        public void setCategory(String category)
        {
            this.category=category;
        }
        /*
         Данный метод сдвигает все не пустые значения в начало массива так, чтобы 
         пустые оказались в конце списка.
        */

        private void makeShiftInTheArray(String[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i; j < array.Length - 1; j++)
                {
                    if (array[j] == "" && array[j + 1] != "")
                    {
                        String temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
