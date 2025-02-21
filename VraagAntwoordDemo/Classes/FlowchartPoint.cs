using VraagAntwoordDemo.Enums;
using VraagAntwoordDemo.Util;

namespace VraagAntwoordDemo.Classes;

public class FlowchartPoint
{
    public int Id { get; set; }
    public string Text { get; private set; }
    public FlowchartPointType Type { get; private set; }
    public Dictionary<int, FlowchartPointType> AnswerYes { get; private set; }
    public Dictionary<int, FlowchartPointType> AnswerNo { get; private set; }

    public FlowchartPoint(int id, string text, FlowchartPointType type, Dictionary<int, FlowchartPointType> answerYes, Dictionary<int, FlowchartPointType> answerNo)
    {
        Id = id;
        Text = text;
        Type = type;
        AnswerYes = answerYes;
        AnswerNo = answerNo;
    }
    
    public FlowchartPoint(int id, string text, FlowchartPointType type)
    {
        Id = id;
        Text = text;
        Type = type;
    }

    public void Show()
    {
        if(Type == FlowchartPointType.ANSWER)
        {
            Console.WriteLine(Text + " [Press Enter To Close]");
            string? input = Console.ReadLine();
        }
        else
        {
            Console.WriteLine(Text + " [Y/n]");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                input = "n";
        
            HandleAnswer(input);
        }
    }

   public void HandleAnswer(bool answer)
    {
        var nextPoints = answer ? AnswerYes : AnswerNo;
        if (nextPoints == null || !nextPoints.Any())
            throw new Exception("No next point defined");
    
        var nextId = nextPoints.First().Key;
        var nextType = nextPoints.First().Value;
        
        Console.WriteLine($"Debug: Moving to {nextType} with ID {nextId}");
    
        FlowchartPoint? nextPoint = nextType == FlowchartPointType.QUESTION
            ? DatabaseUtil.GetQuestionFromId(nextId)
            : DatabaseUtil.GetAnswerFromId(nextId);
    
        if (nextPoint == null)
            throw new Exception($"Invalid {nextType.ToString().ToLower()} id: {nextId}");
    
        nextPoint.Show();
    }
    
    public void HandleAnswer(string answer)
    {
        if(answer.ToLower() == "y")
            HandleAnswer(true);
        else if(answer.ToLower() == "n")
            HandleAnswer(false);
        else
            Show();
    }
    
}