using NUnit.Framework;
using SourceProject;
using FluentAssertions;

namespace TestProject
{
    [TestFixture]
    public partial class Tests
    {
        [Test]
        public void Test_ReturnsTrue_OnEvenNumbers()
        {
            var class1 = new Class1();
            Assert.IsTrue(class1.TrueOnEvenNumbers(2));
            Assert.IsTrue(class1.TrueOnEvenNumbers(4));
            Assert.IsFalse(class1.TrueOnEvenNumbers(5));
        }

        [TestCase(2, ExpectedResult=true)]
        [TestCase(4, ExpectedResult=true)]
        [TestCase(5, ExpectedResult=false)]
        public bool Test_ReturnsTrue_OnEvenNumbers_UsingTestCaseAttribute(int number)
        {
            var class1 = new Class1();
            return class1.TrueOnEvenNumbers(number);
        }

        [Test]
        public void Test_ReturnsTrue_OnEvenNumberRange([Range(40, 46, 2)] int number)
        {
            var class1 = new Class1();
            Assert.IsTrue(class1.TrueOnEvenNumbers(number));
        }

        [Test]
        public void Test_ReturnsFalse_OnOddNumberRange([Range(71, 77, 2)] int number)
        {
            var class1 = new Class1();
            class1.TrueOnEvenNumbers(number).Should().BeFalse();
        }

        [TestCase(Workday.Monday, ExpectedResult = Mood.Happy)]
        [TestCase(Workday.Wednesday, ExpectedResult = Mood.Stressed)]
        public Mood Test_ReturnExpectedMood_OnWorkday(Workday workday)
        {
            var class1 = new Class1();
            return class1.GetMoodWithReasonForWorkday(workday).Mood;
        }

        /* [TestCase(Workday.Monday, ExpectedResult = new MoodWithReason(Mood.Happy, Reason.AlmostWeekend))]
        public MoodWithReason Test_ReturnExpectedMoodWithReason_OnWorkday(Workday workday)
        {
            var class1 = new Class1();
            return class1.GetMoodWithReasonForWorkday(workday);
        } */

        [TestCaseSource(nameof(MoodWithReasons))]
        public void Test_ReturnExpectedMoodWithReason_OnWorkday(Workday workday, MoodWithReason moodWithReason)
        {
            var class1 = new Class1();
            class1.GetMoodWithReasonForWorkday(workday).Mood.Should().Be(moodWithReason.Mood);
            class1.GetMoodWithReasonForWorkday(workday).Reason.Should().Be(moodWithReason.Reason);
        }

        [TestCaseSource(nameof(SeparatedMoodWithReasons))]
        public void Test_ReturnExpectedSeparatedMoodWithReason_OnWorkday(Workday workday, Mood mood, Reason reason)
        {
            var class1 = new Class1();
            class1.GetMoodWithReasonForWorkday(workday).Mood.Should().Be(mood);
            class1.GetMoodWithReasonForWorkday(workday).Reason.Should().Be(reason);
        }

        [Test]
        public void Test_AutomaticCombinationOfEnums([Values] Mood mood, [Values] Reason reason)
        {
            
        }
        
        [Test]
        public void Test_RangeOfNumbers_MultiplyToLessThan10000([Values(1, 29, 36, 55)] int firstValue,
                                                                [Values(7, 35)] int secondValue)
        {
            (firstValue * secondValue).Should().BeLessThan(10000);
        }

        [Test]
        public void Test_RangeOfNumbers_MultiplyToLessThanOrEqualTo10000([ValueSource(nameof(FirstValueSource))] int firstValue,
                                                                         [ValueSource(nameof(SecondValueSource))] int secondValue)
        {
            (firstValue * secondValue).Should().BeLessOrEqualTo(10000);
        }

    }
}