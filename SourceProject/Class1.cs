using System;
using System.Collections.Generic;

namespace SourceProject
{
    public class Class1
    {
        private Dictionary<Workday, MoodWithReason> WorkdayMoods { get; } = new Dictionary<Workday, MoodWithReason>
        {
            [Workday.Monday] = new MoodWithReason(Mood.Happy, Reason.FeelingRefreshedFromTheWeekend),
            [Workday.Tuesday] = new MoodWithReason(Mood.Happy, Reason.NoStressYet),
            [Workday.Wednesday] = new MoodWithReason(Mood.Stressed, Reason.TooMuchRush),
            [Workday.Thursday] = new MoodWithReason(Mood.Stressed, Reason.OnlyMeetings),
            [Workday.Friday] = new MoodWithReason(Mood.Happy, Reason.AlmostWeekend)
        };

        public bool TrueOnEvenNumbers(int number)
        {
            return (number % 2 == 0);
        }

        public MoodWithReason GetMoodWithReasonForWorkday(Workday workday)
        {
            return WorkdayMoods[workday];
        }
    }
}
