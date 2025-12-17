using MudBlazor;

namespace FECompanyDashboard.Layout.Constants;

public static class ThemeFor
{
    public static readonly MudTheme MainLayout = new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#006CB8",
            Secondary = "#6c757d",
            AppbarBackground = "#3E2CDD",
            Background = Colors.Gray.Lighten5,
            Surface = Colors.Shades.White
        },
        PaletteDark = new PaletteDark
        {
            Primary = Colors.Blue.Lighten1,
            Background = Colors.Gray.Darken4,
            Surface = Colors.Gray.Darken3
        }
    };
}
