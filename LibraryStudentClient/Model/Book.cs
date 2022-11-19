using LibraryStudentClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibraryStudentClient.Model
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public string Section { get; set; }
        public string Authors { get; set; }


        private RelayCommand? viewSelectedBook;
        public RelayCommand ViewSelectedBook
        {
            get
            {
                return viewSelectedBook ??
                    (viewSelectedBook = new RelayCommand(obj =>
                    {
                        DataManagerMainVM.currentDM.ShowBook();
                    }));
            }
        }
        /*
                    <ListView ItemsSource = "{Binding Books}" Foreground="#FF042271" FontSize="16" Margin="0,10,0,0"
                      SelectedItem="{Binding SelectedBook}">
                <ListView.Background>
                    <LinearGradientBrush EndPoint = "0.5,1" StartPoint="0.5,0">
                        <GradientStop Color = "White" Offset="0.006"/>
                        <GradientStop Color = "Black" Offset="1"/>
                        <GradientStop Color = "#FF60C0CC" Offset="0.567"/>
                        <GradientStop Color = "#FF1D4E69" Offset="0.994"/>
                        <GradientStop Color = "#FFBBD8D8" Offset="0.087"/>
                    </LinearGradientBrush>
                </ListView.Background>
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header = "Название книги" DisplayMemberBinding="{Binding Path=Title}"/>
                        <GridViewColumn Header = "Раздел" DisplayMemberBinding="{Binding Path=Section}"/>
                        <GridViewColumn Header = "Авторы" DisplayMemberBinding="{Binding Path=Authors}" />
                        <GridViewColumn Header = "Издатель" DisplayMemberBinding="{Binding Path=Publisher}"/>
                        <GridViewColumn Header = "Год издания" DisplayMemberBinding="{Binding Path=Year}"/>
                    </GridView>
                </ListView.View>
            </ListView>
        */
    }
}
