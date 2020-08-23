namespace SourceProject
{
    public struct MoodWithReason
    {
        public Mood Mood { get; }
        public Reason Reason { get; }

        public MoodWithReason(Mood mood, Reason reason) => (Mood, Reason) = (mood, reason);
    }
}