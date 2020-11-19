using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIApp
{
    /*
     * prezentującej dane w postaci obrazka (dla każdej wartości atrybutu inny
obrazek – ograniczyć ilość możliwych wartości do 3),
▪ kliknięcie na kontrolkę powoduje zmianę atrybutu (cyklicznie),
▪ kontrolka posiada publiczną właściwość umożliwiająco pobranie i ustawienie
wartości atrybutu,
▪ kontrolka posiada dedykowany edytor do zmiany wartości tej właściwości
(integracja z Visual Studio),
▪ kontrolka posiada zdarzenie informujące o zmianie wartości atrybutu
    */
    public partial class CategoryControl : UserControl
    {
        public event Action<Book.CategoryEnum> UpdateCategoryEvent;

        public CategoryControl()
        {
            InitializeComponent();
        }

        private Book.CategoryEnum category;
        public Book.CategoryEnum Category
        {
            get { return category; }
            
            set {
                category = value;
                UpdateImage();
                UpdateCategoryEvent?.Invoke(Category);
            }
        }


        private void UpdateImage()
        {
            switch (Category)
            {
                case Book.CategoryEnum.criminal:
                    this.categoryPictureBox.Image = global::MDIApp.Properties.Resources.criminal;
                    break;
                case Book.CategoryEnum.poetry:
                    this.categoryPictureBox.Image = global::MDIApp.Properties.Resources.poetry;
                    break;
                case Book.CategoryEnum.fantasy:
                default:
                    this.categoryPictureBox.Image = global::MDIApp.Properties.Resources.fantasy;
                    break;
            }
        }

        
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Category = (Book.CategoryEnum)(((int)Category + 1) % 3); // next category
            UpdateImage();
        }

        private void CategoryControl_Load(object sender, EventArgs e)
        {

        }
    }
}
