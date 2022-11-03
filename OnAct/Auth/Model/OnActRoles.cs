namespace OnAct.Auth.Model
{
    public static class OnActRoles
    {
        public const string Admin = nameof(Admin);
        public const string ActivityCreator = nameof(ActivityCreator);
        public const string Manager = nameof(Manager);
        public const string User = nameof(User);

        public static readonly IReadOnlyCollection<string> All = new[] { Admin, ActivityCreator, Manager, User };

    }
}
