using VraagAntwoordDemo.Classes;
using VraagAntwoordDemo.Enums;
using VraagAntwoordDemo.Util;

Medication cotrimoxazol = new Medication("cotrimoxazol");
var questionsList = new List<FlowchartPoint>();
var answersList = new List<FlowchartPoint>();

questionsList.Add(new FlowchartPoint(
    1, "Clcr Bekend?", 
    FlowchartPointType.QUESTION, 
    new Dictionary<int, FlowchartPointType> { { 2, FlowchartPointType.QUESTION } },
    new Dictionary<int, FlowchartPointType> { { 5, FlowchartPointType.QUESTION } }
));
questionsList.Add(new FlowchartPoint(
    2, "Clcr > 13 maanden?", 
    FlowchartPointType.QUESTION, 
    new Dictionary<int, FlowchartPointType> { { 2, FlowchartPointType.ANSWER } },
    new Dictionary<int, FlowchartPointType> { { 3, FlowchartPointType.QUESTION } }
));
questionsList.Add(new FlowchartPoint(
    3, "Clcr > 30ml/min", 
    FlowchartPointType.QUESTION, 
    new Dictionary<int, FlowchartPointType> { { 4, FlowchartPointType.ANSWER } },
    new Dictionary<int, FlowchartPointType> { { 4, FlowchartPointType.QUESTION } }
));
questionsList.Add(new FlowchartPoint(
    4, "Clr > 10ml/min", 
    FlowchartPointType.QUESTION, 
    new Dictionary<int, FlowchartPointType> { { 3, FlowchartPointType.ANSWER } },
    new Dictionary<int, FlowchartPointType> { { 1, FlowchartPointType.ANSWER } }
));
questionsList.Add(new FlowchartPoint(
    5, "Patient > 70 jaar",
    FlowchartPointType.QUESTION, 
    new Dictionary<int, FlowchartPointType> { { 5, FlowchartPointType.ANSWER } },
    new Dictionary<int, FlowchartPointType> { { 6, FlowchartPointType.ANSWER } }
));
DatabaseUtil.questions = questionsList;


answersList.Add(new FlowchartPoint(
    2, "Bepaal of controle nodig is",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    1, "Overleg tweede lijn",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    3, "Verdubbel Dosering",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    4, "Geen Signaal",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    5, "Bepaal of controle nodig is",
    FlowchartPointType.ANSWER
));
answersList.Add(new FlowchartPoint(
    6, "Geen Signaal",
    FlowchartPointType.ANSWER
));
DatabaseUtil.answers = answersList;

// cotrimoxazol.AddPoints(questionsList);
// cotrimoxazol.AddPoints(answersList);
cotrimoxazol.SetFirstQuestion(questionsList[0]);

cotrimoxazol.ShowFirst();