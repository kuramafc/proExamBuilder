using NPOI.XWPF.UserModel;
using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Documents;
using System;
using System.IO;

namespace Pro.Exam.Builder.Domain
{
    public class DocumentDocX : IDocumentDocX
    {
        private readonly string directory = "/Documents/";


        public DocumentDocX()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public void CreateDocument(QuestionsDto question)
        {
            var code = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            var newFile = $"{code}.core.docx";
            
                XWPFDocument doc = new XWPFDocument();

                for (var i = 0; i < question.Questions.Count; i++)
                {
                    var paragraph = doc.CreateParagraph();
                    paragraph.Alignment = ParagraphAlignment.BOTH;
                    XWPFRun run = paragraph.CreateRun();
                    run.FontFamily = "Arial";
                    run.FontSize = 12;
                    run.SetText(i + 1 + " - " + question.Questions[i].QuestionName);

                    if (!string.IsNullOrEmpty(question.Questions[i].Image.Trim()) && File.Exists(@"C:/Users/ctiadmin/Downloads/aa.PNG"))
                    {

                    var widthEmus = (int)(400.0 * 9525);
                    var heightEmus = (int)(300.0 * 9525);

                    using (FileStream picData = new FileStream("C:/Users/ctiadmin/Downloads/aa.PNG", FileMode.Open, FileAccess.Read))
                    {
                        var image = doc.CreateParagraph();
                        XWPFRun imageRun = image.CreateRun();
                        imageRun.AddPicture(picData, (int)PictureType.PNG, "aa.PNG", widthEmus, heightEmus);
                    }
                }

                if (question.Questions[i].HasOption && question.Questions[i].Options != null)
                    {
                        for (var j = 0; j < question.Questions[i].Options.Count; j++)
                        {
                            var list = doc.CreateParagraph();
                            paragraph.Alignment = ParagraphAlignment.BOTH;

                            XWPFRun runList = list.CreateRun();
                            runList.FontFamily = "Arial";
                            runList.FontSize = 11;
                            runList.AddTab();
                            runList.SetText(alpha[j] + ") " + question.Questions[i].Options[j]);
                        }
                    }

                    var rigthQuestion = doc.CreateParagraph();
                    paragraph.Alignment = ParagraphAlignment.BOTH;

                    XWPFRun rigthQuestionRun = rigthQuestion.CreateRun();
                    rigthQuestionRun.FontFamily = "Arial";
                    rigthQuestionRun.FontSize = 11;
                    rigthQuestionRun.SetColor("#FF0000");
                    rigthQuestionRun.IsBold = true;
                    rigthQuestionRun.AddTab();
                    rigthQuestionRun.SetText("Resposta: " + question.Questions[i].RightQuestion);
                }

            using (var fs = new FileStream(directory + newFile, FileMode.Create, FileAccess.Write))
            {
                doc.Write(fs);
            }
        }
    }
}
