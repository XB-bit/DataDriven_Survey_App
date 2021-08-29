namespace AIT_Research.Model
{
    public class Question
    {
        //getters and setters
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsAdditionalQuestion { get; set; }
        public int AnswerKindID { private get; set; }

        //get type answer
        public string GetAnswerKind()
        {
            switch (AnswerKindID)
            {
                case 1:
                    return "text";
                case 2:
                    return "checkbox";
                case 3:
                    return "radioButton";
                case 4:
                    return "dropDown";
                default:
                    return "";
            }
        }
    }
}