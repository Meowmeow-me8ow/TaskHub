namespace Api.Controllers.Tasks.Request
{
    public class CreateTaskRequest
    {
        public string? Title { get; set; }
        public Guid UserId { get; set; }
    }
}
