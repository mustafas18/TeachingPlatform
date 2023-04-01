using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commands.Account;
using WebApi.Commands.Courses;
using WebApi.ViewModels.Acconut;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StudentController : BaseApiController
    {
        private readonly IMediator _mediatR;

        public StudentController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetByCourseId(int courseId)
        {
            try
            {
                var course = await _mediatR.Send(new GetCourseWithStudent(courseId));
                //course?.Sessions.ForEach(p => { p.Course = null; });
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignUpInCourse([FromBody] CourseStudentViewModel signUpCourse)
        {
            try
            {
                var result = await _mediatR.Send(new SignUpCourse(signUpCourse.UserName, signUpCourse.CourseId));
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCoursesByStudentName(string studentUserName)
        {
            try
            {
                var result = await _mediatR.Send(new GetStudentCourses(studentUserName));
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Check if the user is a student of the course.
        /// </summary>
        /// <param name="studentCourse"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> IsStudent([FromBody] CourseStudentViewModel studentCourse)
        {
            try
            {
                var result = await _mediatR.Send(new CheckCourseStudent(studentCourse));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
