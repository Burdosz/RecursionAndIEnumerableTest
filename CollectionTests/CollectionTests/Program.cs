// See https://aka.ms/new-console-template for more information
using CollectionTests;


var functionality = new TreeMapper();
var oldTree = new OldTree
{
    Id = "theOnlyChild",
    Parents = new ()
    {
        new ()
        {
            Id = "Mama",
            Parents = null
        },
        new ()
        {
            Id = "Papa",
            Parents = new()
            {
                new ()
                {
                    Id = "Mama",
                    Parents = new ()
                    {
                        new ()
                        {
                            Id = "Papa",
                            Parents = new()
                            {
                                new ()
                                {
                                    Id = "GrandPapa",
                                    Parents = null
                                }
                            }
                        }
                    }
                }
            }
        }
    }
};

Console.WriteLine("Calling the method with HashSet as internal accumulator");
var newTree = functionality.MapTreeObject(oldTree);
Console.WriteLine();

Console.WriteLine("Calling count on parents:");
Console.WriteLine("Count is:" + newTree.Parents.Count());
Console.WriteLine();

Console.WriteLine("Calling count on parents again:");
Console.WriteLine("Second Count is:" + newTree.Parents.Count());
Console.WriteLine();

Console.WriteLine("Calling first on parents:");
Console.WriteLine("The parent is:" + newTree.Parents.First()?.Id ?? "null");
Console.WriteLine();

Console.WriteLine("Calling last on parents:");
Console.WriteLine("The parent is:" + newTree.Parents.Last()?.Id ?? "null");
Console.WriteLine();
Console.WriteLine();


Console.WriteLine("Experiment with second copy of tree");
var secondNewTree = functionality.MapTreeObject(oldTree);
Console.WriteLine("Calling to list on parents:");
var papaParents = secondNewTree.Parents.ToList();
Console.WriteLine();

Console.WriteLine("Taking last parent");
var y = papaParents.Last();
Console.WriteLine();

Console.WriteLine($"Taken parent {y.Id}");
Console.WriteLine("Calling to list on ys parents:");
y.Parents.ToList();


Console.WriteLine("End");


