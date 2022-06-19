using HashPuzzle;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Xunit.Abstractions;

namespace Tests;

public class HashPuzzleTests
{
    private readonly HashPuzzleCreator puzzleCreator;
    private readonly ITestOutputHelper output;
    public HashPuzzleTests(ITestOutputHelper output)
    {
        puzzleCreator = new();
        this.output = output;
    }
    
    [Fact]
    public void InsantiateAPuzzleCreatorTest()
    {
        Assert.NotNull(puzzleCreator);
    }
    
    [Fact]
    public void CreateATargetTest()
    {
        var t = puzzleCreator.GetTarget(5);
        Assert.Equal(5, t.Count());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    public void MatchTest(int targetLength)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        var target = puzzleCreator.GetTarget(targetLength);
        string solution = puzzleCreator.FindSolution(target);
        sw.Stop();
        output.WriteLine($"MatchTest Length {targetLength} time {sw.Elapsed.TotalMilliseconds}");
        
    }
}