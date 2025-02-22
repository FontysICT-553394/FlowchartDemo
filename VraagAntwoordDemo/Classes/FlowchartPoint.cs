using System.Diagnostics;
using VraagAntwoordDemo.Enums;
using VraagAntwoordDemo.Util;

namespace VraagAntwoordDemo.Classes;

public class FlowchartPoint
{
    public int Id { get; private set; }
    public int MedId { get; private set; }
    public string Text { get; private set; }
    public FlowchartPointType Type { get; private set; }
    public KeyValuePair<int, FlowchartPointType> AnswerYes { get; private set; }
    public KeyValuePair<int, FlowchartPointType> AnswerNo { get; private set; }

    public FlowchartPoint(int id, int medId, string text, FlowchartPointType type, KeyValuePair<int, FlowchartPointType> answerYes, KeyValuePair<int, FlowchartPointType> answerNo)
    {
        Id = id;
        MedId = medId;
        Text = text;
        Type = type;
        AnswerYes = answerYes;
        AnswerNo = answerNo;
    }
    
    public FlowchartPoint(int id, int medId, string text, FlowchartPointType type)
    {
        Id = id;
        MedId = medId;
        Text = text;
        Type = type;
    }

    public void Show()
    {
        if(Type == FlowchartPointType.ANSWER)
        {
            Console.WriteLine(Text + " [Press Any Key To Close]");
            Console.ReadKey();
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
    
        var nextId = nextPoints.Key;
        var nextType = nextPoints.Value;
        
        FlowchartPoint? nextPoint = nextType == FlowchartPointType.QUESTION
            ? DatabaseUtil.GetQuestionFromId(MedId, nextId)
            : DatabaseUtil.GetAnswerFromId(MedId, nextId);
    
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