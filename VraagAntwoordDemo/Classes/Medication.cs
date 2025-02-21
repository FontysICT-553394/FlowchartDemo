using VraagAntwoordDemo.Enums;

namespace VraagAntwoordDemo.Classes;

public class Medication
{
    public string Name { get; private set; }
    public FlowchartPoint FirstQuestion { get; private set; }

    public Medication(string name, FlowchartPoint firstQuestion)
    {
        Name = name;
        FirstQuestion = firstQuestion;
    }
    
    public Medication(string name)
    {
        Name = name;
    }
    
    public void SetFirstQuestion(FlowchartPoint firstQuestion)
    {
        FirstQuestion = firstQuestion;
    }
    
    public void ShowFirst()
    {
        FirstQuestion.Show();
    }
}