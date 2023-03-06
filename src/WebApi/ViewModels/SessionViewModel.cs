using Core.Entities.CourseAggregate;
using Core.Enums;

namespace WebApi.ViewModels
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public string TitleFa { get; set; }
        public string TitleEn { get; set; }
        public int CourseId { get; set; }
        //public Section Section { get; set; }
        public SessionType SessionType { get; set; } = SessionType.Video;
        /// <summary>
        /// Duriation in second
        /// </summary>
        public int Duration { get; set; }
        public string Thumbnail { get; set; }
        public string ResourceUri { get; set; }
        public int OrderNumber { get; set; }
    }
}
