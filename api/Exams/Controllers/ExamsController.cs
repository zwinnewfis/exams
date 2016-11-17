using Exams.Models;
using Exams.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Exams.Controllers
{
    [RoutePrefix("exams")]
    public class ExamsController : ApiController
    {
        IUserService userService;
        IExamService examService;

        public ExamsController(IUserService userService, IExamService examService)
        {
            this.userService = userService;
            this.examService = examService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Exam> GetExams()
        {
            return examService.GetExams();
        }

        [HttpGet]
        [Route("{id}")]
        public Exam GetExamById(int id)
        {
            return examService.GetExam(id);
        }

        [HttpPost]
        [Route("")]
        public int CheckExam(UserExam userExam)
        {
            int result = examService.CheckExam(userExam.Exam);
            userService.SaveUserResult(userExam, result);
            return result;
        }

        [HttpGet]
        [Route("results")]
        public HttpResponseMessage GetResults()
        {
            var bytes = userService.GetResults();
            var result = new HttpResponseMessage(HttpStatusCode.OK)
                           {
                               Content = new ByteArrayContent(bytes)
                           };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                                        {
                                                            FileName = "results.zip"
                                                        };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return result;
        }
    }
}
