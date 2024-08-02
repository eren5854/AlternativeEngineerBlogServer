using Ardalis.SmartEnum;

namespace AlternativeEngineerBlogServer.Domain.Users;
public sealed class UserGenderSmartEnum : SmartEnum<UserGenderSmartEnum>
{
    public static readonly UserGenderSmartEnum Male = new UserGenderSmartEnum("Erkek", 1);
    public static readonly UserGenderSmartEnum Female = new UserGenderSmartEnum("Kadın", 2);
    public static readonly UserGenderSmartEnum Unspecified = new UserGenderSmartEnum("Belirtilmemiş", 3);
    public UserGenderSmartEnum(string name, int value) : base(name, value)
    {
    }
}
