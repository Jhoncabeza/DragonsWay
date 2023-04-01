using DragonsWay.Logic;

Console.WriteLine("*** Dragon's Way ***\n");
var game = new Game(10, "→→→↓↓↓→→→↓↓↓→→→→→→→→→↓→→→→→→");
//var game = new Game(10, "→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→");
Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(game);
Console.BackgroundColor = ConsoleColor.Black;



if (game.Win)
{
    Console.WriteLine("The dragon is free!");
}
else
{
    Console.WriteLine("The dragon die... sorry");
}
