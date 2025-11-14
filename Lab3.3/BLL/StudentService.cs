using System;
using System.Collections.Generic;
using System.Linq;
using Lab3._3.DAL;


namespace Lab3._3.BLL;
    public class BusinessLogicException : Exception
{
    public BusinessLogicException(string message) : base(message) { }
}

public class StudentService
{
    public IEnumerable<StudentEntity> GetStudentsInCourse(IEnumerable<StudentEntity> all, int course)
    {
        if (all == null) throw new BusinessLogicException("Список студентів пустий.");
        return all.Where(s => s.Course == course);
    }

    public IEnumerable<StudentEntity> FemaleFifthCourseInKyiv(IEnumerable<StudentEntity> all)
    {
        if (all == null) throw new BusinessLogicException("Список студентів пустий.");
        return all.Where(s => string.Equals(s.Sex, "Ж", StringComparison.OrdinalIgnoreCase)
            && s.Course == 5
            && s.Residence != null
            && s.Residence.IndexOf("Київ", StringComparison.OrdinalIgnoreCase) >= 0);
    }
}