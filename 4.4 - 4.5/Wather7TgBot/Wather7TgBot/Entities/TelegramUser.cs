namespace Wather7TgBot.Entities;

public class TelegramUser
{
    public long BotUserId { get; set; } // Primary Key (Auto-Increment)
    public long TelegramUserId { get; set; } // Telegram foydalanuvchi ID

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? PhoneNumber { get; set; }

    public bool IsBlocked { get; set; } = false; // Default qiymat: false

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Foydalanuvchi qo‘shilgan vaqt
    public DateTime? UpdatedAt { get; set; } // Foydalanuvchi ma’lumotlari yangilangan vaqt (nullable)
}
