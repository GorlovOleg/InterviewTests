/*
Author          : Full-stack Developer Oleg Gorlov
Description:	: UTest class GraduationTracker.Tests.Unit
Copyright       : 
email           : 
Date            : 04/01/2018
Release         : 1.0.0
Comment         : 
 */
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        public static GraduationTracker graduationTracker = new GraduationTracker();
        public static Tuple<bool, STANDING> tupleOutput = new Tuple<bool, STANDING>(true, STANDING.None);
        public static List<Tuple<bool, STANDING>> graduated = new List<Tuple<bool, STANDING>>();
        public static Diploma diploma = new Diploma();
        public static Course course = new Course();
        public static Requirement requirement = new Requirement();
        public static STANDING standing = new STANDING();
        public static Repository repository = new Repository();
        public static IList<Student> students;

        #region HasGraduated_Remedial
        /// <summary>
        /// Check a valid input  for method graduationTracker.HasGraduated
        /// </summary>
        /// <param name="inputValue1">boolen</param>
        /// <param name="inputValue2">enum STANDING.Remedial</param>
        /// <returns>List<Tuple<bool, STANDING>></returns>
        [TestMethod]
        public void HasGraduated_Remedial()
        {
            var inputValue1 = false;
            var inputValue2 = STANDING.Remedial;

            //--- average < 50; Mark=40
            var studentsOut = new Student
            {
                Id = 1,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            };

            tupleOutput = graduationTracker.HasGraduated(diploma, studentsOut);

            Assert.AreEqual(tupleOutput.Item1, inputValue1);
            Assert.AreEqual(tupleOutput.Item2, inputValue2);
        }
        #endregion

        #region HasGraduated_Average
        /// <summary>
        /// Check a valid input  for method graduationTracker.HasGraduated
        /// </summary>
        /// <param name="inputValue1">boolen</param>
        /// <param name="inputValue2">enum STANDING.Average</param>
        /// <returns>List<Tuple<bool, STANDING>></returns>
        [TestMethod]
        public void HasGraduated_Average()
        {
            var inputValue1 = true;
            var inputValue2 = STANDING.Average;


            //--- average > 50 and average < 80; Mark=79
            var studentsOut = new Student
            {
                Id = 2,
                Courses = new Course[]
                {
                        new Course{Id = 1, Name = "Math", Mark=79 },
                        new Course{Id = 2, Name = "Science", Mark=79 },
                        new Course{Id = 3, Name = "Literature", Mark=79 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=79 }
                    }
            };


            tupleOutput = graduationTracker.HasGraduated(diploma, studentsOut);

            Assert.AreEqual(tupleOutput.Item1, inputValue1);
            Assert.AreEqual(tupleOutput.Item2, inputValue2);

        }
        #endregion

        #region HasGraduated_SumaCumLaude
        /// <summary>
        /// Check a valid input  for method graduationTracker.HasGraduated
        /// </summary>
        /// <param name="inputValue1">boolen</param>
        /// <param name="inputValue2">enum STANDING.SumaCumLaude</param>
        /// <returns>List<Tuple<bool, STANDING>></returns>
        [TestMethod]
        public void HasGraduated_SumaCumLaude()
        {
            var inputValue1 = true;
            var inputValue2 = STANDING.SumaCumLaude;

            //--- average > 80 and average < 95; Mark=94
            var studentsOut = new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                        new Course{Id = 1, Name = "Math", Mark=94 },
                        new Course{Id = 2, Name = "Science", Mark=94 },
                        new Course{Id = 3, Name = "Literature", Mark=94 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=94 }
                }
            };

            tupleOutput = graduationTracker.HasGraduated(diploma, studentsOut);

            Assert.AreEqual(tupleOutput.Item1, inputValue1);
            Assert.AreEqual(tupleOutput.Item2, inputValue2);
        }
        #endregion

        #region HasGraduated_MagnaCumLaude
        /// <summary>
        /// Check a valid input  for method graduationTracker.HasGraduated
        /// </summary>
        /// <param name="inputValue1">boolen</param>
        /// <param name="inputValue2">enum STANDING.MagnaCumLaude</param>
        /// <returns>List<Tuple<bool, STANDING>></returns>
        [TestMethod]
        public void HasGraduated_MagnaCumLaude()
        {
            var inputValue1 = true;
            var inputValue2 = STANDING.MagnaCumLaude;

            //--- average > 95 ; Mark=95
            var studentsOut = new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                }
            };

            tupleOutput = graduationTracker.HasGraduated(diploma, studentsOut);

            Assert.AreEqual(tupleOutput.Item1, inputValue1);
            Assert.AreEqual(tupleOutput.Item2, inputValue2);

        }
        #endregion
    }
}
