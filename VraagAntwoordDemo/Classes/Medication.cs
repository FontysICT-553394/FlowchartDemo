using VraagAntwoordDemo.Enums;

namespace VraagAntwoordDemo.Classes;

public class Medication
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public FlowchartPoint FirstQuestion { get; private set; }

    public Medication(int id, string name, FlowchartPoint firstQuestion)
    {
        Id = id;
        Name = name;
        FirstQuestion = firstQuestion;
    }
    
    public Medication(int id, string name)
    {
        Id = id;
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