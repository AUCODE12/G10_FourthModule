namespace E_CommerceSystem.Dal.Enums;

public enum OrderStatus
{
    Pending,        // Buyurtma qabul qilingan, ammo hali tasdiqlanmagan
    Confirmed,      // Buyurtma tasdiqlandi
    Processing,     // Buyurtma tayyorlanmoqda
    Shipped,        // Buyurtma jo‘natildi
    Delivered,      // Buyurtma mijozga yetkazildi
    Canceled,       // Buyurtma bekor qilindi
    Returned,       // Buyurtma qaytarib berildi
    Failed          // Buyurtma bajarilmadi (to‘lov muammosi yoki boshqa sabablar)
}
