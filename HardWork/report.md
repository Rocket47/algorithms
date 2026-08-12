# Задание HardWork: снижение цикломатической сложности

## 2. Структура проекта

Структура примеров:

```text
Tasks/
  Task1Elevator/
    Before/
    After/
    Models/
  Task2NumberToWords/
    Before/
    After/
    Models/
  Task3SortThreeNumbers/
    Before/
    After/
    Models/
```

В каждой задаче:
- папка Before содержит исходную версию с высокой ЦС
- папка After - результат рефакторинга

## 3. Задача 1: управление лифтом

Файлы:

- [Tasks/Task1Elevator/Before/ElevatorControllerBefore.cs](Tasks/Task1Elevator/Before/ElevatorControllerBefore.cs)
- [Tasks/Task1Elevator/After/ElevatorControllerAfter.cs](Tasks/Task1Elevator/After/ElevatorControllerAfter.cs)
- [Tasks/Task1Elevator/After/DownDirectionHandler.cs](Tasks/Task1Elevator/After/DownDirectionHandler.cs)
- [Tasks/Task1Elevator/After/StoppedDirectionHandler.cs](Tasks/Task1Elevator/After/StoppedDirectionHandler.cs)
- [Tasks/Task1Elevator/After/UpDirectionHandler.cs](Tasks/Task1Elevator/After/UpDirectionHandler.cs)

#### Исходная версия до рефакторинга:

```csharp
public ElevatorCommandResult FloorPress(ElevatorState state, int floor)
{
    var message = "";

    if (floor < 1)
    {
        message = "Floor must be positive";
    }
    else if (floor > state.TopFloor)
    {
        message = $"We only have {state.TopFloor} floors";
    }
    else
    {
        switch (state.Direction)
        {
            case ElevatorDirection.Down:
                if (state.CurrentFloor > floor)
                {
                    state.CurrentFloor = floor;
                    state.Direction = ElevatorDirection.Stopped;
                    message = $"Going down and stopped at floor {floor}";
                }
                else if (state.CurrentFloor == floor)
                {
                    state.Direction = ElevatorDirection.Stopped;
                    message = "That is our current floor";
                }
                else
                {
                    state.Direction = ElevatorDirection.Up;
                    state.CurrentFloor = floor;
                    message = $"Changing direction and going up to floor {floor}";
                }

                break;

            case ElevatorDirection.Stopped:
                if (state.CurrentFloor < floor)
                {
                    state.Direction = ElevatorDirection.Up;
                    state.CurrentFloor = floor;
                    state.Direction = ElevatorDirection.Stopped;
                    message = $"Going up and stopped at floor {floor}";
                }
                else if (state.CurrentFloor == floor)
                {
                    message = "That is our current floor";
                }
                else
                {
                    state.Direction = ElevatorDirection.Down;
                    state.CurrentFloor = floor;
                    state.Direction = ElevatorDirection.Stopped;
                    message = $"Going down and stopped at floor {floor}";
                }

                break;

            case ElevatorDirection.Up:
                if (state.CurrentFloor < floor)
                {
                    state.CurrentFloor = floor;
                    state.Direction = ElevatorDirection.Stopped;
                    message = $"Going up and stopped at floor {floor}";
                }
                else if (state.CurrentFloor == floor)
                {
                    state.Direction = ElevatorDirection.Stopped;
                    message = "That is our current floor";
                }
                else
                {
                    state.Direction = ElevatorDirection.Down;
                    state.CurrentFloor = floor;
                    message = $"Changing direction and going down to floor {floor}";
                }

                break;
        }
    }

    return new ElevatorCommandResult(state, message);
}
```

ЦС исходной версии:

```text
Базовая - 1
if / else if - 8
case в switch - 4
Итого ЦС: 13
```

#### После рефакторинга

```csharp
public ElevatorCommandResult FloorPress(ElevatorState state, int floor)
{
    if (floor < 1)
    {
        return new ElevatorCommandResult(state, "Floor must be positive");
    }

    if (floor > state.TopFloor)
    {
        return new ElevatorCommandResult(state, $"We only have {state.TopFloor} floors");
    }

    return _handlers[state.Direction].Handle(state, floor);
}
```

ЦС результирующей версии:

```text
- Базовая - 1
- Количество if - 2

Итого: общая ЦС = 3
```

Снижение ЦС: `13 -> 3`.

Приёмы:

1) Практика полного избавления от else
2) Удаление switch/case
3) Состояния движения вынесены в отдельные классы
4) Метод избавлен от жёсткого ветвления и переведён к полиморфной обработке состояний

## 4. Задача 2: перевод числа в слова

Пример переводит число в текст.

Файлы:

- [Tasks/Task2NumberToWords/Before/NumberToWordsBefore.cs](Tasks/Task2NumberToWords/Before/NumberToWordsBefore.cs)
- [Tasks/Task2NumberToWords/After/NumberToWordsAfter.cs](Tasks/Task2NumberToWords/After/NumberToWordsAfter.cs)
- [Tasks/Task2NumberToWords/After/INumberWordRule.cs](Tasks/Task2NumberToWords/After/INumberWordRule.cs)

### Версия до рефакторинга

```csharp
public string Convert(NumberWordRequest request)
{
    var value = request.Value;
    var separator = request.Separator;

    if (value < 0)
    {
        return "minus " + Convert(new NumberWordRequest(Math.Abs(value), separator));
    }

    if (value < 20)
    {
        return GetWord(value);
    }

    if (value < 100)
    {
        var tens = value / 10 * 10;
        var units = value % 10;

        if (units == 0)
        {
            return GetWord(tens);
        }

        return GetWord(tens) + separator + GetWord(units);
    }

    if (value < 1000)
    {
        var hundreds = value / 100;
        var rest = value % 100;

        if (rest == 0)
        {
            return GetWord(hundreds) + " hundred";
        }

        return GetWord(hundreds) + " hundred" + separator + Convert(new NumberWordRequest(rest, separator));
    }

    if (value < 1000000)
    {
        var thousands = value / 1000;
        var rest = value % 1000;

        if (rest == 0)
        {
            return Convert(new NumberWordRequest(thousands, separator)) + " thousand";
        }

        return Convert(new NumberWordRequest(thousands, separator)) +
               " thousand" +
               separator +
               Convert(new NumberWordRequest(rest, separator));
    }

    return "too big";
}
```

```text
- Базовая - 1
- Использовние if - 8
- Общая ЦС = 9
```

### Версия после рефакторинга

```csharp
public string Convert(NumberWordRequest request)
{
    var rule = _rules.FirstOrDefault(candidate => candidate.CanConvert(request.Value));
    return rule?.Convert(request, this) ?? "too big";
}
```

ЦС результирующей версии:

```text
Базовая - 1
```

Снижение ЦС: `9 -> 1`.

Приёмы:

- цепочка `if` заменена на список правил;
- словарь чисел вынесен в таблицу `Words`;
- диапазоны чисел оформлены отдельными классами
- основной метод больше не знает деталей обработки тысяч, сотен и десятков.

## 5. Задача 3: сортировка трёх чисел

Пример сортирует три числа по убыванию.

Файлы:

- [Tasks/Task3SortThreeNumbers/Before/ThreeNumberSorterBefore.cs](Tasks/Task3SortThreeNumbers/Before/ThreeNumberSorterBefore.cs)
- [Tasks/Task3SortThreeNumbers/After/ThreeNumberSorterAfter.cs](Tasks/Task3SortThreeNumbers/After/ThreeNumberSorterAfter.cs)

### Версия до рефакторинга

```csharp
public IReadOnlyList<int> SortDescending(SortRequest request)
{
    var first = request.First;
    var second = request.Second;
    var third = request.Third;

    if (first == second && first == third)
    {
        return [first, second, third];
    }

    if (first >= second && first >= third)
    {
        if (second >= third)
        {
            return [first, second, third];
        }

        return [first, third, second];
    }
    else if (second >= first && second >= third)
    {
        if (first >= third)
        {
            return [second, first, third];
        }

        return [second, third, first];
    }
    else if (third >= first && third >= second)
    {
        if (first >= second)
        {
            return [third, first, second];
        }

        return [third, second, first];
    }

    return [first, second, third];
}
```

ЦС

```text
Базовая - 1
if / else if - 7
&& - 5
Общая ЦС = 13
```

### Версия после рефакторинга

```csharp
public IReadOnlyList<int> SortDescending(SortRequest request) =>
    new[] { request.First, request.Second, request.Third }
        .OrderDescending()
        .ToArray();
```

ЦС после рефакторинга:

```text
Базовая = 1
```

Снижение: `13 -> 1`.

Приёмы:

- ручной перебор условий заменён стандартной linq операцией
- удалены `else if` и вложенные `if`

### Рефлексия
Рассуждаю преимущественно с последним опытом работы в финтехе.
Данные правила усваивались интуитивно или с помощью критических замечаний на код ревью. Честно говоря, чем проще 
код на практике - тем лучше. Всегда есть соблазн в больших фичах и горящих сроках быстро сделать много вложенных условий, простых switch/case сценариев
для разных статусных моделей. Действительно, в случае бага правки становятся испытанием. Поддерживать код труднее, несмотря на то что в моменте решение казалось легким и прозрачным.
Следом за этим обычно тянутся десятки тестов на один обработчик и трудность в расширении функционала. Есть еще момент из практики, что когда надо быстро погрузиться в бизнес контекст (к примеру, на встрече)
код с высокой ЦС с большой вероятностью быстро запутает, трудно определить действующие правила "на лету". Сейчас на проекте мы
используем vertical slice архитектуру и некоторые обработчики получается упаковать буквально до 10 строк кода. Это не всегда легко сделать, но как же приятно потом работать с таким кодом.
При этом кажется что стремление к супер эффективной ЦС может значительно замедлить разработку критического функционала. Мне показалось нужным в этой теме искать некий баланс.
По ощущениям, если говорить о типовом SaaS бэкенде без полиморфизма не обойтись вобще. Множество переиспользуемых объектов (к примеру, dto) зачастую просто обязывают созадвать базовый класс и переиспользовать под конкретный эндпоинт.
И последнее, по ощущениям сам фреймворк проектируется и подталкивает к снижению ЦС. Такие инструмент как возвращение результата обработки запроса в middleware, медиатр и cqrs - все это сводится к снижению зависимостей и упрощению вызовов.

### Резюме
Узнал и повторил много полезных правил. Забираю цикломатическую сложность как инструмент для повышения надежности и простоты кода одноверенно. 
Буду анализировать код на ЦС с целью повышения вероятности рефакторинга и упрощения дальнейшей поддержки продукта.
