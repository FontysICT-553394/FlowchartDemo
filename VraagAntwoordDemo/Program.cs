using VraagAntwoordDemo.Classes;
using VraagAntwoordDemo.Enums;
using VraagAntwoordDemo.Util;

Medication cotrimoxazol03 = new Medication(1,"Cotrimoxazol");
Medication Foliumzuur15 = new Medication(2,"Foliumzuur");

var questionsList = new List<FlowchartPoint>();
var answersList = new List<FlowchartPoint>();

#region Questions-Med-03

var FirstQuestionMed03 = new FlowchartPoint(
    1, cotrimoxazol03.Id, "Clcr Bekend?",
    FlowchartPointType.QUESTION,
    new KeyValuePair<int, FlowchartPointType>(2, FlowchartPointType.QUESTION),
    new KeyValuePair<int, FlowchartPointType>(5, FlowchartPointType.QUESTION)
);
questionsList.Add(FirstQuestionMed03);

questionsList.Add(new FlowchartPoint(
    2, cotrimoxazol03.Id,"Clcr > 13 maanden?", 
    FlowchartPointType.QUESTION, 
    new KeyValuePair<int, FlowchartPointType>(2, FlowchartPointType.ANSWER),
    new KeyValuePair<int, FlowchartPointType>(3, FlowchartPointType.QUESTION)
));
questionsList.Add(new FlowchartPoint(
    3, cotrimoxazol03.Id,"Clcr > 30ml/min", 
    FlowchartPointType.QUESTION, 
    new KeyValuePair<int, FlowchartPointType>(4, FlowchartPointType.ANSWER),
    new KeyValuePair<int, FlowchartPointType>(4, FlowchartPointType.QUESTION)
));
questionsList.Add(new FlowchartPoint(
    4, cotrimoxazol03.Id,"Clr > 10ml/min", 
    FlowchartPointType.QUESTION, 
    new KeyValuePair<int, FlowchartPointType>(3, FlowchartPointType.ANSWER),
    new KeyValuePair<int, FlowchartPointType>(1, FlowchartPointType.ANSWER)
));
questionsList.Add(new FlowchartPoint(
    5, cotrimoxazol03.Id,"Patient > 70 jaar",
    FlowchartPointType.QUESTION, 
    new KeyValuePair<int, FlowchartPointType>(5, FlowchartPointType.ANSWER),
    new KeyValuePair<int, FlowchartPointType>(6, FlowchartPointType.ANSWER)
));

#endregion
#region Questions-Med-15

var FirstQuestionMed15 = new FlowchartPoint(
    1, Foliumzuur15.Id, "Indicatie Bekend?",
    FlowchartPointType.QUESTION,
    new KeyValuePair<int, FlowchartPointType>(5, FlowchartPointType.QUESTION),
    new KeyValuePair<int, FlowchartPointType>(2, FlowchartPointType.QUESTION)
);
questionsList.Add(FirstQuestionMed15);

questionsList.Add(new FlowchartPoint(
    2, Foliumzuur15.Id, "Dagelijkse Toediening?",
    FlowchartPointType.QUESTION,
    new KeyValuePair<int, FlowchartPointType>(1, FlowchartPointType.ANSWER),
    new KeyValuePair<int, FlowchartPointType>(3, FlowchartPointType.QUESTION)
));
questionsList.Add(new FlowchartPoint(
    3, Foliumzuur15.Id, "Dosering <= 40mg/week?",
    FlowchartPointType.QUESTION,
    new KeyValuePair<int, FlowchartPointType>(4, FlowchartPointType.QUESTION),
    new KeyValuePair<int, FlowchartPointType>(1, FlowchartPointType.ANSWER)
));
questionsList.Add(new FlowchartPoint(
    4, Foliumzuur15.Id, "Foliumzuur in actuele medicatie?",
    FlowchartPointType.QUESTION,
    new KeyValuePair<int, FlowchartPointType>(1, FlowchartPointType.ANSWER),
    new KeyValuePair<int, FlowchartPointType>(2, FlowchartPointType.ANSWER)
));
questionsList.Add(new FlowchartPoint(
    5, Foliumzuur15.Id, "Foliumzuur in actuele medicatie",
    FlowchartPointType.QUESTION,
    new KeyValuePair<int, FlowchartPointType>(1, FlowchartPointType.ANSWER),
    new KeyValuePair<int, FlowchartPointType>(2, FlowchartPointType.ANSWER)
));
#endregion
DatabaseUtil.questions = questionsList;

#region Answers-Med-03
answersList.Add(new FlowchartPoint(
    2, cotrimoxazol03.Id,"Bepaal of controle nodig is",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    1, cotrimoxazol03.Id,"Overleg tweede lijn",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    3, cotrimoxazol03.Id,"Verdubbel Dosering",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    4, cotrimoxazol03.Id,"Geen Signaal",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    5, cotrimoxazol03.Id,"Bepaal of controle nodig is",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    6, cotrimoxazol03.Id,"Geen Signaal",
    FlowchartPointType.ANSWER
));
#endregion
#region Answers-Med-15
answersList.Add(new FlowchartPoint(
    2, Foliumzuur15.Id,"Voeg foliumzuur toe",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    1, Foliumzuur15.Id,"Geen signaal",
    FlowchartPointType.ANSWER
));

#endregion
DatabaseUtil.answers = answersList;

cotrimoxazol03.SetFirstQuestion(FirstQuestionMed03);
Foliumzuur15.SetFirstQuestion(FirstQuestionMed15);

Console.WriteLine("Which med would you like to test?\n1. Cotrimoxazol (03) \n2. Foliumzuur (15)");
string? input = Console.ReadLine();
if(input == "1")
    cotrimoxazol03.ShowFirst();
else if(input == "2")
    Foliumzuur15.ShowFirst();