namespace Api.Data.Shared;

public enum ArticleStatus
{
 InProgress,
 Review,
 Published,
 Hidden
}

public enum EmployeeStatus
{
 Active,
 Blocked
}

public enum EmployeePositionPermissionLevel
{
 Moderator = 2,
 Copywriter = 3,
 Editor = 4,
 Administrator = 5
}

public enum UserStatus
{
 Active,
 Blocked
}

public enum CommentHiddenReason
{
 Abuse,
 BadLanguage,
 Racism
}

public enum ArticleCategory
{
 Politics,
 Sports,
 Events,
 Accidents,
 Other
}
