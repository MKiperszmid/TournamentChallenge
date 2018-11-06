namespace Torneo
{
    public class Match
    {
        public string Local { get; set; }
        public string Visitor { get; set; }
        public Result Result { get; set; }

        public Match(string Local, string Visitor, Result Result)
        {
            this.Local = Local;
            this.Visitor = Visitor;
            this.Result = Result;
        }
    }

    public enum Result
    {
        LOCAL_WON,
        VISITOR_WON,
        DRAW
    }
}
