using LiveSplit.PaceAlert.Api;

namespace LiveSplit.PaceAlert.Logic
{
    public static class Triggers
    {
        public class Split : ITrigger
        {
            public string GetTag() => "PaceAlert.Split";
            public string GetTitle() => "On Split";
        }

        public class Start : ITrigger
        {
            public string GetTag() => "PaceAlert.Start";
            public string GetTitle() => "On Start";
        }

        public class Reset : ITrigger
        {
            public string GetTag() => "PaceAlert.Reset";
            public string GetTitle() => "On Reset";
        }
    }
}