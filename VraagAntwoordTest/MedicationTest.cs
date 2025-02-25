using VraagAntwoordDemo.Classes;
using VraagAntwoordDemo.Enums;
using VraagAntwoordDemo.Util;

namespace VraagAntwoordTest;

[TestClass]
public class MedicationTest
{
    [TestMethod]
    public void CreateMedicationTest()
    {
        const int medId = 1;
        const string medName = "TestMed";
        
        var med = new Medication(medId, medName);
        
        Assert.AreEqual(medId, med.Id);
        Assert.AreEqual(medName, med.Name);
    }

    [TestMethod]
    public void FirstMedicationQuestionTest()
    {
        const int medId = 1;
        const int questionId = 1;
        const string questionText = "Do u like cheez?";
        const int questionId2 = 3;
        const string questionText2 = "Do u like sauzage?";
        const string medName = "TestMed";

        var question = new FlowchartPoint(questionId, medId, questionText, FlowchartPointType.ANSWER);
        var question2 = new FlowchartPoint(questionId2, medId, questionText2, FlowchartPointType.ANSWER);
        var med = new Medication(medId, medName);
        med.SetFirstQuestion(question);

        Assert.AreEqual(question, med.FirstQuestion);
        
        med.SetFirstQuestion(question2);
        
        Assert.AreEqual(question2, med.FirstQuestion);
    }

    [TestMethod]
    public void GetQuestionFromDatabaseTest()
    {
        const int questionId = 1;
        const string questionText = "Do u like cheez?";
        const int questionId2 = 3;
        const string questionText2 = "Do u like sauzage?";
        const int questionId3 = 1;
        const string questionText3 = "Do u like pissa?";
        const int medId = 1;
        const string medName = "TestMed";
        const int medId2 = 3;
        const string medName2 = "MedTest";

        var question = new FlowchartPoint(questionId, medId, questionText, FlowchartPointType.ANSWER);
        var question2 = new FlowchartPoint(questionId2, medId, questionText2, FlowchartPointType.ANSWER);
        var question3 = new FlowchartPoint(questionId3, medId2, questionText3, FlowchartPointType.ANSWER);
        var med = new Medication(medId, medName);
        var med2 = new Medication(medId2, medName2);
        DatabaseUtil.questions.Add(question);
        DatabaseUtil.questions.Add(question2);
        DatabaseUtil.questions.Add(question3);
        
        var databaseQuestionId2 = DatabaseUtil.GetQuestionFromId(medId, questionId2);
        var databaseQuestionShouldNotExist = DatabaseUtil.GetQuestionFromId(medId, 4);
        var databaseQuestionForWrongMed = DatabaseUtil.GetQuestionFromId(medId, questionId3);
        var databaseQuestionMed2Id1 = DatabaseUtil.GetQuestionFromId(medId2, questionId3);
        
        //Test for med1
        Assert.AreEqual(question2, databaseQuestionId2);
        //Different medId
        Assert.AreEqual(question3, databaseQuestionMed2Id1);
        //doesn't exist
        Assert.AreEqual(null, databaseQuestionShouldNotExist);
        //Wrong medId, but Id exists for a different med
        Assert.AreNotEqual(question3, databaseQuestionForWrongMed);
    }
    
}