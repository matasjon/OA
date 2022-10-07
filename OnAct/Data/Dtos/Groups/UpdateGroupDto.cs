namespace OnAct.Data.Dtos.Groups
{
    public record UpdateGroupDto(string Name, string Description, string[] StartTimes, string[] EndTimes, int[] Days, bool IsFull);
}
