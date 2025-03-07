namespace RamazonTaqvimiBot.Dal.Entities;

public class UserTg
{
    public long BotUserId { get; set; }
    public long TelegramUserId { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? PhoneNumber { get; set; }
    public string Location { get; set; }
    public bool IsBlocked { get; set; } = false;
}
