﻿namespace SnappetChallengAPI.Model
{
    public class Assessment
    {
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public int SubmittedAnswerId { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public string Difficulty { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }

    }
}
