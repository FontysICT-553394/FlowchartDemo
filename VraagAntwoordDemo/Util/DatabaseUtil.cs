using VraagAntwoordDemo.Classes;

namespace VraagAntwoordDemo.Util;

public class DatabaseUtil
{
    //hardcoded database for demo
    public static List<FlowchartPoint> questions = new();
    public static List<FlowchartPoint> answers = new();

    public static FlowchartPoint? GetQuestionFromId(int id)
    {
        return questions.FirstOrDefault(q => q.Id == id);
    }
    
    public static FlowchartPoint? GetAnswerFromId(int id)
    {
        return answers.FirstOrDefault(a => a.Id == id);
    }
}