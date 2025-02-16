namespace E_CommerceSystem.Dal.Enums;

public enum PaymentStatus
{
    Pending,      // To‘lov hali amalga oshirilmagan
    Processing,   // To‘lov jarayonda
    Completed,    // To‘lov muvaffaqiyatli amalga oshirildi
    Failed,       // To‘lov muvaffaqiyatsiz bo‘ldi
    Canceled,     // To‘lov bekor qilindi
    Refunded,     // Pul qaytarildi
    Chargeback    // Mijoz to‘lovni rad etdi (bank orqali qaytarish)
}