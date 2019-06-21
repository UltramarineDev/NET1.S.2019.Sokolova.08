All done

1.(deadline - 05.04.2019, 24.00) ("3-ий перезапуск" НОД-а) 

DONE.(NumbersManipulations - GCDNew3.cs, AssemblyForTask1Day8 - GCDNew3Decorator.cs - <a href="https://github.com/UltramarineDev/NET.S.2019.Sokolova.03"> see in Day3</a>)

Есть унификация алгоритма нахождения НОД-а для двух целочисленных значений в виде интерфейса

  public interface IGcdAlgorithm
  {
      int Calculate(int first, int second);
  }

c реализацией в виде классов EuclideanGcdAlgorithm и BinaryGcdAlgorithm (доступ к коду классов для их измения не возможен, назовем эту сборку условно #1.dll). Предложить варианты расширения функциональности существующих (и новых) алгоритмов вычисления НОД-а, предлагающие возможность при вычислении определять показания времени работы алгоритма, рассмотреть возможность настройки алгоритма в контексте предоставления различных реализаций измерения времени.(Решения поместить в сборку #2.dll). 


2. (deadline - 06.04.2019 24.00) 
DONE. See in <a href="https://github.com/UltramarineDev/NET.S.2019.Sokolova.07/tree/master/ArrayManipulations">Day7</a>

Добавить в статический класс ArrayExtension (Day 7) метод расширения для сортировки непрямоугольного ("jagged") целочисленного массива (матрицы) таким образом, чтобы была возможность, в частности, упорядочить строки матрицы:

 - в порядке возрастания(убывания) сумм элементов ее строк;
 - в порядке возрастания(убывания) максимальных элементов ее строк;
 - в порядке возрастания(убывания) минимальных элементов ее строк.
Разработать unit-тесты.

3.(deadline - 07.04.2019 24.00) - done

 - Разработать класс Book (ISBN, автор, название, издательство, год издания, количество страниц, цена), переопределив для него необходимые методы класса Object. Для объектов класса реализовать отношения эквивалентности и порядка (используя соответствующие интерфейсы).

  public class Book : IEquatable<Book>, IComparable<Book>
  {
      public string Author { get; set; }
      public string Title { get; set; }
      ...
  }

Для выполнения основных операций со набором книг, который можно загрузить (Load) и, если возникнет необходимость, сохранить (Save) в некоторое хранилище BookListStorage разработать класс BookListService (как сервис для работы с коллекцией книг) с функциональностью AddBook (добавить книгу, если такой книги нет, в противном случае выбросить исключение); RemoveBook (удалить книгу, если она есть, в противном случае выбросить исключение); FindBookByTag (найти книгу по заданному критерию); SortBooksByTag (отсортировать список книг по заданному критерию), при реализации делегаты не использовать!

public interface IBookListStorage
	{
	    IEnumerable<Book> LoadBooks();
	    void SaveBooks(IEnumerable<Book> books);
	}

 - В качестве хранилища пока использовать FakeBookListStorage как обертку для списка книг, который хранится в памяти ("in memory dataset"). Данное хранилище пока используется для целей тестирования. В дальнейшем хранилище будет изменяться.

 - (deadline - 08.04.2019 24.00) - done
Продемонстрировать возможности работы с системой типов в ASP.NET MVC приложении.
