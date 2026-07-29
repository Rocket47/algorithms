namespace SoftwareDesign.sd1_17;

using System;
using System.Collections.Generic;
using System.Linq;

internal interface IExplorationStrategy
{
    Dictionary<string, object> CollectData();

    Dictionary<string, object> ProcessData(
        Dictionary<string, object> data);
}

internal class SensorExplorationStrategy : IExplorationStrategy
{
    public Dictionary<string, object> CollectData()
    {
        return new Dictionary<string, object>
        {
            ["temperature"] = 22,
            ["humidity"] = 45
        };
    }

    public Dictionary<string, object> ProcessData(
        Dictionary<string, object> data)
    {
        return new Dictionary<string, object>
        {
            ["temperature_celsius"] = data["temperature"],
            ["humidity_percentage"] = data["humidity"]
        };
    }
}

internal class WebResourceExplorationStrategy : IExplorationStrategy
{
    public Dictionary<string, object> CollectData()
    {
        return new Dictionary<string, object>
        {
            ["page_title"] = "Новости",
            ["content_length"] = 3500
        };
    }

    public Dictionary<string, object> ProcessData(
        Dictionary<string, object> data)
    {
        var pageTitle = (string)data["page_title"];

        return new Dictionary<string, object>
        {
            ["title_length"] = pageTitle.Length,
            ["content_length"] = data["content_length"]
        };
    }
}

internal class ExplorationManager
{
    private IExplorationStrategy? _strategy;

    public ExplorationManager()
    {
    }
    
    public void SetStrategy(IExplorationStrategy strategy)
    {
        _strategy = strategy;
    }

    public Dictionary<string, object> RunExploration()
    {
        if (_strategy is null)
        {
            throw new InvalidOperationException("Стратегия исследования не выбрана.");
        }

        var data = _strategy.CollectData();

        return _strategy.ProcessData(data);
    }
}

internal static class Program
{
    private static void Run()
    {
        var manager = new ExplorationManager();
        
        manager.SetStrategy(new SensorExplorationStrategy());

        var sensorResult = manager.RunExploration();

        PrintResult("Данные сенсоров", sensorResult);
        
        manager.SetStrategy(new WebResourceExplorationStrategy());

        var webResult = manager.RunExploration();

        PrintResult("Данные веб-ресурса", webResult);
    }

    private static void PrintResult(
        string title,
        Dictionary<string, object> result)
    {
        var formattedResult = string.Join(", ", result.Select(item => $"{item.Key}={item.Value}"));

        Console.WriteLine($"{title}: {formattedResult}");
    }
}