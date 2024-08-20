using Samples;

int num = 10_000_000;
Console.WriteLine(num);

#region with
A a = new A
{
    Name = "A",
    X = 1,
    Y = 2,
};

Console.WriteLine($"Name : {a.Name} \n X : {a.X} \n Y : {a.Y}");

var b = a with
{
    Name = "B",
};

Console.WriteLine($"Name : {b.Name} \n X : {b.X} \n Y : {b.Y}");

#endregion

#region Deep Copy (with)

var original = new TaggedNumber(1, new List<string> { "A", "B" });

var copy = original with { Number = 2 };
Console.WriteLine($"Tags of {nameof(copy)}: number {copy.Number} - {copy.PrintTags()}");


original.Tags.Add("C");

Console.WriteLine($"Tags of {nameof(copy)}: number {copy.Number} - {copy.PrintTags()}");
Console.WriteLine($"Tags of {nameof(original)}: number {original.Number} - {original.PrintTags()}");

Console.WriteLine($"Tags of {nameof(original)}: {original.GetHashCode()}");
Console.WriteLine($"Tags of {nameof(copy)}: {copy.GetHashCode()}");

#endregion

#region switch
var r1 = num switch
{
    int t when t < 100 => "1",
    int t when t < 1_000 => "2",
    int t when t < 10_000 => "3",
    int t when t < 100_000 => "4",
    int t when t < 100_000 => "5",
    int t when t < 1_000_000 => "6",
    int t when t < 10_000_000 => "7",
    int t when t < 100_000_000 => "8",
};

Console.WriteLine($"r1 :  {r1}");

Console.WriteLine(GetResult(1000));

var p1 = Transform(new Point(10, 30));

#endregion


Predicate<string> predicate = x => x.Length > 5;
Console.WriteLine(predicate("Hello"));


var aaaa = Enumerable.Range(1, 5).Select(x => new ToDo() { Number = x });

var tttttt = aaaa.FirstOrDefault(x=>x.Number == 9) is { } todo ? todo : new ToDo { Number = -1};
Console.WriteLine(tttttt.Number);

Console.ReadKey();

#region functions
string GetResult(int num) => num switch
{
    1000 => "Hello",
    10000 => "Goodbye",
};


Point Transform(Point point) => point switch
{
    { X: 0, Y: 0 } => new Point(0, 0),
    { X: var x, Y: var y } when x < y => new Point(x + y, y),
    { X: var x, Y: var y } when x > y => new Point(x - y, y),
    { X: var x, Y: var y } => new Point(2 * x, 2 * y),
};

public readonly struct Point
{
    public Point(int x, int y) => (X, Y) = (x, y);
    public int X { get; }
    public int Y { get; }
}

#endregion
