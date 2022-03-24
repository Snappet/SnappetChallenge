﻿using Snappet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Domain.Interface.Repository
{
    public interface IExerciseRepository
    {
        public IEnumerable<StudentExerciseActivityModel> GetStudentActivity(DateOnly date, int skip, int take);
        public IEnumerable<ExerciseModel> GetStudentExercises(DateOnly date, int studentId, int skip, int take);
    }
}
