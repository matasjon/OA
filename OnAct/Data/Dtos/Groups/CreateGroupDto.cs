namespace OnAct.Data.Dtos.Groups
{
    public record CreateGroupDto (string Name, string Description, string[] StartTimes, string[] EndTimes, int[] Days, bool IsFull);

}
