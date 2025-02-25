namespace BotDal.Entity;

public class TelegramUser
{
    public long Id { get; set; }

    public long BotUserId { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
