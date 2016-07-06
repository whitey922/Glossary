using Glossary.Classes.Exceptions;
using Glossary.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Glossary
{
    //класс с описанием сущности Категорий
    [Serializable]
   public class Catigories
    {
        //поле листа с уже существующими данными
        private List<String> catigoriesList = new List<String>();

        //геттер для листа
        public List<String> CatigoriesList
        {
            get { return catigoriesList; }
        }

        //удаление из листа
        public void remove(String category)
        {
            CatigoriesList.Remove(category);
        }

        //добавление в лист
        public void add(String category)
        {
            try
            {
                String pattern = @"^[\w-]{1,30}$";
                Regex reg = new Regex(pattern);

                if (!reg.IsMatch(category))
                    throw new InvalidTermException();
                else CatigoriesList.Add(category);
            }
            catch (InvalidTermException)
            {
                MessageBox.Show("Название категории должно содержать латинские символы, русские и знак - .", "Ошибка ввода!");
            }
        }

        //изменение в листе
        public void change(String newСategory, String previousCategory)
        {
            for (int i = 0; i < CatigoriesList.Count; i++)
            {
                if(CatigoriesList[i]==previousCategory) CatigoriesList[i] = newСategory;
            }
        }

        //закрытый конструктор
        private Catigories() { }

        //поле для доступа к объекту
        private static Catigories instance;
        //серреализация
        public static void serialize()
        {
            // BinaryFormatter сохраняет данные в двоичном формате. Чтобы получить доступ к BinaryFormatter, понадобится
            // импортировать System.Runtime.Serialization.Formatters.Binary
            BinaryFormatter binFormat = new BinaryFormatter();
            // Сохранить объект в локальном файле.
            try
            {
                using (Stream fStream = new FileStream("categories.dat",
              FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, Catigories.Instance.CatigoriesList);
                }
            }
            catch (FileNotFoundException)
            {
                new Idiot().ShowDialog();
            }
        }


        //десерреализация файла
        public static void deserialize()
        {
            try
            {
                using (Stream fStream = new FileStream("categories.dat",
               FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    var formatter = new BinaryFormatter();
                    List<String> listOfCategories = (List<String>)formatter.Deserialize(fStream);
                    Catigories.Instance.catigoriesList = listOfCategories;
                }
            }
            catch (FileNotFoundException)
            {
                new Idiot().ShowDialog();
            }

        }
        //паттерн Singleton - создаем объект один раз
        public static Catigories Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Catigories();
                }
                return instance;
            }
        }
        }
}
