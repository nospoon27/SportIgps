namespace Application.Features.Workouts.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutsResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int SportId { get; set; }
        public int WorkoutGroupId { get; set; }
        public int? TrainerId { get; set; }
    }
}