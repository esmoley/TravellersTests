Задача:
Дано непустое клеточное поле размера m на n из нулей и единиц. В левом верхнем углу поля находится персонаж, которому требуется добраться в нижний правый угол. За один ход персонаж может передвигаться на одну клетку вверх, вниз, влево или вправо. Если после хода значение в текущей клетке изменилось, персонаж платит одну монетку. Требуется определить минимальное количество монеток, которое потребуется, чтобы пройти весь путь.

Формальные условия. Реализовать функцию:
private static int GetMinTravelPrice(int[][] cells)
{
    // ...
}
m = cells.Length;
n = cells[0].Length;
Гарантируется, что cells[i][j] == 0 || cells[i][j] == 1 для всех i, j таких, что 0 <= i && i < m && 0 <= j && j < n. Персонаж стоит в клетке (0, 0). Добраться требуется в клетку (m - 1, n - 1).


Пример 1:
cells = [
  [0, 0, 1],
  [0, 1, 0],
  [0, 1, 1],
]
Ответ: 1
Оптимальный маршрут: [(0, 0), (1, 0), (2, 0), (2, 1), (2, 2)]
Комментарий: Переход из (2, 0) в (2, 1) стоит одну монетку.

Пример 2:
cells = [
  [0],
]
Ответ: 0
Оптимальный маршрут: [(0, 0)]

Пример 3:
cells = [
  [0, 0, 1],
  [1, 0, 0],
  [1, 1, 0],
]
Ответ: 0
Оптимальный маршрут: [(0, 0), (0, 1), (1, 1), (1, 2), (2, 2)]


Решение: 
Задача решена двумя способами:
1. На скорость: движение вниз или вправо.
2. На эффективность: поиск лучшего решения используя все возможные вариации.
Точка входа: ConsoleTravellerTest.Program
Тесты: NUnitTestTraveller.AdvancedTravellerTests и NUnitTestTraveller.SimpleTravellerTests
