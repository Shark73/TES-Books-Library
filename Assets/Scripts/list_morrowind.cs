using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class list_morrowind : MonoBehaviour
{
    public GameObject button_caption;
    private Object[] books;// Объект с названиями книг
    private static string[] book_mor = new string[128]; // Массив с названиями книг 
    private static int Current_Page = 0; // Текущая страница в списке книг
    public string selectedBook;

    public GameObject books_1;
    public GameObject books_2;
    public GameObject books_3;
    public GameObject books_4;
    public GameObject books_5; // заранее заявленные кнопки
    public GameObject allBooks; // Это чтобы красиво скрывать их в начале. ВРеменная переменная

  


    

    void OnMouseDown()
    {
        if (button_caption.name == "Button_Morrowind")
        {
            Debug.Log("Это Морровинд!");
            books = Resources.LoadAll("Books", typeof(Object)); // получение списка книг из папки 

            int i = 0;
             foreach (var t in books)
             {
                book_mor[i] = t.name;
                i++;
                
             }
            //             GameObject.Find("Книжки").SetActive(true);
            allBooks.SetActive(true);

             books_1.GetComponentInChildren<Text>().text = book_mor[0];
             books_2.GetComponentInChildren<Text>().text = book_mor[1]; 
             books_3.GetComponentInChildren<Text>().text = book_mor[2]; 
             books_4.GetComponentInChildren<Text>().text = book_mor[3]; 
             books_5.GetComponentInChildren<Text>().text = book_mor[4];
             Current_Page = 1;

        }
        else if (button_caption.name == "Button_Oblivion")
        {
            Debug.Log("Книги по Обливиону в разработке!");
        }
        else if(button_caption.name == "Button_Skyrim")
        {
            Debug.Log("Книги по Скайриму в разработке!");
        }
        else if (button_caption.name == "Button_Test")
        {
            GameObject.Find("Button_Skyrim").SetActive(!isActiveAndEnabled);
            Debug.Log("Тестов нет!");
        }
        else if (button_caption.name == "Next")
        {
            Current_Page += 5;
            books_1.GetComponentInChildren<Text>().text = book_mor[Current_Page];
            books_2.GetComponentInChildren<Text>().text = book_mor[Current_Page+1];
            books_3.GetComponentInChildren<Text>().text = book_mor[Current_Page+2];
            books_4.GetComponentInChildren<Text>().text = book_mor[Current_Page+3];
            books_5.GetComponentInChildren<Text>().text = book_mor[Current_Page+5];

        }
        else if (button_caption.name == "Prev")
        {
            Current_Page -= 5;
            books_1.GetComponentInChildren<Text>().text = book_mor[Current_Page];
            books_2.GetComponentInChildren<Text>().text = book_mor[Current_Page + 1];
            books_3.GetComponentInChildren<Text>().text = book_mor[Current_Page + 2];
            books_4.GetComponentInChildren<Text>().text = book_mor[Current_Page + 3];
            books_5.GetComponentInChildren<Text>().text = book_mor[Current_Page + 5];

        }

        else if (button_caption.name == "Button_Exit")
        {
            Application.Quit();
        }
        else //if(button_caption.name == "")// А тут проверка, что мы выбрали книгу
        {
            selectedBook = button_caption.GetComponentInChildren<Text>().text; // Переменная, хранящая выбранную книгу. Передать значение на другую сцену
            PlayerPrefs.SetString("selectedBook", selectedBook);
            SceneManager.LoadScene("Book");
        }
    }

}


/*
 * 
 * 
 * 
 * 
 * Система:
 *Надо научиться брать внешние, не связанные переменные. В том числе с других сцен. ЧТоб совсем глобальные. И к объектам обращаться так (Через файнд можно попробовать). В будущем поможет
 *Продумать деление книг СКАЙ/МОР/ОБЛ, как это оптимальнее реализовать (Наверн прост по папкам разным, но хз)
 * 
 * 
 * 
 * Интерфейс:
 * При открытии программы, скрыть первоначальный список книг, и сделать, чтобы появлялись, только при выборе игры
 * Окна растягиваются, в зависимости от экрана
 * 
 * 
 * 
 *Оптимизация:
 *Разделить сцену главного меню и списка книг
 *Сделать кнопки с книгами не заранее определенными, а динамически создающимися (А в будущем даже чтоб пользователь сам задавал количество книг на страницу)
 *Заранее прогружать книжки, при входе в приложение. Чтоб не подвисало
 *
 *
 *
 *
 *Подсказки для дебила:
 *Чтобы переменные не обнулялись, в объявлении надо писать static
 *К static переменным можно как-то обращаться, типа Class.zalupa
 *
 *
 *
 *Дорожная карта
 *0.1 - базовый интерфейс +
 *0.2 - базовые механики  60%
 *0.4 - отображение загруженных книг
 *0.5 - форматирование текста
 *0.7 - автоматическое подстраивание интерфейса под разрешение устройства
 *0.8- заполнение библиотеки
 *0.9 - завершение оформления (Интерфейс, красивые кнопочки, анимации, музыка)
 *1.0 - релиз
 *
 *
 *
 *
 *
 *
 */