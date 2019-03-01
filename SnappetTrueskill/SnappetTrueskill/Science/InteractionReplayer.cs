﻿using Moserware.Skills;
using SnappetTrueskill.Data;
using SnappetTrueskill.Domain;
using System;

namespace SnappetTrueskill.Science
{
    /// <summary>
    /// Class to support replaying a set of exercise interactions to recalculate all TrueSkill ratings for users and exercises.
    /// </summary>
    public class InteractionReplayer
    {
        private readonly IUserRepository _userRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IExerciseInteractionRepository _exerciseInteractionRepository;

        private readonly GameInfo _gameInfo;

        public InteractionReplayer(IUserRepository userRepository, IExerciseRepository exerciseRepository, IExerciseInteractionRepository exerciseInteractionRepository, GameInfo gameInfo)
        {
            _userRepository = userRepository;
            _exerciseRepository = exerciseRepository;
            _exerciseInteractionRepository = exerciseInteractionRepository;

            _gameInfo = gameInfo;
        }

        /// <summary>
        /// Replays the entire history until `endDate`
        /// </summary>
        /// <param name="endDate"></param>
        public void Replay(DateTime endDate)
        {
            foreach (var interaction in _exerciseInteractionRepository.GetAll())
            {
                // Do not include this record if date is after `endDate`
                if (interaction.SubmitDateTime > endDate)
                    continue;

                // Insert user if it doesn't exist in database
                if (!_userRepository.Contains(interaction.UserId))
                    _userRepository.Insert(
                        new User {
                            Id = interaction.UserId,
                            Rating = _gameInfo.DefaultRating
                        });

                // Insert exercise if it doesn't exist in database
                if (!_exerciseRepository.Contains(interaction.ExerciseId))
                {
                    double difficulty;

                    // Initialize the exercise rating with the given difficulty in the data set as a warm start
                    if (interaction.Difficulty.HasValue && interaction.Difficulty.Value > 0)
                        difficulty = NormalizeDifficulty(interaction.Difficulty.Value);
                    else
                        difficulty = _gameInfo.DefaultRating.Mean;

                    _exerciseRepository.Insert(
                        new Exercise
                        {
                            Id = interaction.ExerciseId,
                            Rating = new Rating(difficulty, _gameInfo.DefaultRating.StandardDeviation),
                            OriginalDifficulty = interaction.Difficulty
                        });
                }

                UpdateRating(interaction);
            }
        }

        private void UpdateRating(ExerciseInteraction interaction)
        {
            var currentUserRating = _userRepository.Get(interaction.UserId).Rating;
            var currentExerciseRating = _exerciseRepository.Get(interaction.ExerciseId).Rating;

            var user = new Player(interaction.UserId);
            var exercise = new Player(interaction.ExerciseId);

            var team1 = new Team(user, currentUserRating);
            var team2 = new Team(exercise, currentExerciseRating);

            var teams = Teams.Concat(team1, team2);
            var teamRanks = new int[2] { 2, 1 };

            // If correct, swap team ranks so that the user wins over the exercise
            if (interaction.Correct > 0)
                teamRanks = new int[2] { 1, 2 };

            var newRatings = TrueSkillCalculator.CalculateNewRatings(_gameInfo, teams, teamRanks);
            var newUserRating = newRatings[user];
            var newExerciseRating = newRatings[exercise];

            // Update ratings
            _userRepository.UpdateRating(interaction.UserId, newUserRating);
            _exerciseRepository.UpdateRating(interaction.ExerciseId, newExerciseRating);
        }

        /// <summary>
        /// Normalizes the difficulty of an exercise to default mean and standard deviation.
        /// </summary>
        /// <param name="difficulty">The difficulty to normalize.</param>
        /// <returns>The normalized difficulty rating.</returns>
        private double NormalizeDifficulty(double difficulty)
        {
            return (difficulty - 259) / 105 * _gameInfo.DefaultRating.StandardDeviation + _gameInfo.DefaultRating.Mean;
        }
    }
}
