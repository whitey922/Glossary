using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Glossary.Classes.Exceptions;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Glossary.Forms;

namespace Glossary.Classes
{
    [Serializable]
    public class Terms
    {
        private static List<Term> terms = new List<Term>();

        /*
         Метод addTerm() принимает массив русских и английских аналогов термина и строку определения термина.
         В начале идет вызов методов для проверки корректности введенных параметров, который возвращают либо массив, 
         что свидетельствует о том, что проверка пройдена, либо значение null - проверка не пройдена и массивы 
         остались пустыми. Далее проводится проверка на то, пустые массивы или нет, если не пустые то идет добавление
         термина в список, иначе не происходит ничего.
        */

        public static bool addTerm(String[] russian, String[] english, String determination, String categories)
        {
            String[] checkedRussian = checkRussian(russian);
            String[] checkedEnglish = checkEnglish(english);
            String checkedDetermination = checkDetermination(determination);
            String category = checkCategory(categories);
            if (checkedRussian != null && checkedEnglish != null && checkedDetermination != null && checkedDetermination != null)
            {
                if (MessageBox.Show("Входные данные корректны, вы уверены, что хотите добавить термин?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    terms.Add(new Term(russian, english, determination, category));
                    return true;
                }
            } return false;
        }

        public static void removeTerm(int index)
        {
            if (index >= 0 && index < terms.Count)
                if (MessageBox.Show("Вы уверены, что хотите удалить выбраный термин?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    terms.RemoveAt(index);
        }

        /*
         Метод editTerm() принимает индекс термина в списке терминов, массив русских и английских аналогов термина
         и строку определения термина. Далее проводится проверка входных данных посредством выховов соответствующих методов.
         Методы проверки возвращают либо массив данных если проверка пройдена, либо null если проверка не пройдена.
         Далее проводится проверка на null и если всё в порядке то идет замена данных для текущего эл-та списка.
        */

        public static bool editTerm(int index, String[] russian, String[] english, String determination, String category)
        {
            String[] checkedRussian = checkRussian(russian);
            String[] checkedEnglish = checkEnglish(english);
            String checkedDetermination = checkDetermination(determination);
            String checkedCategory = checkCategory(category);
            if (checkedRussian != null && checkedEnglish != null && checkedDetermination != null && checkedCategory != null)
            {
                if (MessageBox.Show("Входные данные корректны, вы уверены, что хотите изменить термин?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    terms[index].setRussian(russian);
                    terms[index].setEnglish(english);
                    terms[index].setDetermination(determination);
                    terms[index].setCategory(category);
                    return true;
                }
            } return false;
        }

        /*
         Метод checkRussian() необходим для проверки входных данных а именно массива русских аналогов термина.
         Метод проверяет, из русских ли букв состоят слова. Если найдены другие символы кроме русских букв или пробела - 
         метод бросает исключение InvalidTermException(), которое перехватывается ниже, при этом выводится сообщение об 
         ошибке и метод прекращает выполнение кода. Если же первая проверка пройдена - идет проверка на то, пустой ли массив.
         Если пустой то метод бросает исключение EmptyTermException(), который перехватывается ниже, при этому выводится сообщение об
         ошибке и метод прекрадает выполнение кода. Если и эта проверка пройдена то метод возвращает массив, что свидетельствует о том,
         что проверка пройдена.         
        */

        private static String[] checkRussian(String[] russian)
        {
            try
            {
                String pattern = @"^[А-я-]{1,30}$";
                Regex reg = new Regex(pattern);


                for (int i = 0; i < russian.Length; i++)
                {
                        if(!reg.IsMatch(russian[i]))
                                throw new InvalidTermException();
                }
            }
            catch (InvalidTermException)
            {
                MessageBox.Show("Один из введенных русских аналогов содержит не русские буквы.", "Ошибка ввода!");
                return null;
            }

            try
            {
                int empty = 0;
                for (int i = 0; i < russian.Length; i++)
                {
                    if (russian[i] == "")
                        empty++;
                }

                if (empty == 3)
                    throw new EmptyTermException();
            }
            catch (EmptyTermException)
            {
                MessageBox.Show("Не введен ни один русский аналог термина.", "Ошибка ввода!");
                return null;
            }

            return russian;
        }

        /*
         Метод checkEnglish() аналогичен методу checkRussian(), но первая проверка идет на наличие каких либо символов кроме английских и пробелов.
        */

        private static String[] checkEnglish(String[] english)
        {
            String pattern = @"^[A-z-!]{1,30}$";
            Regex reg = new Regex(pattern);
            try
            {
                for (int i = 0; i < english.Length; i++)
                {
                    if (!reg.IsMatch(english[i]))
                        throw new InvalidTermException();
                }
            }
            catch (InvalidTermException)
            {
                MessageBox.Show("Один из введенных английских аналогов содержит не английские символы", "Ошибка ввода!");
                return null;
            }

            try
            {
                int empty = 0;
                for (int i = 0; i < english.Length; i++)
                {
                    if (english[i] == "")
                        empty++;
                }

                if (empty == 3)
                    throw new EmptyTermException();
            }
            catch (EmptyTermException)
            {
                MessageBox.Show("Не введен ни один английский аналог термина.", "Ошибка ввода!");
                return null;
            }

            return english;
        }

        /*
         Метод checkDetermination() проводит проверку, пустая ли входная строка, если пустая - метод бросает исключение
         EmptyTermException() который перехватывается ниже и выводится сообщение об ошибке после чего метод возвращает
         null, что говорит о том, что проверка не пройдена, иначе возвращается входная строка.
        */

        private static String checkDetermination(String determination)
        {
            String pattern = @"^[\w-!]{1,100}$";
            Regex reg = new Regex(pattern);
            try
            {
                    if (!reg.IsMatch(determination))
                        throw new EmptyTermException();
            }
            catch (EmptyTermException)
            {
                MessageBox.Show(@"Ошибка ввода определения. Определение должно содержать любой текстовый символ, включая пробел ! и -.", "Ошибка ввода");
                return null;
            }
            return determination;
        }

        /*
        Метод checkDetermination() проводит проверку, пустая ли входная строка, если пустая - метод бросает исключение
        EmptyTermException() который перехватывается ниже и выводится сообщение об ошибке после чего метод возвращает
        null, что говорит о том, что проверка не пройдена, иначе возвращается входная строка.
       */

        private static String checkCategory(String category)
        {
            try
            {
                if (category == "" || category == null)
                    throw new EmptyTermException();
               
            }
            catch (EmptyTermException)
            {
                MessageBox.Show("Категория не выбрана.", "Ошибка ввода");
                return null;
            }
            return category;
        }

        public static String getRussianAsString(int index)
        {
            return terms[index].getRussianAsString();
        }

        public static String[] getRussianAsArray(int index)
        {
            return terms[index].getRussianAsArray();
        }

        public static String getEnglishAsString(int index)
        {
            return terms[index].getEnglishAsString();
        }

        public static String[] getEnglishAsArray(int index)
        {
            return terms[index].getEnglishAsArray();
        }

        public static String getDetermination(int index)
        {
            return terms[index].getDetermination();
        }

        public static String getCategory(int index)
        {
            return terms[index].getCategory();
        }

        public static int getIndex(String russian, String english, String determination)
        {
            int index = 0;
            String[] russianArray = { "", "", "" };
            String[] englishArray = { "", "", "" };
            for (int i = 0; i < russian.Split(',').Length; i++)
            {
                russianArray[i] = russian.Split(',')[i].TrimStart(' ');
            }
            for (int i = 0; i < english.Split(',').Length; i++)
            {
                englishArray[i] = english.Split(',')[i].TrimStart(' ');
            }

            foreach (Term term in terms)
            {
                if (term.getRussianAsArray()[0] != russianArray[0] ||
                    term.getRussianAsArray()[1] != russianArray[1] ||
                    term.getRussianAsArray()[2] != russianArray[2])
                    continue;
                if (term.getEnglishAsArray()[0] != englishArray[0] ||
                    term.getEnglishAsArray()[1] != englishArray[1] ||
                    term.getEnglishAsArray()[2] != englishArray[2])
                    continue;
                if (term.getDetermination() != determination)
                    continue;
                index = terms.IndexOf(term);

            }

            return index;
        }

        public static void serializeOfList()
        {
            try
            {
                // BinaryFormatter сохраняет данные в двоичном формате. Чтобы получить доступ к BinaryFormatter, понадобится
                // импортировать System.Runtime.Serialization.Formatters.Binary
                BinaryFormatter binFormat = new BinaryFormatter();
                // Сохранить объект в локальном файле.
                using (Stream fStream = new FileStream("data.dat",
                   FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, terms);
                }
            }
            catch (FileNotFoundException)
            {
                new Idiot().ShowDialog();
            }
        }


        //десерреализация файла
        public static void deserializeOfList()
        {
            try
            {
                using (Stream fStream = new FileStream("data.dat",
                               FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    var formatter = new BinaryFormatter();
                    List<Term> listOfTerms = (List<Term>)formatter.Deserialize(fStream);
                    terms = listOfTerms;
                }
            }
            
             catch (FileNotFoundException)
            {
                new Idiot().ShowDialog();
            }
        }
        /*
        Метод поиска по значению термина
        */
        public static Term search(String inputSearch)
        {
            try
            {
                for (int i = 0; i < terms.Count; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (terms[i].getEnglishAsArray()[j] == inputSearch || terms[i].getRussianAsArray()[i] == inputSearch) return Terms.terms[i];
                        else throw new EmptySearch();
                    }

                }
            }
            catch (EmptySearch)
            {
                MessageBox.Show("Ничего не найдено", "Поиск");

            }
            return null;

        }

        public static List<Term> search(String[] inputSearch)
        {
            List<Term> lstTerm = new List<Term>(); 
            try
            {
                for (int i = 0; i < terms.Count; i++)
                {
                    for (int j = 0; j < inputSearch.Length; j++)
                    {
                        if (terms[i].getCategory() == inputSearch[j])
                        {
                            lstTerm.Add(terms[i]);
                        } 
                        else throw new EmptySearch();
                    }

                }
            }
            catch (EmptySearch)
            {
                MessageBox.Show("Ничего не найдено", "Поиск");

            }
            return lstTerm;
        }
        public static int getCount()
        {
            return terms.Count;
        }
    }
}