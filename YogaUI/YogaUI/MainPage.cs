using Xamarin.Forms;
using Xamarin.Forms.Markup;
using static Xamarin.Forms.Markup.GridRowsColumns;

namespace YogaUI
{
    public class MainPage : ContentPage
    {
        Color BgClr = Color.FromHex("#1D252D");

        Style<Label> LabelStyle = new Style<Label>(
            (Label.TextColorProperty, Color.White),
            (Label.FontFamilyProperty, "Arcon Rounded")
        );

        public MainPage() => Build();

        void Build()
        {
            Resources = new ResourceDictionary();
            Resources.Add(LabelStyle);

            // content here
            Content = new StackLayout()
            {
                Padding = new Thickness(15),
                BackgroundColor = BgClr,
                Children = {
                    new Image
                    {
                        Source = "menu.png",
                        WidthRequest = 34,
                        HeightRequest = 34
                    }.Start(),
                    new Label
                    {
                        Text = "Good Morning!"
                    },
                    new Label
                    {
                        Text = "David Ortinau",
                        FontSize = 32,
                        FontFamily = "Montserrat Alternates"
                    },
                    new SearchBar
                    {
                        Placeholder = "Find a routine",
                        BackgroundColor = Color.FromHex("#324958"),
                        PlaceholderColor = Color.White,
                        TextColor = Color.White
                    },
                    new ScrollView
                    {
                        Content =
                                new FlexLayout
                                {
                                    Direction = FlexDirection.Row,
                                    Wrap = FlexWrap.Wrap,
                                    JustifyContent = FlexJustify.SpaceBetween,
                                    AlignItems = FlexAlignItems.Start,
                                    Children =
                                    {
                                        new Label
                                        {
                                            Text = "Choose a Yoga Category",
                                            HeightRequest = 80,
                                            FontFamily = "Montserrat Alternates"
                                        }
                                        .FontSize(28)
                                        .Basis(new FlexBasis(0.5f, true))
                                        .TextCenterVertical(),
                                        new Label
                                        {
                                            Text = "View All"
                                        }
                                            .FontSize(12)
                                            .Basis(new FlexBasis(0.5f, true))
                                            .TextCenterVertical()
                                            .TextEnd(),
                                        CreateCategory("Vinyasa Yoga", "20 Trainers", "vinyasa.png", "#E44C4C"),
                                        CreateCategory("Ashtanga Yoga", "4 Trainers", "ashtanga.png", "#5840E4"),
                                        CreateCategory("Bikram Yoga", "12 Trainers", "bikram.png", "#42A78A"),
                                        CreateCategory("Jivamukti Yoga", "15 Trainers", "jivamukti.png", "#F0CC4F"),
                                        CreateCategory("Iyenger Yoga", "8 Trainers", "iyenger.png", "#8C4FF0"),
                                        CreateCategory("Yin Yoga", "16 Trainers", "yin.png", "#E99340"),
                                        new Label
                                        {
                                            Text = "Essentials for Beginners",
                                            HeightRequest = 80,
                                            FontFamily = "Montserrat Alternates"
                                        }
                                        .FontSize(28)
                                        .Basis(new FlexBasis(1.0f, true))
                                        .TextCenterVertical(),
                                        CreateEssentialBox("Mental Training", "04 Min 20 Sec", "4.5", ""),
                                        CreateEssentialBox("Mental Training", "04 Min 20 Sec", "4.5", ""),
                                        CreateEssentialBox("Mental Training", "04 Min 20 Sec", "4.5", ""),
                                        CreateEssentialBox("Mental Training", "04 Min 20 Sec", "4.5", ""),

                                    }
                                }
                    }.Margin(0,15)
                }
            };
        } // Build
        enum Row { Title, SubTitle, Push }
        Frame CreateCategory(string title, string subtitle, string yogaImage, string bgColor)
        {

            return new Frame
            {
                BackgroundColor = Color.FromHex(bgColor),
                CornerRadius = 15,
                HasShadow = false,
                HeightRequest = 120,
                Padding = 0,
                Content = new Grid
                {
                    RowDefinitions = Rows.Define(
                                (Row.Title, Auto),
                                (Row.SubTitle, Star)
                            ),
                    RowSpacing = 0,
                    Children = {
                                new Image
                                {
                                    Source = yogaImage,
                                    WidthRequest = 80,
                                    Aspect = Aspect.AspectFit,
                                    VerticalOptions = LayoutOptions.End,
                                    HorizontalOptions = LayoutOptions.End
                                }.RowSpan(2).Margins(bottom:-5),
                                new Label {
                                    Text = title,
                                    FontSize = 14,
                                    FontFamily = "Montserrat Alternates"
                                }.Row(Row.Title).Margins(left:12,right:12,top:12),
                                new Label
                                {
                                    Text = subtitle,
                                    FontSize = 12,
                                }.Row(Row.SubTitle).Margins(left:12,right:12),

                            }
                }

            }
                    .Basis(new FlexBasis(0.3f, true))
                    .Margins(top: 5, bottom: 10);
        }

        enum BoxRows { Video, Title, Duration }
        enum BoxCols { Title, Rating }
        Grid CreateEssentialBox(string title, string duration, string rating, string imageSrc)
        {
            return new Grid
            {
                RowDefinitions = Rows.Define(
                    (BoxRows.Video, 120),
                    (BoxRows.Title, 24),
                    (BoxRows.Duration, 20)
                ),
                ColumnDefinitions = Columns.Define(
                    (BoxCols.Title, Star),
                    (BoxCols.Rating, Auto)
                ),
                Children = {
                    new Frame
                    {
                        BackgroundColor = Color.FromHex("#000000"),
                        CornerRadius = 15,
                        HasShadow = false,
                        HeightRequest = 120,
                        Padding = 0,
                        Content = new StackLayout
                        {
                        }
                    }.Row(BoxRows.Video).ColumnSpan(2),
                    new Label
                    {
                        Text = title,
                        FontSize = 18,
                        FontFamily = "Montserrat Alternates"
                    }.Column(BoxCols.Title).Row(BoxRows.Title),
                    new Label
                    {
                        Text = rating,
                        FontSize = 12,
                        FontFamily = "Montserrat Alternates"
                    }.Column(BoxCols.Rating).Row(BoxRows.Title).TextEnd(),
                    new Label
                    {
                        Text = duration,
                        FontSize = 12,
                        TextColor = Color.FromHex("#9191A1")
                    }.Row(BoxRows.Duration)
                }
            }
            .Basis(new FlexBasis(0.48f, true))
            .Margins(top: 5, bottom: 10);
        } // CreateEssentialBox
    }
}