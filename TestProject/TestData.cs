using System.Collections.Generic;
using NUnit.Framework;
using SourceProject;

namespace TestProject
{
    public partial class Tests
    {
        private static IEnumerable<TestCaseData> MoodWithReasons()
        {
            yield return new TestCaseData(Workday.Tuesday, new MoodWithReason(Mood.Happy, Reason.NoStressYet));
            yield return new TestCaseData(Workday.Thursday, new MoodWithReason(Mood.Stressed, Reason.OnlyMeetings));
        }

        private static IEnumerable<TestCaseData> SeparatedMoodWithReasons()
        {
            yield return new TestCaseData(Workday.Thursday, Mood.Stressed, Reason.OnlyMeetings);
            yield return new TestCaseData(Workday.Friday, Mood.Happy, Reason.AlmostWeekend);
        }

        private static IEnumerable<int> FirstValueSource()
        {
            yield return 34;
            yield return 29;
            yield return 89;
            yield return 100;
        }

        private static IEnumerable<int> SecondValueSource()
        {
            yield return 44;
            yield return 92;
            yield return 100;
        }
    }
}