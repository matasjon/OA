using Npgsql.PostgresTypes;

namespace OnAct.Data.Dtos.Groups
{
    public record GroupDto(int Id, string Name, string Description, string[] StartTimes, string[] EndTimes, int[] Days, bool IsFull);
}
