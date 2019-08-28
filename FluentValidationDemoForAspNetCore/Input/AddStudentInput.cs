using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationDemoForAspNetCore.Input
{
    /// <summary>
    /// 添加学生入参
    /// </summary>
    public class AddStudentInput : AddPersonInput
    {
        /// <summary>
        /// 学校
        /// </summary>
        public string School{ get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public Class Class { get; set; }
        /// <summary>
        /// 课程
        /// </summary>
        public List<Course> Courses { get; set; } 
    }
}
