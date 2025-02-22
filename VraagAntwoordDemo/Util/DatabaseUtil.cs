using VraagAntwoordDemo.Classes;

namespace VraagAntwoordDemo.Util;

public class DatabaseUtil
{
    //hardcoded database for demo
    public static List<FlowchartPoint> questions = new();
    public static List<FlowchartPoint> answers = new();

    public static FlowchartPoint? GetQuestionFromId(int medId, int flowPointId)
    {
        foreach (var q in questions)
        {
            if(q.MedId == medId && q.Id == flowPointId)
                return q;
        }

        return null;
    }

    public static FlowchartPoint? GetAnswerFromId(int medId, int flowPointId)
    {
        foreach (var a in answers)
        {
            if(a.MedId == medId && a.Id == flowPointId)
                return a;
        }

        return null;
    }
}