namespace BotLearnForExam.Dal.Entities;

public class UserInfo
{
    public long UserInfoId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Summary { get; set; }

    public long BotUserId { get; set; }
    public BotUser BotUser { get; set; }
}