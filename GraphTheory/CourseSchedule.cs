using System.Collections;
using System.Collections.Generic;

namespace GraphTheory
{
    public static class CourseSchedule
    {
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var nextCourses = new List<short>[numCourses];
            var prevCourses = new List<short>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                nextCourses[i] = new List<short>();
                prevCourses[i] = new List<short>();
            }
            foreach (var prerequisite in prerequisites)
            {
                var course = (short)prerequisite[0];
                var reqCourse = (short)prerequisite[1];

                nextCourses[reqCourse].Add(course);
                prevCourses[course].Add(reqCourse);
            }

            short finished = 0;
            while (finished < numCourses)
            {
                List<short> queue = new List<short>();
                for (short i = 0; i < numCourses; i++)
                {
                    if (nextCourses[i] == null || prevCourses[i].Count > 0)
                        continue;
                    finished++;
                    queue.Add(i);
                }

                if (queue.Count == 0)
                    return false;

                foreach (short course in queue)
                {
                    if (nextCourses[course] == null)
                        continue;

                    foreach (var nextCourse in nextCourses[course])
                    {
                        if (!prevCourses[nextCourse].Remove(course))
                            return false;
                    }

                    nextCourses[course] = null;
                }
            }

            return finished == numCourses;
        }
    }
}