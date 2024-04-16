# Компилятор

Разработка текстового редактора с функциями языкового процессора.

## Оглавление

- [Лабораторная работа №1: Разработка пользовательского интерфейса (GUI) для языкового процессора](#лабораторная-работа-1-разработка-пользовательского-интерфейса-gui-для-языкового-процессора)
- [Лабораторная работа №2: Разработка лексического анализатора (сканера)](#лабораторная-работа-2-разработка-лексического-анализатора-сканера)
- [Лабораторная работа №3: Разработка синтаксического анализатора (парсера)](#лабораторная-работа-3-разработка-синтаксического-анализатора-парсера)
- [Лабораторная работа №4: Нейтрализация ошибок (метод Айронса)](#лабораторная-работа-4-нейтрализация-ошибок-метод-айронса)
- [Лабораторная работа №5: Включение семантики в анализатор. Создание внутренней формы представления программы](#лабораторная-работа-5-включение-семантики-в-анализатор-создание-внутренней-формы-представления-программы)
- [Лабораторная работа №6: Реализация алгоритма поиска подстрок с помощью регулярных выражений](#лабораторная-работа-6-реализация-алгоритма-поиска-подстрок-с-помощью-регулярных-выражений)
- [Лабораторная работа №7: Реализация метода рекурсивного спуска для синтаксического анализа](#лабораторная-работа-7-реализация-метода-рекурсивного-спуска-для-синтаксического-анализа)

## Лабораторная работа №1: Разработка пользовательского интерфейса (GUI) для языкового процессора

**Тема:** разработка текстового редактора с возможностью дальнейшего расширения функционала до языкового процессора.

**Цель работы:** разработать приложение с графическим интерфейсом пользователя, способное редактировать текстовые данные. Это приложение будет базой для будущего расширения функционала в виде языкового процессора.

**Язык реализации:** C#, Windows Forms.

### Интерфейс текстового редактора

![Главное окно программы](/README_images/main_window.png)

#### Получившийся текстовый редактор имеет следующие элементы:

1. Заголовок окна.

   Содержит информацию о названии открытого файла, полного пути к нему, а также о том, сохранен ли он на текущий момент (наличие символа звездочки справа от названия означает наличие несохраненных изменений).

2. Меню
   | Пункт меню | Подпункты |
   | ------ | ------ |
   | Файл | ![Главное окно программы](/README_images/menu_file.png) |
   | Правка | ![Правка](/README_images/menu_edit.png) |
   | Текст | ![Текст](/README_images/menu_text.png) |
   | Пуск | — |
   | Справка | ![Справка](/README_images/menu_help.png) |
3. Панель инструментов

   ![Панель инструментов](/README_images/toolbar.png)

   - Создать
   - Открыть
   - Сохранить
   - Изменить размер текста
   - Отменить
   - Повторить
   - Копировать
   - Вырезать
   - Вставить
   - Пуск
   - Вызов справки
   - О программе

4. Область редактирования

   Поддерживаются следующие функции:

   - Изменение размера текста
   - Открытие файла при перетаскивании его в окно программы
   - Базовая подсветка синтаксиса
   - Нумерация строк

5. Область отображения результатов

   В область отображения результатов выводятся сообщения и результаты работы языкового процессора.

   Поддерживаются следующие функции:

   - Изменение размера текста
   - Отображение ошибок в виде таблицы

6. Строка состояния

   В дополнении к информации, выводимой в заголовке окна, показываются текушие номера строки и столбца, где находится курсор.

### Справочная система

Разделы справочной системы открываются как HTML-документы в браузере.

| Раздел        | Изображение                                                               |
| ------------- | ------------------------------------------------------------------------- |
| Вызов справки | <img src="/README_images/help_click.png" alt="Вызов справки" width="500"> |

### Вывод сообщений

| Сообщение               | Описание                                                                                                       | 
| ----------------------- | -------------------------------------------------------------------------------------------------------------- | 
| Закрытие окна программы | Появляется при закрытии программы нажатием крестика или комбинацией клавиш при наличии несохраненных изменений | 
| Сохранение изменений    | Появляется при попытке открыть существующий файл или создать новый при наличии несохраненных изменений         | 

## Лабораторная работа №2: Разработка лексического анализатора (сканера)
Тема: разработка лексического анализатора (сканера).

Цель работы: изучить назначение лексического анализатора. Спроектировать алгоритм и выполнить программную реализацию сканера.

|№	|Тема|	Пример верной строки|
|---|---|---|
|27|	Объявление вещественной константы с инициализацией на языке С/С++|	const	double PI = 3.141592;|

В соответствии с вариантом задания необходимо:

Спроектировать диаграмму состояний сканера.
Разработать лексический анализатор, позволяющий выделить в тексте лексемы, иные символы считать недопустимыми (выводить ошибку).
Встроить сканер в ранее разработанный интерфейс текстового редактора. Учесть, что текст для разбора может состоять из множества строк.
Входные данные: строка (текст программного кода).

Выходные данные: последовательность условных кодов, описывающих структуру разбираемого текста с указанием места положения и типа.
### Диаграмма состояний сканера
<img src="README_images/diagram_sost.png" >
## Лабораторная работа №3: Разработка синтаксического анализатора (парсера)
Тема: разработка синтаксического анализатора (парсера).

Цель работы: изучить назначение синтаксического анализатора, спроектировать алгоритм и выполнить программную реализацию парсера.

|№ |Тема|Пример верной строки |
|--|--|--|
|27| Объявление вещественной константы с инициализацией на языке C/C++| const double PI = 3.14159265359; |

В соответствии с вариантом задания на курсовую работу необходимо:

- Разработать автоматную грамматику.
- Спроектировать граф конечного автомата (перейти от автоматной грамматики к конечному автомату).
- Выполнить программную реализацию алгоритма работы конечного автомата.
- Встроить разработанную программу в интерфейс текстового редактора, созданного на первой лабораторной работе.

### Грамматика

G[<CONST> = <вещественная константа>]:

VT = { ‘const ’, ‘double ’, ‘a’…’z’, ‘A’…’Z’, ‘0’…’9’, ‘:’, ‘;’, ‘+’, ‘-‘, ‘=’, ‘_’ }

VN = { <CONST>, DOUBLE, NAME, NAMEREM, NUMBER, INT, INTREM, DECIMAL, DECIMALREM, END, letter, digit }

P =
- <CONST> → ‘const ’ DOUBLE 
- DOUBLE → 'double ' NAME
- NAME → letter NAMEREM 
- NAMEREM →  letter NAMEREM | '=' NUMBER
- NUMBER → ['+'|'-'] INT
- INT → digit INTREM
- INTREM → digit INTREM | '.' DECIMAL | ';'
- DECIMAL → digit DECIMALREM 
- DECIMALREM → digit DECIMALREM | ';' 
- letter → ‘a’ | ‘b’ | … | ‘z’ | ‘A’ | ‘B’ | … | ‘Z’
- digit → ‘0’ | ‘1’ | … | ‘9’

### Классификация грамматики
Согласно классификации Хомского, грамматика G[Z] является полностью автоматной.

### Граф конечного автомата
<img src="/README_images/graf.png">

### Пример
Текст без ошибок
<img src="/README_images/zero_errors.png">

Текст с ошибками
<img src="/README_images/many_errors.png">
## Лабораторная работа №4: Нейтрализация ошибок (метод Айронса)

Тема: нейтрализация ошибок (метод Айронса).

Цель работы: реализовать алгоритм нейтрализации синтаксических ошибок и дополнить им программную реализацию парсера.

### Метод Айронса
Разрабатываемый синтаксический анализатор построен на базе автоматной грамматики. При нахождении лексемы, которая не соответствует грамматике предлагается свести алгоритм нейтрализации к последовательному удалению следующего символа во входной цепочке до тех пор, пока следующий символ не окажется одним из допустимых в данный момент разбора.

Этот алгоритм был мной уже реализован в Лабораторной работе №3. В таблице ошибок выводятся их местоположение и текст ошибки, содержащий информацию об отброшенном фрагменте.
### Пример
Текст с ошибками
<img src="/README_images/many_errors.png">
Исправление
<img src="/README_images/afrer_nitralization.png">
## Лабораторная работа №5: Включение семантики в анализатор. Создание внутренней формы представления программы

## Лабораторная работа №6: Реализация алгоритма поиска подстрок с помощью регулярных выражений

## Лабораторная работа №7: Реализация метода рекурсивного спуска для синтаксического анализа
